using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
    internal class Program
    {
        static int width = 40;
        static int height = 20;
        static int score = 0;
        static ConsoleKey direction = ConsoleKey.RightArrow;
        static bool gameOver = false;

        static void Main()
        {
            Console.CursorVisible = false;
            // Console.SetWindowSize(width, height);

            var snake = new List<(int x, int y)> { (10, 10), (9, 10), (8, 10) };
            var rand = new Random();
            var food = (x: rand.Next(1, width - 2), y: rand.Next(1, height - 2));

            Thread inputThread = new Thread(ReadInput);
            inputThread.Start();

            while (!gameOver)
            {
                Console.Clear();

                // Draw border
                for (int i = 0; i < width; i++) Console.SetCursorPosition(i, 0); Console.Write("-");
                for (int i = 0; i < width; i++) Console.SetCursorPosition(i, height-1); Console.Write("-");
                for (int i = 0; i < height; i++) Console.SetCursorPosition(0, i); Console.Write("|");
                for (int i = 0; i < height; i++) Console.SetCursorPosition(width-1, i); Console.Write("|");

                // Draw food
                Console.SetCursorPosition(food.x, food.y);
                Console.Write("🍎");

                // Move snake
                var head = snake.First();
                var newHead = head;

                switch (direction)
                {
                    case ConsoleKey.RightArrow: newHead.x++; break;
                    case ConsoleKey.LeftArrow: newHead.x--; break;
                    case ConsoleKey.UpArrow: newHead.y--; break;
                    case ConsoleKey.DownArrow: newHead.y++; break;
                }

                if (newHead.x <= 0 || newHead.x >= width-1 || newHead.y <= 0 || newHead.y >= height-1 || snake.Contains(newHead))
                {
                    gameOver = true;
                    break;
                }

                snake.Insert(0, newHead);

                if (newHead == food)
                {
                    score++;
                    food = (rand.Next(1, width-2), rand.Next(1, height-2));
                }
                else
                {
                    snake.RemoveAt(snake.Count - 1);
                }

                // Draw snake
                foreach (var (x, y) in snake)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("■");
                }

                Console.SetCursorPosition(0, height);
                Console.Write($"Score: {score}");

                Thread.Sleep(100);
            }

            Console.Clear();
            Console.WriteLine("💀 Game Over! Score: " + score);
        }

        static void ReadInput()
        {
            while (!gameOver)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow && direction != ConsoleKey.DownArrow)
                    direction = ConsoleKey.UpArrow;
                if (key == ConsoleKey.DownArrow && direction != ConsoleKey.UpArrow)
                    direction = ConsoleKey.DownArrow;
                if (key == ConsoleKey.LeftArrow && direction != ConsoleKey.RightArrow)
                    direction = ConsoleKey.LeftArrow;
                if (key == ConsoleKey.RightArrow && direction != ConsoleKey.LeftArrow)
                    direction = ConsoleKey.RightArrow;
            }
        }
    }
}
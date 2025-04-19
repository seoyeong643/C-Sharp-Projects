using System;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;
            int result;
            char operation;

            Console.WriteLine("Hello, welcome to the calculator program!");
            Console.WriteLine("Please enter the first number.");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the second number.");
            num2 = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("What type of operation would you like to perform?");
            System.Console.WriteLine("Please enter + for addition, - for subtraction, * for multiplication, or / for division.");
            
            string? input = Console.ReadLine(); // safer input handling
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            operation = Convert.ToChar(input);

            if (operation == '+')
            {
                result = num1 + num2;
            }
            else if (operation == '-')
            {
                result = num1 - num2;
            }
            else if (operation == '*')
            {
                result = num1 * num2;
            }
            else if (operation == '/')
            {
                if (num2 == 0)
                {
                    Console.WriteLine("Cannot divide by zero.");
                    return;
                }
                result = num1 / num2;
            }
            else
            {
                Console.WriteLine("Please enter a valid operator.");
                return;
            }
            Console.WriteLine("The result is: " + result);
        }
    }
}
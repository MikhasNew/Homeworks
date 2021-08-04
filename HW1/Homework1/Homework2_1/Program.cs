using System;

namespace Homework2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
                int counter = 0;
                double sum = 0;

                Console.WriteLine("Enter numbers separating by Enter. Symbol zero stoped your input");
                string userInput = Console.ReadLine();
                double parsrUserInput = 0;

                while (userInput != "0")
                {
                    if (double.TryParse(userInput.Replace(" ", "").Replace('.', ','), out parsrUserInput))
                    {
                        if (double.IsInfinity(parsrUserInput))
                        {
                            PrintWarning("Number contains too many digits");
                            userInput = Console.ReadLine();
                            continue;
                        }
                            counter++;
                            sum = sum + parsrUserInput;
                            Console.WriteLine($"Your input: {parsrUserInput}, enter next number");
                            userInput = Console.ReadLine();
                        
                    }
                    else
                    {
                        PrintWarning(@"Please enter positive and negative, whole or fractional numbers. Example: -23,3 ");
                        userInput = Console.ReadLine();
                    }

                }

                double average = sum / counter;
                if (double.IsInfinity(sum))
                {
                    PrintWarning("The sum of the numbers entered is too large. Buffer is overflow.");
                }
                else
                {
                    if (counter > 1)
                    {
                        Console.WriteLine($"Your input {counter} numbers. Summ of the numbers = {sum}, average = {average}");
                    }
                    else
                    {
                        if (counter == 0)
                            Console.WriteLine($"Your not input number.");
                        else
                        Console.WriteLine($"Your input {counter} number. Is number = {sum}");
                    }
                }
            
            static void PrintWarning(string message)
            {
                var conFColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = conFColor;
            }



        }
    }
}

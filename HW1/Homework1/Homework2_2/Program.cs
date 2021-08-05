using System;
using Homework2_1;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Homework2_2
{ 
    class Program
    {
       
        static void Main(string[] args)
        {
            HW_2();
        }
        static void HW_2()
        {
            double int1 = 0;
            double int2 = 0;

            double int1ToZero = 0;
            double int2ToZero = 0;

            Console.WriteLine("Enebled interval of numbers. Enter the first border of the interval.");
            if (ReadNumbers(Console.ReadLine(), out int1))
            {
                Console.WriteLine("Enter second border of the interval.");
                if (ReadNumbers(Console.ReadLine(), out int2))
                {
                    double doubleSumm = 0;

                    if (int1 > int2) //revers interval
                    {
                        double temp = int1;
                        int1 = int2;
                        int2 = temp;
                    }

                    Console.WriteLine($"You set the interval: {int1} - {int2}.");

                    //Math.Floor округляет вниз по направлению к отрицательной бесконечности.
                    //Math.Ceiling округляет вверх по направлению к положительной бесконечности.
                    //Math.Truncate округляет вниз или вверх по направлению к нулю.

                    //  int1ToZero = decimal.Ceiling(int1);  //first number is always rounded to zero
                    // int2ToZero = decimal.Floor(int2); //if second number round down
                    int1ToZero = Math.Ceiling(int1);
                    int2ToZero = Math.Floor(int2);

                    try
                    {
                        /////
                        // Stopwatch stopwatch = new Stopwatch();
                        // stopwatch.Start();

                        doubleSumm = 0;
                        double i = 0;

                        if (int1ToZero % 2 != 0)     
                        {
                            i = int1ToZero;
                        }
                        else
                            i = int1ToZero + 1;

                        for (; i <= int2ToZero; i += 2)
                        {
                            doubleSumm += i;
                            if(double.IsInfinity(doubleSumm))
                            {
                                Homework2_1.Program.PrintWarning(" The sum of the numbers entered is too large. Buffer is overflow.");
                                break;
                            }

                        }

                        Console.WriteLine($"Sum of odd numbers within this interval = {doubleSumm}");

                        //  stopwatch.Stop();
                        // Console.WriteLine(stopwatch.ElapsedMilliseconds);

                        // stopwatch = new Stopwatch();
                        // stopwatch.Start();

                        //doubleSumm = 0;
                        //for (double ii = int1ToZero; ii <= int2ToZero; ii++)
                        //{
                        //    if (ii % 2 != 0)
                        //    {
                        //        doubleSumm += ii;
                        //    }
                        //}

                        //Console.WriteLine($"Sum of odd numbers within this interval = {doubleSumm}");

                        // stopwatch.Stop();
                        //смотрим сколько миллисекунд было затрачено на выполнение
                        //  Console.WriteLine(stopwatch.ElapsedMilliseconds);
                    }
                    catch (Exception Ex)
                    {
                        Homework2_1.Program.PrintWarning(Ex.Message + " Press any key or enter ESC to exit");
                        var ConsoleKey = Console.ReadKey();
                        if (ConsoleKey.Key != System.ConsoleKey.Escape)
                        {
                            HW_2();
                        }

                    }

                }

            }
        }
        static bool ReadNumbers(string userInput, out double parsrUserInput)
        {
            parsrUserInput = 0;
            bool iDdouble = false;
            userInput = userInput.Replace(" ", "").Replace('.', ',');

            if (!double.TryParse(userInput, out parsrUserInput))
            {

                Homework2_1.Program.PrintWarning(@"Please enter positive and negative, whole or fractional numbers. Example: -23,3. Or enter Ext. ");
                userInput = Console.ReadLine();

                if (userInput == "Ext")
                {
                    iDdouble = false;
                }
                else
                {
                    iDdouble = ReadNumbers(userInput, out parsrUserInput);
                }
            }
            else
            {

                if (!IsInfinity(parsrUserInput, true))
                {
                    iDdouble = true;
                }
                else
                {
                    userInput = Console.ReadLine();

                    if (userInput == "Ext")
                    {
                        iDdouble = false;
                    }
                    else
                    {
                        iDdouble = ReadNumbers(userInput, out parsrUserInput);
                    }
                }
                //Console.WriteLine($"Your input: {parsrUserInput}, enter next number");

            }


            return iDdouble;

        }
        static bool IsInfinity(double dicit, bool printErrorString = false)
        {
            if (dicit <= double.MaxValue && dicit >= double.MinValue)
            {
                return false;
            }
            else
            {
                if (printErrorString)
                   Homework2_1.Program.PrintWarning(@"Buffer is overflowed. Enter a other number or enter Ext. ");
                return true;
            }
        }
    }
}

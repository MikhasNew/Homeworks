﻿using System;
using System.Collections.Generic;

namespace Homework2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //  double temp = double.NaN;
            double intit1 = double.NaN;
            double intit2 = double.NaN;
            char oprt = ' ';
            string temp = "";
            HW_4_3();


        }
        static void ShowMenu()
        {

            Console.WriteLine("The calculator will help you with calculations.\n" +
                "Enter one of the following functions:\n" +
                "1 sequential data entry and operations.\n" +
                "2 counting the sum of entered numbers.\n" +
                "3 counting a string expression like a * b = ");
            char select = Console.ReadKey().KeyChar;
            switch (select)
            {
                case '1':
                    //  HW_4_1();
                    break;
                case '2':
                    //  HW_4_2();
                    break;
                case '3':
                    HW_4_3();
                    break;
                default:
                    PrintWarning("Select action 1, 2 or 3");
                    ShowMenu();
                    break;

            }

        }

        static void HW_4_3()
        {
            char operation;
            double a = 0;
            double b = 0;





            a = double.Parse(ReadDigitals(out operation));

            b = double.Parse(ReadDigitals(new List<char> { '=', '\r' }));
           var lkjl = operatorFunc(a, b, operation);


        }

        static bool IsOperation(char inChar)
        {

            List<char> operators = new List<char> { '+', '-', '*', '/', '^', '!', '=' };
            while (!operators.Contains(inChar))
            {
                return false;
            }
            return true;
        }
        static bool IsDigitals(char inChar)
        {

            List<char> digitals = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            while (!digitals.Contains(inChar))
            {
                return false;
            }
            return true;
        }
        static char ReadOperation()
        {

            List<char> operators = new List<char> { '+', '-', '*', '/', '^', '!' };
            var c = Console.ReadKey(true).KeyChar;
            while (!operators.Contains(c))
            {
                // Console.WriteLine("Select following operations: '+', '-', '*', '/', '^', '!'.");
                var x = ReadOperation();
                return x;
            }

            Console.WriteLine(c.ToString());
            return c;
        }
        static char ReadDigitals()
        {

            List<char> operators = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var c = Console.ReadKey(true).KeyChar;
            while (!operators.Contains(c))
            {
                // Console.WriteLine("Select following operations: '+', '-', '*', '/', '^', '!'.");
                var x = ReadDigitals();
                return x;
            }

            Console.Write(c.ToString());
            return c;
        }
        static string ReadDigitals(out char operationSimbol)
        {
            bool stopRead = false;
            bool tck = false;
            string bufrStr = "";
            operationSimbol = '?';

            List<char> operators;


            operators = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.', '+', '-', '*', '/', '^', '!' };


            var c = Console.ReadKey(true).KeyChar;
            while (!stopRead)
            {
                if (operators.Contains(c))
                {

                    if ((c == ',' || c == '.'))
                    {
                        if (!tck)
                        {
                            bufrStr += ',';
                            tck = true;
                            Console.Write(c.ToString());

                        }
                        c = Console.ReadKey(true).KeyChar;
                        continue;
                    }

                    if (IsOperation(c) && bufrStr.Replace(" ", "").Replace('.', ',') != "")
                    {
                        Console.Write(c.ToString());
                        operationSimbol = c;
                        stopRead = true;
                        return bufrStr;

                    }

                    bufrStr += c;
                    Console.Write(c.ToString());
                    c = Console.ReadKey(true).KeyChar;
                    //continue;

                }
                else
                    c = Console.ReadKey(true).KeyChar;
            }

            return bufrStr;
        }
        static string ReadDigitals(List<char> stopSimbols)
        {
            bool stopRead = false;
            bool tck = false;
            string bufrStr = "";


            List<char> operators = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.' };
            operators.AddRange(stopSimbols);

            var c = Console.ReadKey(true).KeyChar;
            while (!stopRead)
            {
                if (operators.Contains(c))
                {

                    if ((c == ',' || c == '.'))
                    {
                        if (!tck)
                        {
                            bufrStr += ',';
                            tck = true;
                            Console.Write(c.ToString());

                        }
                        c = Console.ReadKey(true).KeyChar;
                        continue;
                    }

                    if (stopSimbols.Contains(c) && IsOperation(c) && bufrStr.Replace(" ", "").Replace('.', ',') != "")
                    {
                        Console.Write(c.ToString());

                        stopRead = true;
                        return bufrStr;

                    }

                    bufrStr += c;
                    Console.Write(c.ToString());
                    c = Console.ReadKey(true).KeyChar;
                    //continue;

                }
                else
                    c = Console.ReadKey(true).KeyChar;
            }

            return bufrStr;
        }
        static double operatorFunc(double int1, double int2, char operation)
        {
            double resalt = double.NaN;
            if (operation != '!')
            {
                
                                   
                    switch (operation)
                    {
                        case '+':
                            resalt = Summ(int1, int2);
                            break;
                        case '-':
                            resalt = Subtract(int1, int2);
                            break;
                        case '*':
                            resalt = Multipl(int1, int2);
                            break;
                        case '/':
                            if (int2 == 0)
                            {
                                PrintWarning("Division by zero is not possible");
                                break;
                            }
                            else
                            {
                                resalt = Division(int1, int2);
                                break;
                            }
                        case '^':
                            resalt = Degree(int1, int2);
                            break;
                        default:
                            //  Console.WriteLine($"Operation {operation} not recognized");
                            break;
                    }

                
            }
            else
            {
                if (!IsFractional(int1, true) && int1 >= 0) //!double.IsNegative()
                {
                    resalt = Factorial(int1);
                }
                else
                {
                    PrintWarning("Factorial is the product of all positive integers less than or equal to N.");
                }

            }
            
            return resalt;
        }


        static double Summ(double a, double b)
        {
            return a + b;
        }
        static double Subtract(double a, double b)
        {
            return a - b;
        }
        static double Multipl(double a, double b)
        {
            return (a * b);

        }
        static double Division(double a, double b)
        {
            return a / b;
        }
        static double Degree(double value, double pow)
        {
            // for positive and negative integers:

            //if (pow > 0)
            //{
            //    return value * Degree(value, pow - 1);
            //}
            //else
            //{
            //    if (pow == 0)
            //        return 1;
            //    else return 1 / (value * Degree(value, -pow - 1));
            //}

            return Math.Pow(value, pow);
        }
        static double Factorial(double n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                try
                {
                    return checked(n * Factorial(n - 1));
                }
                catch (Exception e)
                {
                    PrintWarning(e.ToString());
                    return double.NaN;
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

                PrintWarning(@"Please enter positive and negative, whole or fractional numbers. Example: -23,3. Or enter Ext. ");
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
                    PrintWarning(@"Buffer is overflowed. Enter a other number or enter Ext. ");
                return true;
            }
        }
        static bool IsFractional(double dicit, bool printErrorString = false)
        {
            if (dicit % 1 == 0)
            {
                return false;
            }
            else
            {
                if (printErrorString)
                    PrintWarning(@"Not an integer value entered. ");
                return true;
            }
        }

        public static void PrintWarning(string message)
        {
            var conFColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = conFColor;
        }

        


        }
    }


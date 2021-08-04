using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace Homework2_3
{
    class Program
    {
        #region Console size setting 
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();

        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int HIDE = 0;

        private const int MAXIMIZE = 3;

        private const int MINIMIZE = 6;

        private const int RESTORE = 9;
        #endregion
        static void Main(string[] args)
        {
            HW_3();
            
        }
        static void HW_3()
        {

            byte rectanglHeight = 0;
            Console.WriteLine("set the height of the triangle");
            if (byte.TryParse(Console.ReadLine(), out rectanglHeight))
            {
                //uint baseSymblCount =0;
                //uint indentSymblCount =0;

                int[] listOddNambers = PositiveOddNambersGenerator(rectanglHeight);


                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight); //Set Console Max Sice
                ShowWindow(ThisConsole, MAXIMIZE);
                if (Console.WindowWidth <= listOddNambers[listOddNambers.Length - 1] + 20)
                {
                    Console.BufferWidth = listOddNambers[listOddNambers.Length - 1] + 20;
                }

                int otsp = rectanglHeight;
                foreach (int nmbr in listOddNambers)
                {
                    Console.WriteLine(new String(' ', otsp--) + new String('^', nmbr));
                }

            }
            else
            {
                PrintWarning("Height of the triangle can be a positive integer up to 255.  Press any key or ESC to exit");
                var ConsoleKey = Console.ReadKey();
                if (ConsoleKey.Key != System.ConsoleKey.Escape)
                {
                    HW_3();
                }

            }
        }
        static int[] PositiveOddNambersGenerator(int nambersCount)
        {
            int[] listOddNambers = new int[nambersCount];

            int i = 0;
            for (int OddNamber = 1; ; OddNamber = OddNamber + 2) //odd number generator
            {
                if (i < nambersCount)
                {
                    listOddNambers[i] = OddNamber;
                    i++;
                }
                else
                    break;
            }
            return listOddNambers;
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

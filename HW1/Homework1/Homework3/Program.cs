using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace AbstractFactoryDepo
{
    class Program
    {
        static void Main(string[] args)
        {
            showMenu();

        }
        static void showMenu()
        {
            Console.WriteLine("Start a demonstration? Press Y or N. Press E to Exit."); 
            var bl = setYesOrNo();
            if (bl)
            {
                startDemo();
                showMenu();
            }
            else
            {
                go();
                showMenu();
            }
        }
        static void go()
        {
            uint svCount, compartmentCount, reservedSeatCount, seatedCarsCount;
            LocomotiveTypes locomotiveType = setLocomotiveType();

            Console.WriteLine("Enter the number of purchased SV class tickets");
            svCount = setPassangerCounts();

            Console.WriteLine("Enter the number of purchased compartment class tickets");
            compartmentCount = setPassangerCounts();

            Console.WriteLine("Enter the number of purchased reserved seat class tickets");
            reservedSeatCount = setPassangerCounts();

            Console.WriteLine("Enter the number of purchased seated cars class tickets");
            seatedCarsCount = setPassangerCounts();

            Console.WriteLine("Use castom parametrs from xml? Press Y or N.");
            var useXml = setYesOrNo();
            var train = new Train(locomotiveType, useXml, svCount, compartmentCount, reservedSeatCount, seatedCarsCount);

            // var train = new Train(locomotiveType, svCount, compartmentCount, reservedSeatCount, seatedCarsCount);

            Console.WriteLine($"\r\n" +
                $"You have identified a train consisting of " +
                $"{train.Locomotives.Count} locomotives and {train.RailwayСarriages.Count} passenger wagons " +
                $"with a total mass of {train.getOwnTrainMass()} . " +
                $"The total number of passengers {train.getTotallReservedPlaceCount()}, " +
                $"free {train.getTotallFreePlaceCount()} places, bagage count - {train.getTotallBagageCount()}." +
                $"\r\n");

            Console.WriteLine(train.getInfo());

            Console.WriteLine("This is a train sorted in descending order of carriage comfort.\r\n\r\n");
            train.sortOrderComfortToIncrease();
            Console.WriteLine(train.getInfo());
        }
       
        static void startDemo()
        {
            uint svCount, compartmentCount, reservedSeatCount, seatedCarsCount;
            LocomotiveTypes locomotiveType;

            Console.WriteLine("Welcome to the train depot. " +
                "The project will allow you to form trains " +
                "for electrified and non - electrified " +
                "directions of passenger transportation " +
                "based on the number of purchased tickets " +
                "in SV cars, compartments, reserved seats and seated cars.  " +
                "Now we will demonstrate our capabilities. " +
                "\r\n");
            Thread.Sleep(1200);
            Console.WriteLine("Specify the type of locomotive (Diesel or electric)" +
                " and enter the count of tickets sold for the corresponding comfort" +
                "\r\n");
            Thread.Sleep(1200);
            Console.WriteLine("Indicate the type of locomotive ('d'-diesel,' e'-electro)");
            locomotiveType = LocomotiveTypes.Diesel;
            Thread.Sleep(1200);
            Console.WriteLine("Enter the number of purchased SV class tickets");
            Console.WriteLine("56");
            svCount = 56;
            Thread.Sleep(1200);
            Console.WriteLine("Enter the number of purchased compartment class tickets");
            Console.WriteLine("76");
            compartmentCount = 76;
            Thread.Sleep(1200);
            Console.WriteLine("Enter the number of purchased reserved seat class tickets");
            Console.WriteLine("243");
            reservedSeatCount = 243;
            Thread.Sleep(1200);
            Console.WriteLine("Enter the number of purchased seated cars class tickets");
            Console.WriteLine("245");
            seatedCarsCount = 245;
            Thread.Sleep(1200);
            Console.WriteLine($"You can use default parameters or data from xml file in folder {Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}");
            Thread.Sleep(1200);
            Console.WriteLine("Use castom parametrs from xml? Press Y or N.");
            Console.WriteLine("Y");
            Thread.Sleep(1200);
            var useXml = true;
            var train = new Train(locomotiveType, useXml, 56, 76, 243, 245);

            Console.WriteLine($"\r\n" +
                $"You have identified a train consisting of " +
                $"{train.Locomotives.Count} locomotives and {train.RailwayСarriages.Count} passenger wagons " +
                $"with a total mass of {train.getOwnTrainMass()} . " +
                $"The total number of passengers {train.getTotallReservedPlaceCount()}, " +
                $"free {train.getTotallFreePlaceCount()} places, bagage count - {train.getTotallBagageCount()}." +
                $"\r\n");
            Thread.Sleep(1200);
            Console.WriteLine(train.getInfo());
            Thread.Sleep(1200);
            Console.WriteLine("This is a train sorted in descending order of carriage comfort.\r\n\r\n");
            train.sortOrderComfortToIncrease();
            Console.WriteLine(train.getInfo());

        }
        private static uint setPassangerCounts()
        {
            uint Count = 0;
            try
            {
                Count = uint.Parse(Console.ReadLine());
            }

            catch (Exception e)
            {
                PrintWarning.Print(e.Message);
                Count = setPassangerCounts();
            }
            return Count;

        }

        private static LocomotiveTypes setLocomotiveType()
        {
            Console.WriteLine("Indicate the type of locomotive ('d'-diesel,' e'-electro)");
            switch (ReadLocomotyveTyp())
            {
                case 'D' or 'd':
                    return LocomotiveTypes.Diesel;
                case 'E' or 'e':
                    return LocomotiveTypes.Electro;
                default:
                    return LocomotiveTypes.Unknown;
            }
        }

        private static bool setYesOrNo()
        {
           switch (Console.ReadKey(true).KeyChar)
            {
                case 'Y' or 'y':
                    Console.WriteLine("\r\n");
                    return true;
                case 'N' or 'n':
                    Console.WriteLine("\r\n");
                    return false;
                case 'E' or 'e':
                    Console.WriteLine("\r\n");
                    Environment.Exit(0);
                    return false;
                default:
                    return setYesOrNo();
            }
            
        }

        static char ReadLocomotyveTyp()
        {
            List<char> operators = new List<char> { 'd', 'D', 'e', 'E' };
            var c = Console.ReadKey(true).KeyChar;
            while (!operators.Contains(c))
            {
                var x = ReadLocomotyveTyp();
                return x;
            }
            Console.WriteLine(c.ToString());
            return c;
        }
        
    }
}

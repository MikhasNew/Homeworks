using AbstractFactoryDepo.Pattern.LocomotiveClasse;
using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AbstractFactoryDepo.Pattern.Model
{

    public static class PrintWarning
    {
        public static void Print(string text)
        {
            var conFColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = conFColor;
        }
    }
}

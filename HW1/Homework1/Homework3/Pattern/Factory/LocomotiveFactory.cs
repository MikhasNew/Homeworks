using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.Factory
{
    public class LocomotiveFactory : AbstractLocomotiveFactory
    {
        public override AbstractLocomotive GreateLocomotive(LocomotiveTypes locomotiveType)
        {
            switch (locomotiveType)
            {
                case LocomotiveTypes.Diesel:
                    return new LocomotiveClasse.DiselLocomotive();
                case LocomotiveTypes.Electro:
                    return new LocomotiveClasse.ElectroLocomotive();
                default:
                    return new LocomotiveClasse.UnknownLocomotive();
            }
        }

        public override AbstractLocomotive GreateLocomotive(LocomotiveTypes locomotiveType, bool xmlConfig)
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string resPath = assemblyPath + "\\Resource\\locomotives.xml"; //Path.Combine(assemblyPath, "locomotives.xml");
            try
            {
                if (xmlConfig)
                {
                    var locomotives = (List<AbstractLocomotive>)XmlReader.ReadEntry(typeof(List<AbstractLocomotive>), resPath);
                    AbstractLocomotive abstractLocomotive = null;
                   // bool isTruData = false;
                    foreach (var lc in locomotives)
                    {
                        if (lc.LocamativeType == locomotiveType)
                        {
                            switch (locomotiveType)
                            {
                                case LocomotiveTypes.Diesel:
                                    abstractLocomotive = new LocomotiveClasse.DiselLocomotive(lc.LocamativeModel, lc.OwnMass, lc.MaxMass);
                                    break;
                                case LocomotiveTypes.Electro:
                                    abstractLocomotive = new LocomotiveClasse.ElectroLocomotive(lc.LocamativeModel, lc.OwnMass, lc.MaxMass);
                                    break;
                                default:
                                    abstractLocomotive = new LocomotiveClasse.UnknownLocomotive(lc.LocamativeModel, lc.OwnMass, lc.MaxMass);
                                    break;
                            }
                        }

                    }
                    return abstractLocomotive;

                }
                else
                    return GreateLocomotive(locomotiveType);
            }
            catch (Exception e)
            {
                PrintWarning.Print(e.Message+ "\r\n" + resPath);
                Console.WriteLine("\r\n\r\nUssed default pararmetrs");
                return GreateLocomotive(locomotiveType);

            }

        }
    }
}
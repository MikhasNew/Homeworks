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
    public class RailwayСarriageFactory : AbstractRailwayСarriageFactory
    {
        public override AbstractRailwayСarriage GreateRailwayСarriage(RailwayСarriageTypes railwayСarriageType)
        {
            switch (railwayСarriageType)
            {
                case RailwayСarriageTypes.SV:
                    return new RailwayСarriageClasse.SvRailwayСarriage();
                case RailwayСarriageTypes.SeatedCars:
                    return new RailwayСarriageClasse.SeatedCarsRailwayСarriage();
                case RailwayСarriageTypes.ReservedSeat:
                    return new RailwayСarriageClasse.ReservedSeatRailwayСarriage();
                case RailwayСarriageTypes.Compartment:
                    return new RailwayСarriageClasse.CompartmentRailwayСarriage();
                default:
                    return new RailwayСarriageClasse.UnknownRailwayСarriage();

            }
        }

        public override AbstractRailwayСarriage GreateRailwayСarriage(RailwayСarriageTypes railwayСarriageType, bool xmlConfig)
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string resPath = Path.Combine(assemblyPath, "railwayСarriages.xml");
            try
            {
                if (xmlConfig)
                {
                    var railwayСarriages = (List<AbstractRailwayСarriage>)XmlReader.ReadEntry(typeof(List<AbstractRailwayСarriage>), resPath);
                    AbstractRailwayСarriage abstractRailwayСarriage = null;
                    //bool isTruData = false;
                    foreach (var rc in railwayСarriages)
                    {
                        if (rc.RailwayСarriageType == railwayСarriageType)
                        {
                            switch (railwayСarriageType)
                            {
                                case RailwayСarriageTypes.SV:
                                    abstractRailwayСarriage = new RailwayСarriageClasse.SvRailwayСarriage(rc.RailwayСarriageModel, rc.OwnMass, rc.PassengersCount, rc.BagageCount);
                                    break;
                                case RailwayСarriageTypes.SeatedCars:
                                    abstractRailwayСarriage = new RailwayСarriageClasse.SeatedCarsRailwayСarriage(rc.RailwayСarriageModel, rc.OwnMass, rc.PassengersCount, rc.BagageCount);
                                    break;
                                case RailwayСarriageTypes.ReservedSeat:
                                    abstractRailwayСarriage = new RailwayСarriageClasse.ReservedSeatRailwayСarriage(rc.RailwayСarriageModel, rc.OwnMass, rc.PassengersCount, rc.BagageCount);
                                    break;
                                case RailwayСarriageTypes.Compartment:
                                    abstractRailwayСarriage = new RailwayСarriageClasse.CompartmentRailwayСarriage(rc.RailwayСarriageModel, rc.OwnMass, rc.PassengersCount, rc.BagageCount);
                                    break;
                                default:
                                    abstractRailwayСarriage = new RailwayСarriageClasse.UnknownRailwayСarriage(rc.RailwayСarriageModel, rc.OwnMass, rc.PassengersCount, rc.BagageCount);
                                    break;

                            }
                        }

                    }
                    return abstractRailwayСarriage;
                }
                else
                    return GreateRailwayСarriage(railwayСarriageType);
            }
            catch (Exception e)
            {
                PrintWarning.Print(e.Message + "\r\n" + resPath);
                Console.WriteLine("\r\n\r\nUssed default pararmetrs");
                return GreateRailwayСarriage(railwayСarriageType);

            }

        }
    }
}
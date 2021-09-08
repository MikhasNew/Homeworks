using AbstractFactoryDepo.Pattern.RailwayСarriageClasse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AbstractFactoryDepo.Pattern.Model
{
    [XmlInclude(typeof(CompartmentRailwayСarriage))]
    [XmlInclude(typeof(ReservedSeatRailwayСarriage))]
    [XmlInclude(typeof(SeatedCarsRailwayСarriage))]
    [XmlInclude(typeof(SvRailwayСarriage))]
    [XmlInclude(typeof(UnknownRailwayСarriage))]
    public abstract class AbstractRailwayСarriage : IComparable
    {
        public int ID { get; set; }

        /// <summary>
        /// Model of RailwayСarriage.
        /// </summary>
        public string RailwayСarriageModel { get; set; } = "Default";

        /// <summary>
        /// Comfort type of Railway Сarriage.
        /// </summary>
        public RailwayСarriageTypes RailwayСarriageType { get; set; }

        /// <summary>
		/// Own mass of locomative.
		/// </summary>
        public int OwnMass { get;  set; }

        /// <summary>
		/// Passangers count.
		/// </summary>
        public int PassengersCount { get;  set; }

        /// <summary>
        /// Own reserved place Count.
        /// </summary>
        public int ReservedPlaceCount { get; set; }

        /// <summary>
        /// Free Place Count.
        /// </summary>
        public int FreePlaceCount { get; set; }

        /// <summary>
		/// Number of bagage.
		/// </summary>
		public int BagageCount { get;  set; }

        /// <summary>
		/// Sort the railway carriage by comfort order to lower.
		/// </summary>
        public int CompareTo(object obj)
        {
            return RailwayСarriageType.CompareTo((obj as AbstractRailwayСarriage).RailwayСarriageType);
        }

        public string GetInfo()
        {
            return $"---ID of railwayСarriage - {ID},\r\n " +
                $"Model of railwayСarriage - {RailwayСarriageModel},\r\n" +
                $"Comfort type of railway Сarriage - {RailwayСarriageType },\r\n" +
                $"Own mass of locomative - {OwnMass },\r\n" +
                $"Passangers place count - {PassengersCount },\r\n" +
                $"Reserved place count - {ReservedPlaceCount },\r\n" +
                $"Free place Count - {FreePlaceCount },\r\n" +
                $"Number of bagage - {BagageCount },\r\n"+
                $"\r\n";
        }

    }
}

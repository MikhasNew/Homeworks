using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.Model
{
	public  class Train
    {
		private Model.LocomotiveTypes LocomType;
		private Dictionary<Model.RailwayСarriageTypes, uint> RcDictionary;
		
		public List<AbstractLocomotive> Locomotives;
		public readonly List<AbstractRailwayСarriage> RailwayСarriages;

		private Factory.LocomotiveFactory LocomotiveFactory;
		private Factory.RailwayСarriageFactory RailwayСarriageFactory;
				
		public Train(Model.LocomotiveTypes type, bool usingXMLSettings, uint svCount, uint compartmentCount, uint reservedSeatCount, uint seatedCarsCount)
		{
			
				LocomType = type;
				RcDictionary = new Dictionary<RailwayСarriageTypes, uint> {
				{RailwayСarriageTypes.SV, svCount },
				{RailwayСarriageTypes.Compartment, compartmentCount},
				{RailwayСarriageTypes.ReservedSeat, reservedSeatCount },
				{RailwayСarriageTypes.SeatedCars, seatedCarsCount }
			};

				LocomotiveFactory = new Factory.LocomotiveFactory();
				RailwayСarriageFactory = new Factory.RailwayСarriageFactory();

				Locomotives = new List<AbstractLocomotive>();
				RailwayСarriages = new List<AbstractRailwayСarriage>();

				buildTrain(usingXMLSettings);
			
		}
		
		private void buildTrain(bool xmlConfig)
		{
			int id = 0;
			foreach (var n in RcDictionary)
			{
				for (int i = 0; i < n.Value;) //if n.value == 0 not add the carriege
				{
					var rc = RailwayСarriageFactory.GreateRailwayСarriage(n.Key, xmlConfig);
					rc.ID = id++;
					addRailwayСarriage(rc);
					i += rc.PassengersCount;
					if (i > n.Value)
					{
						rc.FreePlaceCount = i - (int)n.Value;
						rc.ReservedPlaceCount = rc.PassengersCount - rc.FreePlaceCount;
					}
					else
						rc.ReservedPlaceCount = rc.PassengersCount;
				}
			}
			int rcOwnMass = getOwnTrainMass();
			id = 0;
			for (int maxTrainMass = 0; maxTrainMass <= rcOwnMass;)
			{
				var lc = LocomotiveFactory.GreateLocomotive(LocomType, xmlConfig);
				lc.ID = id++;
				Locomotives.Add(lc);

				rcOwnMass += lc.OwnMass;
				maxTrainMass += lc.MaxMass;
			}

		}

		public void addLocomotive(Model.AbstractLocomotive locomotive)
		{
			Locomotives.Add(locomotive);
		}
		public void addRailwayСarriage(Model.AbstractRailwayСarriage railwayСarriage)
		{
			RailwayСarriages.Add(railwayСarriage);
		}
		public int getOwnTrainMass()
		{
			int m = 0;
			foreach (var rc in RailwayСarriages)
			{
				m += rc.OwnMass;
			}

			foreach (var lc in Locomotives)
			{
				m += lc.OwnMass;
			}
			return m;
		}
		public int getTotallReservedPlaceCount()
		{
			int reservedPlaceCount=0;
			foreach (var rw in RailwayСarriages)
			{
				reservedPlaceCount += rw.ReservedPlaceCount;
			}
			return reservedPlaceCount;
		}
		public int getTotallFreePlaceCount()
		{
			int freePlaceCount = 0;
			foreach (var rw in RailwayСarriages)
			{
				freePlaceCount += rw.FreePlaceCount;
			}
			return freePlaceCount;
		}
		public int getTotallBagageCount()
		{
			int bagageCount = 0;
			foreach (var rw in RailwayСarriages)
			{
				bagageCount += rw.BagageCount;
			}
			return bagageCount;
		}
		public string getInfo()
		{

			StringBuilder stringBuilder = new StringBuilder("This is information about the train.\r\n");
			foreach (var lc in Locomotives)
			{
				stringBuilder.Append(lc.GetInfo());
				
			}
			foreach (var rc in RailwayСarriages)
			{
				stringBuilder.Append(rc.GetInfo());
				
			}
			return stringBuilder.ToString();
		}
		public void sortOrderComfortToLower()
		{
			RailwayСarriages.Sort();
		}
		public void sortOrderComfortToIncrease()
		{
			RailwayСarriages.Sort();
			RailwayСarriages.Reverse();
		}
	}
}

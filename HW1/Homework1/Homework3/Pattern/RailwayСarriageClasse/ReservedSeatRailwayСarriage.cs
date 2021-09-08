using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.RailwayСarriageClasse
{
    [Serializable]
    public  class ReservedSeatRailwayСarriage: AbstractRailwayСarriage
    {
        public ReservedSeatRailwayСarriage()
        {
            RailwayСarriageType = RailwayСarriageTypes.ReservedSeat;
            OwnMass = 1300;
            PassengersCount = 88;
            BagageCount = 100;
        }
        public ReservedSeatRailwayСarriage(string model, int ownMass, int passengersCount, int bagageCount)
        {
            RailwayСarriageModel = model;
            RailwayСarriageType = RailwayСarriageTypes.ReservedSeat;
            OwnMass = ownMass;
            PassengersCount = passengersCount;
            BagageCount = bagageCount;
        }
        
    }
}

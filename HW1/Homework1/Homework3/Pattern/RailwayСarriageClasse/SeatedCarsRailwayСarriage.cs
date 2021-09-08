using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.RailwayСarriageClasse
{
    [Serializable]
    public class SeatedCarsRailwayСarriage: AbstractRailwayСarriage
    {
        public SeatedCarsRailwayСarriage()
        {
            RailwayСarriageType = RailwayСarriageTypes.SeatedCars;
            OwnMass = 1200;
            PassengersCount = 120;
            BagageCount = 120;
        }
        public SeatedCarsRailwayСarriage(string model, int ownMass, int passengersCount, int bagageCount)
        {
            RailwayСarriageModel = model;
            RailwayСarriageType = RailwayСarriageTypes.SeatedCars;
            OwnMass = ownMass;
            PassengersCount = passengersCount;
            BagageCount = bagageCount;
        }
        
    }
}

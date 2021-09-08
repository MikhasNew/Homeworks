using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.RailwayСarriageClasse
{
    [Serializable]
    public class CompartmentRailwayСarriage: AbstractRailwayСarriage
    {
        public CompartmentRailwayСarriage()
        {
            RailwayСarriageType = RailwayСarriageTypes.Compartment;
            OwnMass = 1500;
            PassengersCount = 78;
            BagageCount = 350;
        }
        public CompartmentRailwayСarriage(string model, int ownMass, int passengersCount, int bagageCount)
        {
            RailwayСarriageModel = model;
            RailwayСarriageType = RailwayСarriageTypes.Compartment;
            OwnMass = ownMass;
            PassengersCount = passengersCount;
            BagageCount = bagageCount;
        }

    }
}

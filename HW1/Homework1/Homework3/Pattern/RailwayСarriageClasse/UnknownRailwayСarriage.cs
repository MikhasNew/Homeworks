using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.RailwayСarriageClasse
{
    [Serializable]
    public class UnknownRailwayСarriage : AbstractRailwayСarriage
    {
        public UnknownRailwayСarriage()
        {
            RailwayСarriageType = RailwayСarriageTypes.Unknown;
            OwnMass = 0;
            PassengersCount = 0;
            BagageCount = 0;
        }
        public UnknownRailwayСarriage(string model, int ownMass, int passengersCount, int bagageCount)
        {
            RailwayСarriageModel = "UnknownRailwayСarriage";
            RailwayСarriageType = RailwayСarriageTypes.Unknown;
            OwnMass = 0;
            PassengersCount = 0;
            BagageCount = 0;
        }

    }
}

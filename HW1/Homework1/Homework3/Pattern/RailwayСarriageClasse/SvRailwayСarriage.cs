using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.RailwayСarriageClasse
{
    [Serializable]
    public class SvRailwayСarriage: AbstractRailwayСarriage
    {
        public SvRailwayСarriage()
        {
            RailwayСarriageType = RailwayСarriageTypes.SV;
            OwnMass = 1500;
            PassengersCount = 54;
            BagageCount = 400;
        }
        public SvRailwayСarriage(string model, int ownMass, int passengersCount, int bagageCount)
        {
            RailwayСarriageModel = model;
            RailwayСarriageType = RailwayСarriageTypes.SV;
            OwnMass = ownMass;
            PassengersCount = passengersCount;
            BagageCount = bagageCount;
        }
       
    }
}

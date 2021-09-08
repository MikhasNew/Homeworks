using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.LocomotiveClasse
{
    [Serializable]
    public class DiselLocomotive : AbstractLocomotive
    {
        
        public DiselLocomotive()
        {
            LocamativeType = LocomotiveTypes.Diesel;
            OwnMass = 3500;
            MaxMass = 15800;
        }
        public DiselLocomotive(string model, int ownMass, int maxMass)
        {
            LocamativeModel = model;
            LocamativeType = LocomotiveTypes.Diesel;
            OwnMass = ownMass;
            MaxMass = maxMass;
        }
        public DiselLocomotive(string configSourse)
        {
            
        }

    }
}

using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.LocomotiveClasse
{
    public class ElectroLocomotive : AbstractLocomotive
    {
       public ElectroLocomotive()
        {
            LocamativeType = LocomotiveTypes.Electro;
            OwnMass = 2500;
            MaxMass = 17400;
        }
        
       public ElectroLocomotive(string model, int ownMass, int maxMass)
        {
            LocamativeModel = model;
            LocamativeType = LocomotiveTypes.Electro;
            OwnMass = ownMass;
            MaxMass = maxMass;
        }
        
    }
}

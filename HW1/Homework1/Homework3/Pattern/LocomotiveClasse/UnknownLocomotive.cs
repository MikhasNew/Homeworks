using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.LocomotiveClasse
{
    public class UnknownLocomotive : AbstractLocomotive
    {
       public UnknownLocomotive()
        {
            LocamativeType = LocomotiveTypes.Unknown;
            LocamativeModel = "UnknownLocomotive";
            OwnMass = 0;
            MaxMass = 0;
        }
       public UnknownLocomotive(string model, int ownMass, int maxMass)
        {
            LocamativeModel = "UnknownLocomotive";
            LocamativeType = LocomotiveTypes.Unknown;
            LocamativeModel = "UnknownLocomotive";
            OwnMass = 0;
            MaxMass = 0;
        }
        public UnknownLocomotive(string configSourse)
        {

        }
    }
}

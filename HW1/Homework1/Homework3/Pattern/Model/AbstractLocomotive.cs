using AbstractFactoryDepo.Pattern.LocomotiveClasse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AbstractFactoryDepo.Pattern.Model
{
    [XmlInclude(typeof(DiselLocomotive))]
    [XmlInclude(typeof(ElectroLocomotive))]
    [XmlInclude(typeof(UnknownLocomotive))]
    public abstract class AbstractLocomotive
    {
        public int ID { get; set; }
        /// <summary>
		/// model of locamative.
		/// </summary>
        public string LocamativeModel { get;  set; } = "Default";
        /// <summary>
		/// type of locamative.
		/// </summary>
        public  LocomotiveTypes LocamativeType { get;  set; }
        /// <summary>
		/// Own mass of locomative.
		/// </summary>
        public  int OwnMass { get;  set; }
        /// <summary>
		/// Maximale masse of train.
		/// </summary>
        public  int MaxMass { get;  set; }

        public string GetInfo()
        {
            return $"---ID of locomotive - {ID},\r\n " +
                $"Model of locomotive - {LocamativeModel},\r\n" +
                $"Type of locomotive - {LocamativeType},\r\n" +
                $"Own mass of locomative - {OwnMass },\r\n" +
                $"Max mass of locomative - {MaxMass },\r\n=" +
                $"\r\n";

                
        }

    }
}

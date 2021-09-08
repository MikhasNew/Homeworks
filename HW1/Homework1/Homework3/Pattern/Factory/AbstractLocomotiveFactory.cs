using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.Factory
{
	
	public abstract class AbstractLocomotiveFactory
	{
		public abstract AbstractLocomotive GreateLocomotive(LocomotiveTypes locomotiveType);
		public abstract AbstractLocomotive GreateLocomotive(LocomotiveTypes locomotiveType, bool xmlConfig);
	}
}
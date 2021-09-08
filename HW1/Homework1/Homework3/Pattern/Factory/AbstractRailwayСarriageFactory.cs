using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDepo.Pattern.Factory
{
	public abstract class AbstractRailwayСarriageFactory
	{
		public abstract AbstractRailwayСarriage GreateRailwayСarriage(RailwayСarriageTypes RailwayСarriageType);
		public abstract AbstractRailwayСarriage GreateRailwayСarriage(RailwayСarriageTypes RailwayСarriageType, bool xmlConfig);
	}
}

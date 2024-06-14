using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaECia.Services
{
	public class SpaceService
	{
		private static readonly Dictionary<string, double> PriceLists = new Dictionary<string, double>
		{
			{ "A", 10000 },
			{ "B", 10000 },
			{ "C", 10000 },
			{ "D", 10000 },
			{ "E", 17000 },
			{ "F", 17000 },
			{ "G", 8000 },
			{ "H", 35000 }
		};

		public static double SpacePrice(string name)
		{
			if (PriceLists.ContainsKey(name.ToUpper()))
			{
				return PriceLists[name.ToUpper()];
			}
			throw new ArgumentException("This space does not exist in our database");
		}
	}
}

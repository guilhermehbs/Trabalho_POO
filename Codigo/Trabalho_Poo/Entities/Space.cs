using System.Collections.Generic;

namespace Trabalho_POO.Entities
{
	public class Space
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
		public string Name { get; private set; }
		public int Capacity { get; private set; }
		public bool Available { get; set; }
		public double Price { get; private set; }

		public Space() { }

		public Space(string name, int capacity)
		{
			Name = name;
			Capacity = capacity;
			Available = true;
			Price = SpacePrice(name);
		}

		private double SpacePrice(string name)
		{
			if (PriceLists.ContainsKey(name.ToUpper())) 
			{
				return PriceLists[name.ToUpper()];
			}
			throw new ArgumentException("This space does not exist in our database");
		}
	}
}

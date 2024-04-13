using System.Collections.Generic;

namespace Trabalho_POO.Entities
{
	public class Space
	{
		public string Name { get; private set; }
		public int Capacity { get; private set; }
		public bool Available { get; set; }

		public double Price { get; private set; }

		private Dictionary<string, double> PriceLists = new Dictionary<string, double> { { "a", 10000 }, { "b", 10000 }, { "c", 10000 }, { "d", 10000 }, { "e", 17000 }, { "f", 17000 }, { "g", 8000 }, { "h", 35000 } };

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
			if (PriceLists.ContainsKey(name.ToLower())) {
				return PriceLists[name.ToLower()];
			}
			throw new ArgumentException("This space does not exist in our database");
		}
	}
}

namespace Trabalho_POO.Entities
{
	public class Drink
	{
		public string Name { get; private set; }
        public double Price { get; private set; }

		public Drink()
		{
		}

		public Drink(string name, double price)
		{
			Name = name;
			Price = price;
		}
	}
}

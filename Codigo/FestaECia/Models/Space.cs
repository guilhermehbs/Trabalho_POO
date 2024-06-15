namespace FestaECia.Models
{
	public class Space
	{
		public int Id { get; }
		public string Name { get; private set; }
		public int Capacity { get; private set; }
		public List<DateTime> DatasMarcadas;

		public Space(int id, string name, int capacity, List<DateTime> datasMarcadas)
		{
			Id = id;
			Name = name;
			Capacity = capacity;
			DatasMarcadas = datasMarcadas;
		}

		public void MarcarData(DateTime date)
		{
			DatasMarcadas.Add(date);
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, Capacity: {Capacity}, Quantidade de datas marcadas: {DatasMarcadas.Count}";
		}
	}
}

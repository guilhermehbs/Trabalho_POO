namespace FestaECia.Models
{
	public class Space
	{
		public int Id { get; }
		public char Name { get; private set; }
		public int Capacity { get; private set; }

        public Calendary SpaceCalendary;


    }
}

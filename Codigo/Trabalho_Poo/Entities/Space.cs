namespace Trabalho_POO.Entities
{
	public class Space
	{
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public bool Available { get; set; }

        public Space() { }

        public Space(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Available = true;
        }
    }
}

using Trabalho_POO.Entities;

namespace Trabalho_POO
{
	class Program
	{
		static void Main(string[] args)
		{
			NoivaECia noivaECia = new NoivaECia();

			Wedding wedding = new Wedding();

			noivaECia.ScheduleWedding(100, "luxo");
			//noivaECia.CancelWedding(wedding);
		}
	}
}

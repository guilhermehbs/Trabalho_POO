using Trabalho_POO.Entities;

namespace NoivaECiaTests
{
	[TestClass]
	public class NoivaECiaTests
	{
		[TestMethod]
		public void TestCasamentoAgendado()
		{
			NoivaECia noivaECia = new NoivaECia();
			Casamento casamento = noivaECia.AgendarCasamento(100);

			Assert.IsNotNull(casamento);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestCasamentoNaoAgendado()
		{
			NoivaECia noivaECia = new NoivaECia();
			noivaECia.AgendarCasamento(1000);
		}

		[TestMethod]
		public void TestProximaDataDisponivel()
		{
			NoivaECia noivaECia = new NoivaECia();
			DateTime data = noivaECia.ProximaDataDisponivel();

			Assert.AreNotEqual(DateTime.MinValue, data);
		}

		[TestMethod]
		public void TestExisteTamanhoDeEspaco()
		{
			NoivaECia noivaECia = new NoivaECia();
			Espaco espaco = noivaECia.MelhorEspacoParaCasamento(100);

			Assert.IsNotNull(espaco);
		}

		[TestMethod]
		public void TestNaoExisteTamanhoDeEspaco()
		{
			NoivaECia noivaECia = new NoivaECia();
			Espaco espaco = noivaECia.MelhorEspacoParaCasamento(700);

			Assert.IsNull(espaco);
		}
	}
}
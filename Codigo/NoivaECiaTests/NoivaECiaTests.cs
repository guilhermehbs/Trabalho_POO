using Trabalho_POO.Entities;

namespace NoivaECiaTests
{
	[TestClass]
	public class NoivaECiaTests
	{
		[TestMethod]
		public void TestMarriageScheduled()
		{
			NoivaECia noivaECia = new NoivaECia();
			Wedding wedding = noivaECia.ScheduleWedding(100);

			Assert.IsNotNull(wedding);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestUnscheduledWedding()
		{
			NoivaECia noivaECia = new NoivaECia();
			noivaECia.ScheduleWedding(1000);
		}

		[TestMethod]
		public void TestNextDateAvailabe()
		{
			NoivaECia noivaECia = new NoivaECia();
			DateTime date = noivaECia.NextDateAvailabe();

			Assert.AreNotEqual(DateTime.MinValue, date);
		}

		[TestMethod]
		public void TestExistsSpaceSize()
		{
			NoivaECia noivaECia = new NoivaECia();
			Space space = noivaECia.BestWeddingSpace(100);

			Assert.IsNotNull(space);
		}

		[TestMethod]
		public void TestNoExistSpaceSize()
		{
			NoivaECia noivaECia = new NoivaECia();
			Space space = noivaECia.BestWeddingSpace(700);

			Assert.IsNull(space);
		}
	}
}
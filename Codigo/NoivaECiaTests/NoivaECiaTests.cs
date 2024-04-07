using Trabalho_POO.Entities;

namespace NoivaECiaTests
{
	[TestClass]
	public class NoivaECiaTests
	{
		[TestMethod]
		public void TestScheduledWedding()
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
			DateTime date = noivaECia.NextDateAvailable();

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

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestNotExistsSpace()
		{
			NoivaECia noivaECia = new NoivaECia();

			noivaECia.ScheduleWedding(50);
			noivaECia.ScheduleWedding(50);
			noivaECia.ScheduleWedding(50);
			noivaECia.ScheduleWedding(50);
			noivaECia.ScheduleWedding(50);
			noivaECia.ScheduleWedding(50);
			noivaECia.ScheduleWedding(50);
			noivaECia.ScheduleWedding(50);
			noivaECia.ScheduleWedding(50);
		}

		[TestMethod]
		public void TestCancelWedding()
		{
			NoivaECia noivaECia = new NoivaECia();

			Wedding wedding = noivaECia.ScheduleWedding(50);

			noivaECia.CancelWedding(wedding);

			Assert.AreEqual(0, noivaECia.ListScheduledWeddings.Count());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestCancelWeddingNull()
		{
			NoivaECia noivaECia = new NoivaECia();

			Wedding wedding = null;

			noivaECia.CancelWedding(wedding);

			Assert.AreEqual(0, noivaECia.ListScheduledWeddings.Count());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void TestCancelWeddingWasNotScheduled()
		{
			NoivaECia noivaECia = new NoivaECia();

			Wedding wedding = new Wedding();

			noivaECia.CancelWedding(wedding);

			Assert.AreEqual(0, noivaECia.ListScheduledWeddings.Count());
		}
	}
}
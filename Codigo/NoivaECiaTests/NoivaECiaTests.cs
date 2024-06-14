using Trabalho_POO.Entities;

namespace NoivaECiaTests
{
	[TestClass]
	public class NoivaECiaTests
	{
		[TestMethod]
		public void TestScheduledWedding()
		{
			FestaECia noivaECia = new FestaECia();
			Wedding wedding = noivaECia.ScheduleWedding(100,"standard");

			Assert.IsNotNull(wedding);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestUnscheduledWedding()
		{
			FestaECia noivaECia = new FestaECia();
			noivaECia.ScheduleWedding(1000, "standard");
		}

		[TestMethod]
		public void TestNextDateAvailabe()
		{
			FestaECia noivaECia = new FestaECia();
			DateTime date = noivaECia.NextDateAvailable();

			Assert.AreNotEqual(DateTime.MinValue, date);
		}

		[TestMethod]
		public void TestExistsSpaceSize()
		{
			FestaECia noivaECia = new FestaECia();
			Space space = noivaECia.BestWeddingSpace(100);

			Assert.IsNotNull(space);
		}

		[TestMethod]
		public void TestNoExistSpaceSize()
		{
			FestaECia noivaECia = new FestaECia();
			Space space = noivaECia.BestWeddingSpace(700);

			Assert.IsNull(space);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestNotExistsSpace()
		{
			FestaECia noivaECia = new FestaECia();

			noivaECia.ScheduleWedding(50, "standard");
			noivaECia.ScheduleWedding(50, "standard");
			noivaECia.ScheduleWedding(50, "standard");
			noivaECia.ScheduleWedding(50, "standard");
			noivaECia.ScheduleWedding(50, "standard");
			noivaECia.ScheduleWedding(50, "standard");
			noivaECia.ScheduleWedding(50, "standard");
			noivaECia.ScheduleWedding(50, "standard");
			noivaECia.ScheduleWedding(50, "standard");
		}

		[TestMethod]
		public void TestCancelWedding()
		{
			FestaECia noivaECia = new FestaECia();

			Wedding wedding = noivaECia.ScheduleWedding(50, "standard");

			noivaECia.CancelWedding(wedding);

			Assert.AreEqual(0, noivaECia.ListScheduledWeddings.Count());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestCancelWeddingNull()
		{
			FestaECia noivaECia = new FestaECia();

			Wedding wedding = null;

			noivaECia.CancelWedding(wedding);

			Assert.AreEqual(0, noivaECia.ListScheduledWeddings.Count());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void TestCancelWeddingWasNotScheduled()
		{
			FestaECia noivaECia = new FestaECia();

			Wedding wedding = new Wedding();

			noivaECia.CancelWedding(wedding);

			Assert.AreEqual(0, noivaECia.ListScheduledWeddings.Count());
		}

	}
}
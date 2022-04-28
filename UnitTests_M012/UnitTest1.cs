using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UnitTests_M012
{
	[TestClass]
	public class UnitTest1
	{
		Rechner rechner;

		[TestInitialize] //Wird vor ALLEN Tests aufgerufen
		public void ErzeugeRechner()
		{
			if (rechner == null)
				rechner = new Rechner();
		}

		[TestCleanup] //Wird nach ALLEN Tests aufgerufen
		public void Cleanup()
		{
			rechner = null;
		}

		[TestCategory("Erfolg")] //Kategorien im Test Explorer bei Traits
		[TestMethod] //Erfolgstest
		public void TesteAddiere()
		{
			int sum = rechner.Addiere(10, 5);
			Assert.AreEqual(15, sum);
		}

		[TestCategory("Fehler")]
		[TestMethod] //Fehlertest
		public void TesteAddiereFehler()
		{
			int sum = rechner.Addiere(10, 5);
			Assert.AreNotEqual(7, sum);
		}
	}
}
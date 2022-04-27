namespace M009
{
	internal class Abstract
	{
		public abstract class LebewesenAbstract //Struktur für erbende Klassen, kein Objekt erstellbar
		{
			public string Name { get; set; }

			public LebewesenAbstract(string name)
			{
				Name = name;
			}

			public abstract void PrintStatus(); //Abstrakte Methode ohne body, muss überschrieben werden
		}

		public class Mensch2 : LebewesenAbstract
		{
			public Mensch2(string name) : base(name)
			{

			}

			public override void PrintStatus()
			{
				//...
			}
		}
	}
}

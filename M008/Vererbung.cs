public class Vererbung
{
	public class Lebewesen
	{
		public string Name { get; set; }

		public Lebewesen(string name)
		{
			Name = name;
		}

		public virtual void WasBinIch() //Kann überschrieben werden, muss aber nicht
		{
			Console.WriteLine("Ich bin ein Lebewesen");
		}

		public void PrintName()
		{
			Console.WriteLine(Name);
		}
	}

	public class Mensch : Lebewesen //Mensch ist Lebewesen
	{
		//Felder von oben (Name) werden übernommen

		public int Alter { get; set; }

		public Mensch(string name, int alter) : base(name) //base: ruft überliegenden Konstruktor auf
		{
			Alter = alter;
		}

		//Methode überschreiben mit override
		//sealed: Überschreibung verhindern (nach unten)
		public sealed override void WasBinIch()
		{
			Console.WriteLine("Ich bin ein Mensch");
		}

		public new void PrintName() //Methode von oben verstecken
		{
			Console.WriteLine(Name + Alter);
		}
	}

	public sealed class Kind : Mensch //Vererbung nach unten verhindern (sealed)
	{
		//Felder von oben: Name, Alter

		public int Groesse { get; set; }

		public Kind(string name, int alter, int groesse) : base(name, alter)
		{
			Groesse = groesse;
		}

		//public override void WasBinIch() //nicht möglich da sealed
		//{
		//	base.WasBinIch();
		//}
	}
}
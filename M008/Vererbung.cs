public class Vererbung
{
	/// <summary>
	/// Die Basisklasse für Lebewesen
	/// </summary>
	public class Lebewesen
	{
		/// <summary>
		/// Der Name des Lebewesens
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Der Basiskonstruktor von Lebewesen
		/// </summary>
		/// <param name="name">Der Name des Lebewesens</param>
		public Lebewesen(string name)
		{
			Name = name;
		}

		/// <summary>
		/// Gibt den Typen als String aus
		/// </summary>
		public virtual void WasBinIch() //Kann überschrieben werden, muss aber nicht
		{
			Console.WriteLine("Ich bin ein Lebewesen");
		}

		/// <summary>
		/// Gibt den Namen auf die Konsole aus
		/// </summary>
		/// <returns>Gibt 0 zurück</returns>
		public int PrintName()
		{
			Console.WriteLine(Name);
			return 0;
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
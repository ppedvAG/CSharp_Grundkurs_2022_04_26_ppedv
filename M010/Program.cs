public class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine(ITeilzeitArbeit.Wochenstunden);

		Mensch m = new Mensch();
		((IArbeit) m).Lohnauszahlung(); //Cast zum bestimmten Interface
		(m as ITeilzeitArbeit).Lohnauszahlung(); //as-Cast: funktioniert nur wenn Typ null sein kann

		IArbeit a = new Mensch(); //Variable vom Interfacetyp
		int wochenlohn = a.Gehalt / 160 * IArbeit.Wochenstunden; //Statische Variable
		//a.Methode();
	}
}

public interface IArbeit //Interfaces mit I anfangen wegen Konvention
{
	static int Wochenstunden => 40;

	int Gehalt { get; set; }

	string Job { get; set; }

	void Lohnauszahlung(); //Methode ohne body wie bei abstrakter Klasse

	public void Methode()
	{
		//Bad Practice
	}
}

public interface ITeilzeitArbeit : IArbeit
{
	static new int Wochenstunden => 20; //Wochenstunden mit new überschreiben

	new void Lohnauszahlung();
}

public abstract class Lebewesen { }

public class Mensch : Lebewesen, IArbeit, ITeilzeitArbeit, IDisposable, ICloneable //Alles aus dem Interface implementieren, Klasse muss vor Interfaces kommen
{
	public int Gehalt { get; set; } = 2000;

	public string Job { get; set; } = "Softwareentwickler";

	void IArbeit.Lohnauszahlung() //Speziell Interface angeben
	{
		Console.WriteLine($"Dieser Mensch hat ein Gehalt von {Gehalt} für den Job {Job} bekommen");
	}

	void ITeilzeitArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mensch hat ein Gehalt von {Gehalt / 2} für den Job {Job} bekommen");
	}

	public void Dispose()
	{
		//z.B. Datenbankverbindungen schließen
	}

	public object Clone() => new Mensch { Gehalt = Gehalt, Job = Job };
}
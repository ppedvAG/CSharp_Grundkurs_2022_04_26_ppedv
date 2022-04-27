using static M009.Abstract;
using static Vererbung;

public class Program
{
	static void Main(string[] args)
	{
		//Variablentyp: Lebewesen, Laufzeittyp: Mensch
		//Mensch an Lebewesen Variable zuweisen
		Lebewesen lw = new Mensch("Max", 23);
		Console.WriteLine(lw.GetType().Name); //Mensch
		Console.WriteLine(typeof(Mensch).Name);

		#region Laufzeittypvergleich
		if (lw.GetType() == typeof(Mensch)) //true
		{
			Console.WriteLine("lw ist Mensch");
		}

		if (lw.GetType() == typeof(Lebewesen)) //false, weil Vergleich mit Objekt selbst und nicht Variablentyp
		{
			Console.WriteLine("lw ist Lebewesen");
		}
		#endregion

		#region Variablentypvergleich
		if (lw is Mensch)
		{
			//true
		}

		if (lw is Lebewesen)
		{
			//true
		}
		#endregion

		#region WasBinIch Override
		//Mensch mensch = new Mensch("Herbert", 33);
		//mensch.WasBinIch(); //Ich bin ein Mensch

		//Lebewesen lebewesen = mensch;
		//lebewesen.WasBinIch(); //Ich bin ein Mensch (durch override weitergegeben)
		#endregion

		#region WasBinIch new
		Mensch mensch = new Mensch("Herbert", 33);
		mensch.WasBinIch(); //Ich bin ein Mensch

		Lebewesen lebewesen = mensch;
		lebewesen.WasBinIch(); //Ich bin ein Lebewesen (durch new wird Verbindung getrennt)
		#endregion


		//LebewesenAbstract la = new LebewesenAbstract(); //nicht möglich da abstract

		List<Lebewesen> list = new List<Lebewesen>(); //Liste von Lebewesen
		list.Add(new Mensch("", 1)); //Klassen die von Lebewesen erben können hinzugefügt werden
		list.Add(new Kind("", 0, 0));

		foreach (Lebewesen l in list)
		{
			l.WasBinIch(); //Hier entsprechende Methode in der Unterklasse ausführen
		}
	}
}
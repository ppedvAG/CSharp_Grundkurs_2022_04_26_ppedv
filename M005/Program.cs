public class Program
{
	//Main: Einstiegspunkt, jedes Programm brauch eine Main-Methode
	//svm + Tab + Tab: Main-Methode generieren
	static void Main(string[] args)
	{
		double x = Addiere(5d, 10); //Aufruf

		Summe(1, 2, 3, 4);
		Summe(8, 523, 524, 5624, 6, 5423, 6, 2346, 423, 6);
		Summe(1, 2); //Bei keinen params: Array mit 0 Stellen

		Subtrahiere(10, 5); //Hier 2 Standardwerte
		Subtrahiere(10, 3, 2); //Hier 1 Standardwert

		//out: veraltet
		int sub = 0; //Hier Variable anlegen
		int add = AddiereUndSubtrahiere(10, 5, out sub); //Hier Ergebnis Addition als return Wert, Ergebnis Subtraktion über out

		AddiereUndSubtrahiere(10, 5, out int ergebnis); //Hier Variable in der Methode anlegen
		Console.WriteLine(ergebnis);

		string input = "123";
		if (int.TryParse(input, out int parsed)) //TryParse mit out Variable im Methodenaufruf direkt
		{
			Console.WriteLine(parsed);
		}
		else
		{
			Console.WriteLine("Parsen hat nicht funktioniert");
		}

		(int, int) tuple = AddiereSubtrahiere(10, 5); //Tuple zuweisen
		Console.WriteLine(tuple.Item1); //Tuple angreifen mit Item1 und Item2
		Console.WriteLine(tuple.Item2);
	}

	static int Addiere(int z1, int z2) //Rückgabetyp Name(Parameter name1, Parameter name2, ...)
	{
		return z1 + z2;
	}

	static double Addiere(double z1, double z2) //Bei zwei Methoden mit gleichem Namen müssen sich die Parameter unterscheiden (Typen)
	{
		return z1 + z2;
	}

	//params: beliebig viele Parameter
	//muss ein int[] sein
	//muss immer das letzte Argument sein
	static int Summe(int z1, int z2, params int[] zahlen)
	{
		return z1 + z2 + zahlen.Sum();
	}

	//Optionaler Parameter: angegebener Wert wird verwendet wenn kein Wert übergeben
	//müssen immer letzte Parameter sein
	static int Subtrahiere(int z1, int z2, int z3 = 5, int z4 = 10)
	{
		return z1 - z2 - z3 - z4;
	}

	static int AddiereUndSubtrahiere(int z1, int z2, out int subtraktion)
	{
		subtraktion = z1 - z2;
		return z1 + z2;
	}

	static (int add, int sub) AddiereSubtrahiere(int z1, int z2) //Tuple: mehrere return-Werte statt out
	{
		return (z1 + z2, z1 - z2);
	}
}
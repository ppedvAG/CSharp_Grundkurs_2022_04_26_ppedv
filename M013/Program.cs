public class Program 
{
	public delegate void Vorstellungen(string name); //Anlegen des Delegates

	static void Main3(string[] args)
	{
		Vorstellungen vorstellungen = new Vorstellungen(VorstellungDE); //Erstellen einer Variable vom entsprechenden Typ
		vorstellungen += VorstellungEN; //Weitere Methode dranhängen
		vorstellungen -= VorstellungEN; //Methode abnehmen
		vorstellungen -= VorstellungEN; //Wenn Methode nicht dran, dann keine Exception o.Ä.
		//vorstellungen += (str) => { };

		vorstellungen("Max"); //Aufruf
		vorstellungen?.Invoke("Max"); //? vor Punkt: null check

		foreach (Delegate dg in vorstellungen.GetInvocationList()) //Alle Methoden anschauen
		{
			Console.WriteLine(dg.Method.Name); //Methodenname printen
		}

		vorstellungen = null; //Delegate clearen
	}

	public static void VorstellungDE(string name)
	{
		Console.WriteLine($"Hallo mein Name ist {name}");
	}

	public static void VorstellungEN(string name)
	{
		Console.WriteLine($"Hello my name is {name}");
	}
}
namespace M007;

public class Program
{
	static void Main(string[] args)
	{
		for (int i = 0; i < 1000; i++)
		{
			Person p = new Person();
			Person.ZaehlePerson(); //statische Methode mit Person.
		}

		Console.WriteLine(Person.Zaehler); //statische Variable

		GC.Collect(); //Hier GC erzwingen
		GC.WaitForPendingFinalizers(); //Hier auf Destruktoren warten

		Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")); //ToString(format) um DateTime zu formatieren

		//Wertetyp
		int original = 5;
		int x = original;
		original = 10; //x bleibt 5

		//Referenztyp
		Person person = new Person();
		Person p2 = person;
		person.Name = "Max"; //Name von p2 wird auf verändert


		int anzahl = 0;
		Addiere(10, 5, ref anzahl); //anzahl Variable übergeben
		Addiere(10, 5, ref anzahl);
		Addiere(10, 5, ref anzahl);
	}

	public static void Addiere(int z1, int z2, ref int anz) //Referenz zu Variable herstellen
	{
		Console.WriteLine(z1 + z2);
		anz++; //Anzahl Variable ansprechen und Wert rausgeben
	}
}
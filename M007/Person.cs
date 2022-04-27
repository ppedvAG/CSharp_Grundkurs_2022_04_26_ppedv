namespace M007
{
	internal class Person
	{
		public string Name { get; set; }

		public Person()
		{
			ZaehlePerson(); //statische Methoden im Objekt aufrufen
		}

		~Person() //Destruktor: wird aufgerufen wenn der Garbage Collector das Objekt einsammelt
		{
			Console.WriteLine("Person eingesammelt");
		}


		public static int Zaehler = 0; //Hängt an der Klasse und nicht am Objekt

		public static void ZaehlePerson()
		{
			Zaehler++;
		}
	}
}

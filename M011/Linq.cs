namespace M011
{
	public class Linq
	{
		static void Main(string[] args)
		{
			//Erstellt eine Liste voller ints von Start mit einer bestimmten Anzahl Elemente
			//(5, 20) -> gibt eine Liste mit 5-24 zurück
			List<int> linqTest = Enumerable.Range(1, 20).ToList();

			linqTest.Average();
			linqTest.Min();
			linqTest.Max();

			linqTest.Sum();

			linqTest.First(); //Erstes Element, Exception wenn Liste leer
			linqTest.FirstOrDefault(); //Erstes Element, null wenn Liste leer

			linqTest.Last();
			linqTest.LastOrDefault();

			//e => e == 5
			//linqTest.Single(); //Einziges Element, Exception wenn nicht genau ein Element
			//linqTest.SingleOrDefault(); //Einziges Element, null wenn keine Elemente, Exception wenn mehr als ein Element

			List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
			{
				new Fahrzeug(251, FahrzeugMarke.BMW),
				new Fahrzeug(274, FahrzeugMarke.BMW),
				new Fahrzeug(146, FahrzeugMarke.BMW),
				new Fahrzeug(208, FahrzeugMarke.Audi),
				new Fahrzeug(189, FahrzeugMarke.Audi),
				new Fahrzeug(133, FahrzeugMarke.VW),
				new Fahrzeug(253, FahrzeugMarke.VW),
				new Fahrzeug(304, FahrzeugMarke.BMW),
				new Fahrzeug(151, FahrzeugMarke.VW),
				new Fahrzeug(250, FahrzeugMarke.VW),
				new Fahrzeug(217, FahrzeugMarke.Audi),
				new Fahrzeug(125, FahrzeugMarke.Audi)
			};

			#region Vergleich Schreibweisen
			//Alle BMWs zurückgeben
			List<Fahrzeug> bmwsForEach = new List<Fahrzeug>();
			foreach (Fahrzeug fzg in fahrzeuge)
				if (fzg.Marke == FahrzeugMarke.BMW)
					bmwsForEach.Add(fzg);

			//Standard-Linq: SQL-ähnliche Schreibweise (alt)
			List<Fahrzeug> bmws = (from fzg in fahrzeuge
								   where fzg.Marke == FahrzeugMarke.BMW
								   select fzg).ToList();

			//Methodenkette
			List<Fahrzeug> bmwsNeu = fahrzeuge.Where(fzg => fzg.Marke == FahrzeugMarke.BMW).ToList();
			#endregion

			#region Einfaches Linq
			//Höchstgeschwindigkeit aller Autos
			fahrzeuge.Max(fzg => fzg.MaxGeschwindigkeit);

			//Mit OrderBy & Descending
			fahrzeuge.OrderBy(fzg => fzg.MaxGeschwindigkeit).Last();
			fahrzeuge.OrderByDescending(fzg => fzg.MaxGeschwindigkeit).First();

			//Alle Fahrzeugmarken
			List<FahrzeugMarke> alleMarken = fahrzeuge.Select(fzg => fzg.Marke).ToList();

			//Marken einzigartig machen
			List<FahrzeugMarke> distinct = alleMarken.Distinct().ToList();

			//Summiere alle Geschwindigkeit
			int summeV = fahrzeuge.Sum(fzg => fzg.MaxGeschwindigkeit);

			//Alle VWs aufsummieren
			int summeVWs = fahrzeuge
				.Where(fzg => fzg.Marke == FahrzeugMarke.VW && fzg.MaxGeschwindigkeit >= 200)
				.Sum(fzg => fzg.MaxGeschwindigkeit);

			//Alle Fahrzeuge >= 150
			bool alle150 = fahrzeuge.All(fzg => fzg.MaxGeschwindigkeit >= 150);

			//Ein Fahrzeug >= 150
			bool ein150 = fahrzeuge.Any(fzg => fzg.MaxGeschwindigkeit >= 150);

			//Check ob ein Element existiert
			bool einElement = fahrzeuge.Any();

			//Liste in Teile aufteilen
			IEnumerable<Fahrzeug[]> x = fahrzeuge.Chunk(5);

			//fahrzeuge.Concat() -> Zwei Listen zusammenhängen
			//fahrzeuge.Append() und fahrzeuge.Prepend() -> Hängen ein Element vorne oder hinten dran
			//fahrzeuge = fahrzeuge.Prepend(null).ToList();
			#endregion

			#region Erweitertes Linq
			//Fahrzeuge nach Automarken gruppieren
			IEnumerable<IGrouping<FahrzeugMarke, Fahrzeug>> grouped = fahrzeuge.GroupBy(fzg => fzg.Marke);

			//Einzelne Gruppe holen (hier BMWs)
			IGrouping<FahrzeugMarke, Fahrzeug> bmwGroup = grouped.First(group => group.Key == FahrzeugMarke.BMW);

			//Fahrzeuge aus Gruppe holen
			List<Fahrzeug> bmwsAusGroup = bmwGroup.ToList();

			//Liste schnell ausgeben
			Console.WriteLine(fahrzeuge.Aggregate(string.Empty, (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxGeschwindigkeit} fahren\n"));

			//Group zu Dictionary konvertieren
			Dictionary<FahrzeugMarke, List<Fahrzeug>> groupDictionary = grouped.ToDictionary(group => group.Key, fzg => fzg.ToList());
			#endregion

			//Liste mischen
			linqTest.OrderBy(e => Random.Shared.Next());

			//Erweiterungsmethode
			List<int> shuffled = linqTest.Shuffle().ToList();
			Console.WriteLine(38752659.Quersumme());
		}
	}

	public class Fahrzeug
	{
		public int MaxGeschwindigkeit;

		public FahrzeugMarke Marke;

		public Fahrzeug(int v, FahrzeugMarke fm)
		{
			MaxGeschwindigkeit = v;
			Marke = fm;
		}
	}

	public enum FahrzeugMarke
	{
		BMW,
		Audi,
		VW
	}
}

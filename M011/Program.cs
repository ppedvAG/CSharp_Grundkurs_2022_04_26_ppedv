using System.Collections.ObjectModel;
using System.Collections.Specialized;

public class Program
{
	static void Main(string[] args)
	{
		List<string> staedte = new List<string>(); //Erstellung einer Liste mit generischem Typ, T wird nach unten weitergegeben
		staedte.Add("Hamburg");
		staedte.Add("Wien");
		staedte.Add("Berlin");
		staedte.Add("Köln");

		Console.WriteLine(staedte[1]); //Elemente angreifen wie bei einem Array

		Console.WriteLine(staedte.Count); //Count statt Length

		staedte[2] = "Dresden"; //Wie beim Array zugreifen mit []

		staedte.Remove("Wien"); //Wien entfernen und andere Elemente aufschieben

		foreach (string s in staedte) //Liste durchgehen
		{
			Console.WriteLine(s);
		}

		staedte.Sort();

		string found = staedte.Find(e => e.StartsWith('H')); //Find mit Funktion (Predicate)


		Stack<string> staedteStack = new Stack<string>();
		staedteStack.Push("Berlin");
		staedteStack.Push("Wien");
		staedteStack.Push("Köln");
		staedteStack.Push("Hamburg");

		Console.WriteLine(staedteStack.Peek()); //Hamburg

		Console.WriteLine(staedteStack.Pop()); //Hamburg genommen und entfernt


		Queue<string> staedteQueue = new Queue<string>();
		staedteQueue.Enqueue("Berlin");
		staedteQueue.Enqueue("Wien");
		staedteQueue.Enqueue("Köln");
		staedteQueue.Enqueue("Hamburg");

		Console.WriteLine(staedteQueue.Peek()); //Berlin

		Console.WriteLine(staedteQueue.Dequeue()); //Berlin genommen und entfernt


		Dictionary<string, int> einwohnerzahlen = new Dictionary<string, int>(); //Dictionary: Liste von Key-Value Paaren
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);

		if (einwohnerzahlen.ContainsKey("Wien"))
			Console.WriteLine(einwohnerzahlen["Wien"]); //Value vom entsprechenden Key

		Console.WriteLine(einwohnerzahlen.ContainsValue(2_000_000)); //Wien

		Console.WriteLine(einwohnerzahlen.Count); //3

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen)
		{
			Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner");
		}


		ObservableCollection<string> str = new ObservableCollection<string>();
		str.CollectionChanged += Str_CollectionChanged; //Event dranhängen
		str.Add("X"); //Event wird aufgerufen
		str.Add("Y");
		str.Add("Z");
	}

	private static void Str_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action) //Schauen was passiert ist
		{
			case NotifyCollectionChangedAction.Add:
				break;
			case NotifyCollectionChangedAction.Remove:
				break;
			case NotifyCollectionChangedAction.Replace:
				break;
			case NotifyCollectionChangedAction.Move:
				break;
			case NotifyCollectionChangedAction.Reset:
				break;
		}
	}
}
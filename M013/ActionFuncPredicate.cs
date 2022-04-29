namespace M013
{
	internal class ActionFuncPredicate
	{
		static void Main2(string[] args)
		{
			Action<int, int> action = Addiere; //Action mit Parametern und void als return Typ
			action += Subtrahiere; //Funktioniert wie delegate
			action += (x, y) => { };
			action(10, 5);
			action.Invoke(10, 5);

			Predicate<int> checkZero = CheckForZero; //Predicate mit genau einem Parameter und bool als return Typ
			checkZero += (x) => x == 0;
			checkZero(0);
			checkZero.Invoke(0);

			Func<int, int, long> func = Multipliziere; //Letzter Wert ist immer return Typ
			func += (x, y) => 
			{
				return x * y;
			}; //Anonyme Methode
			func += (x, y) => x * y;
			func(10, 5);
			func.Invoke(10, 5);

			List<string> staedteListe = new List<string>() { "Berlin", "Wien", "Paris", "Köln" };
			staedteListe.ForEach(e => e += "-");
			staedteListe.Find(stadt => stadt.StartsWith('B'));
		}

		private static long Multipliziere(int arg1, int arg2)
		{
			return arg1 * arg2;
		}

		private static bool CheckForZero(int obj)
		{
			return obj == 0;
		}

		private static void Addiere(int arg1, int arg2)
		{
			Console.WriteLine(arg1 + arg2);
		}

		private static void Subtrahiere(int arg1, int arg2)
		{
			Console.WriteLine(arg1 - arg2);
		}
	}
}

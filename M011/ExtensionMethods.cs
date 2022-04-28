namespace M011
{
	public static class ExtensionMethods //static Klasse
	{
		public static int Quersumme(this int x) //Hier mit this Methode an bestimmte Klasse dranhängen
		{
			return x.ToString().ToCharArray().Sum(e => (int) char.GetNumericValue(e));
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
		{
			return list.OrderBy(e => Random.Shared.Next());
		}
	}
}

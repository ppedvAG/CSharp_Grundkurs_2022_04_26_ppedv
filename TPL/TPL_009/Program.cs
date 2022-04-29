string[] words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");

Parallel.Invoke(GetLongestWord, GetMostCommonWords, //Alle 3 Tasks gleichzeitig starten
() =>
{
	GetCountForWord("sleep");
});
//Wait auf alle

Console.ReadKey();

void GetLongestWord()
{
	Console.WriteLine("Längstes Wort: ");
	Console.WriteLine(words.OrderByDescending(e => e.Length).First());
}

void GetCountForWord(string wort)
{
	Console.WriteLine("Anzahl sleep: ");
	Console.WriteLine(words.Count(e => e.Equals(wort, StringComparison.OrdinalIgnoreCase)));
}

void GetMostCommonWords()
{
	Console.WriteLine("Häufigste Wörter: ");
	Console.WriteLine
	(
		words
		.Where(e => e.Length >= 7)
		.GroupBy(e => e.ToLower())
		.ToDictionary(e => e.Key, e => e.Count())
		.OrderByDescending(e => e.Value)
		.Take(10)
		.Aggregate("", (agg, kv) => agg + $"{kv.Key}: {kv.Value}\n")
	);
}

string[] CreateWordArray(string uri)
{
	string s = new HttpClient().GetStringAsync(uri).Result;
	return s.Split(new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' }, StringSplitOptions.RemoveEmptyEntries);
}
using System.Diagnostics;
using System.Text;

public class Program
{
	static void Main2(string[] args)
	{
		//string: char Array [H][a][l][l][o] -> 5 Stellen, kann nicht dynamisch erweitert werden
		//new List -> 4 Stellen, 5. Element -> Stellen verdoppelt
		string aufbau = string.Empty;

		//+: Alter string kopiert und neuer string wird drangehängt

		Stopwatch sw = Stopwatch.StartNew();

		for (int i = 0; i < 10000; i++)
			aufbau += i;

		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);



		StringBuilder sb = new StringBuilder();

		Stopwatch sw2 = Stopwatch.StartNew();

		for (int i = 0; i < 1000000; i++)
			sb.Append(i);

		string output = sb.ToString();

		sw2.Stop();
		Console.WriteLine(sw2.ElapsedMilliseconds);
	}
}
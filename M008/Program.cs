using static Vererbung;

public class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("Max", 23);
		m.Name = "Test"; //Name wird übernommen
		m.WasBinIch();

		Lebewesen lw = new Mensch("Max", 23);
		lw.PrintName();
	}
}
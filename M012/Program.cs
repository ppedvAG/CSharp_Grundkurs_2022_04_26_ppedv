using M012;

public class Program
{
	[Test]
	static void Main(string[] args)
	{
		try
		{
			string eingabe = Console.ReadLine();
		}
		catch (IOException ex) //Fehlerhafter Input
		{
			Console.WriteLine(ex.Message);
		}
		catch (Exception e) //Alle anderen Exceptions
		{
			Console.WriteLine($"Anderer Fehler: {e.StackTrace}");
		}


		try //Wenn 2 Exception dann in Reihe abgearbeitet
		{
			//eingabe Variable hier nicht sichtbar
			int parse = int.Parse(Console.ReadLine());
			if (parse == 0)
				throw new TestException("Zahl darf nicht 0 sein"); //Exception erzeugen
		}
		catch (FormatException ex) //1. Exception
		{
			Console.WriteLine("Keine Zahl eingegeben");
			Console.WriteLine(ex.Message);
		}
		catch (OverflowException ex) //2.Exception
		{
			Console.WriteLine("Zahl zu groß oder zu klein");
			Console.WriteLine(ex.Message);
		}
		catch (TestException ex)
		{
			Console.WriteLine(ex.Message);
			ex.Test(); //Methode aus TestException aufrufen
		}
		catch (Exception ex)
		{
			Console.WriteLine("Allgemeine Exception");
			Console.WriteLine(ex.Message);

			if (ex is ArithmeticException) //Mehrere Exception Klassen (ArithmeticException, SystemException, ...)
			{
				//...
			}
		}
		finally //Wird immer ausgeführt, auch wenn keine Exception auftritt
		{
			Console.WriteLine("Finally Block ausgeführt");
		}
	}
}

public class TestException : Exception
{
	public TestException() { }

	public TestException(string message) : base(message) { }

	public void Test()
	{

	}
}
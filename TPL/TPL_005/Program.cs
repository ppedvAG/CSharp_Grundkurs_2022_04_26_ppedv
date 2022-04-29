Task t1 = null, t2 = null, t3 = null, t4 = null;

try
{
	t1 = new Task(Fehler1);
	t1.Start();

	t2 = new Task(Fehler2);
	t2.Start();

	t3 = new Task(Fehler3);
	t3.Start();

	t4 = new Task(Erfolg);
	t4.Start();

	Task.WaitAll(t1, t2, t3); //Auf Liste von Tasks warten
}
catch (AggregateException ex) //Exceptions aus Tasks sammeln
{
	foreach (Exception exception in ex.InnerExceptions) //InnerExceptions hält alle Exceptions die aufgetreten sind
	{
		Console.WriteLine(exception.Message);
	}
}

if (t1.IsCompleted) //Schaut ob Task fertig ist (ob erfolgreich oder nicht)
	Console.WriteLine();
if (t2.IsFaulted) //Wenn Exception aufgetreten ist
	Console.WriteLine();
if (t3.IsCanceled) //Wenn durch Cancellation Token gestoppt
	Console.WriteLine();
if (t4.IsCompletedSuccessfully) //Wenn Task ohne Exception geendet ist
	Console.WriteLine();


void Fehler1()
{
	Thread.Sleep(2000);
	throw new DivideByZeroException();
}

void Fehler2()
{
	Thread.Sleep(4000);
	throw new StackOverflowException();
}

void Fehler3()
{
	Thread.Sleep(6000);
	throw new OutOfMemoryException();
}

void Erfolg()
{
	Console.WriteLine("Erfolg");
}
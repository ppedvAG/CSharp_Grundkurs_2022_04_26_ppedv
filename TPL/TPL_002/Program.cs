CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token; //Token anlegen

Task t = new Task(Methode, token); //Hier Token als Parameter übergeben
t.Start();

Thread.Sleep(5000);
cts.Cancel(); //Token auffordern zu Canceln
cts.Dispose(); //Token abbauen

Console.ReadKey();

void Methode(object token)
{
	CancellationToken cancellationToken = (CancellationToken) token;
	while (true)
	{
		Thread.Sleep(50);
		Console.WriteLine("#");

		if (cancellationToken.IsCancellationRequested) //Checken ob Cancel() aufgerufen wurde
		{
			cancellationToken.ThrowIfCancellationRequested(); //OperationCanceledException werfen
		}
	}
}
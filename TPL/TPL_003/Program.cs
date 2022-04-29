//Task.Factory.StartNew und Task.Run haben genau den selben Code

//.NET 4.0
Task t = Task.Factory.StartNew(Methode); //Startet den Task automatisch

//.NET 4.5
Task t2 = Task.Run(Methode); //Startet den Task automatisch

Console.ReadLine();


void Methode()
{
	for (int i = 0; i < 1000; i++)
		Console.WriteLine(i);
}
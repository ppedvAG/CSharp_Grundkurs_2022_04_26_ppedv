Task t = new Task(MacheEtwasSeperat); //Task erstellen
t.Start(); //Task parallel starten
//t.Wait(); //Warte darauf das der Task fertig ist (de-Parallelisieren)

//Main Thread
for (int i = 0; i < 1000; i++) //Code hier läuft parallel
	Console.Write("*");

Console.ReadKey();


void MacheEtwasSeperat()
{
	for (int i = 0; i < 1000; i++)
		Console.Write("#");
}
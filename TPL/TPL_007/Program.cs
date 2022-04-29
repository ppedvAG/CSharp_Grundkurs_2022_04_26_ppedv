List<Task<int>> tasks = new List<Task<int>>(); //Task Liste

for (int i = 1; i < 10; i++)
{
	tasks.Add(new Task<int>(Square, i)); //Tasks zur Liste hinzufügen (2^i)
}

tasks.ForEach(task => task.Start()); //Alle Tasks starten

Task<int[]> taskResult = Task.WhenAll(tasks); //Alle Tasks "zusammensammeln"
taskResult.Wait();

int[] results = taskResult.Result; //Resultat von dem Result Task holen

Console.WriteLine();

int Square(object x) => (int) x * (int) x;
namespace M013
{
	public class Program2
	{
		static void Main(string[] args)
		{
			EventComponent ec =	new EventComponent();
			ec.Progress += (i) => Console.WriteLine(i);
			ec.ProcessCompleted += () => Console.WriteLine("Fertig");
			ec.StartProcess();
		}
	}

	internal class EventComponent
	{
		public event Action ProcessCompleted;
		public event Action<int> Progress;

		public void StartProcess()
		{
			for (int i = 0; i < 10; i++)
			{
				Progress(i);
			}
			ProcessCompleted?.Invoke();
		}
	}
}

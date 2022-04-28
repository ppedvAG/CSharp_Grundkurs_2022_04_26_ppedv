namespace M013
{
	internal class Events
	{
		static event EventHandler Event; //delegate Untertyp
		static event Action<int> IntEvent; //Event mit Action

		static void Main4(string[] args)
		{
			Event += Events_Event;
			Event(null, EventArgs.Empty);
			Event(null, new MyEventArgs() { Name = "Max", ID = 1 }); //EventArgs werden ins Event weitergegeben

			IntEvent += Events_IntEvent;
		}

		private static void Events_IntEvent(int obj)
		{
			Console.WriteLine(obj);
		}

		private static void Events_Event(object sender, EventArgs e)
		{
			if (e is MyEventArgs ev) //schnelle Möglichkeit zum Cast nach Typvergleich
			{
				Console.WriteLine(ev.ID);
				Console.WriteLine(ev.Name);
			}
		}
	}

	public class MyEventArgs : EventArgs
	{
		public string Name { get; set; }

		public int ID { get; set; }
	}
}

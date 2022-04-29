Person p = new Person(1, "Max");

Task t = new Task(Method, p); //Parameter übergeben wie bei Cancellation Token
t.Start();

Task<string> t2 = new Task<string>(MethodReturn, p); //Task mit return Typ als Generic
t2.Start();
string output = t2.Result; //Hier Resultat angreifen (läuft dann synchron)

Task<string> t3 = Task.Factory.StartNew(MethodReturn, p); //Task mit Parameter mit Factory

Task<string> t4 = Task.Run(() => MethodReturn(p)); //Task mit Parameter mit Run


void Method(object o)
{
	if (o is Person p)
	{
		Console.WriteLine($"{p.ID}: {p.Name}");
	}
}

string MethodReturn(object o)
{
	return o is Person p ? $"{p.ID}: {p.Name}" : "";
}

public record Person(int ID, string Name);
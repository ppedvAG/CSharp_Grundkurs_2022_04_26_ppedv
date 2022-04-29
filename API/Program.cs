public class Program
{
	static void Main(string[] args)
	{
		string str = APIInterface.Get(@"http://www.gutenberg.org/files/54700/54700-0.txt").Result;
	}
}
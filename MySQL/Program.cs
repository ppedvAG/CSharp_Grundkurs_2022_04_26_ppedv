using System.Data;

namespace MySQL
{
	internal class Program
	{
		static void Main(string[] args)
		{
			SQLDriver driver = new SQLDriver("server=localhost;port=3306;user=root;password=root;database=mysql");
			driver.OpenConnection();

			driver.ExecuteWithoutResult("CREATE TABLE test(id int, vorname varchar(20));");
			driver.ExecuteWithoutResult("INSERT INTO test VALUES (0, 'Max')");
			driver.ExecuteWithoutResult("INSERT INTO test VALUES (1, 'Peter')");
			driver.ExecuteWithoutResult("INSERT INTO test VALUES (2, 'Hans')");
			DataTable dt = driver.ExecuteWithResult("SELECT * FROM test");

			List<Person> p = new List<Person>();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				p.Add(new Person((int) dt.Rows[i].ItemArray[0], (string) dt.Rows[i].ItemArray[1]));
			}
		}
	}

	public record Person(int ID, string Vorname);
}

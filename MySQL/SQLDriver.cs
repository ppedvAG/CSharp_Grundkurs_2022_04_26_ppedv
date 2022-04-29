using MySql.Data.MySqlClient;
using System.Data;

public class SQLDriver
{
	private MySqlConnection CurrentConnection { get; set; }

	public bool IsConnected => CurrentConnection != null && CurrentConnection.State != ConnectionState.Closed && CurrentConnection.State != ConnectionState.Connecting;

	//server=localhost;port=3306;user=root;password=root;database=mysql
	public SQLDriver(string connectionString) => CurrentConnection = new MySqlConnection(connectionString);

	~SQLDriver() => CurrentConnection?.Dispose();

	//https://dev.mysql.com/doc/mysql-errors/8.0/en/server-error-reference.html
	public int OpenConnection()
	{
		if (IsConnected)
			return -1;

		try
		{
			CurrentConnection.Close(); //Closen wenn Verbindung out-of-sync (zwischen Server und Client)
			CurrentConnection.Open();
			return 0;
		}
		catch (MySqlException ex)
		{
			int errorCode = ex.Number == 0 ? (ex.InnerException as MySqlException).Number : ex.Number;
			switch (errorCode)
			{
				case 1042:
					Console.WriteLine("Verbindung kann nicht hergestellt werden"); //IP-Adresse oder Port falsch
					break;
				case 1045:
					Console.WriteLine("Falscher User/Passwort");
					break;
				case 1049:
					Console.WriteLine("Invalider Datenbankname");
					break;
				default:
					Console.WriteLine($"Anderer Code {errorCode}: https://dev.mysql.com/doc/mysql-errors/8.0/en/server-error-reference.html");
					break;
			}
			return errorCode;
		}
	}

	public void CloseConnection()
	{
		CurrentConnection.Close();
	}

	public bool TestConnection()
	{
		if (CurrentConnection?.Ping() == false)
		{
			CloseConnection();
			return false;
		}
		return true;
	}

	public int Reconnect() => TestConnection() ? 0 : OpenConnection();

	public int ExecuteWithoutResult(string sql)
	{
		if (Reconnect() != 0)
		{
			return -1; //Keine Verbindung möglich
		}

		using (MySqlCommand cmd = CurrentConnection.CreateCommand())
		{
			try
			{
				cmd.CommandText = sql;
				return cmd.ExecuteNonQuery();
			}
			catch (MySqlException ex) //Syntax Error meistens
			{
				return -1;
			}
		}
	}

	public DataTable ExecuteWithResult(string sql)
	{
		if (Reconnect() != 0)
		{
			return null; //Keine Verbindung möglich
		}

		using (MySqlCommand command = CurrentConnection.CreateCommand())
		{
			try
			{
				command.CommandText = sql;
				MySqlDataReader reader = command.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				return dt;
			}
			catch (MySqlException ex)
			{
				return null;
			}
		}
	}
}
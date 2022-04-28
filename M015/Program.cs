using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;
using static System.Environment;

public class Program
{
	static void Main(string[] args)
	{
		//Pfad vom Desktop (C:\Users\<User>\Desktop
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory);

		//Path für Pfadoperationen
		string folderPath = Path.Combine(desktop, "M015");

		if (!Directory.Exists(folderPath)) //Directory Klasse für alles zum Thema Ordner
			Directory.CreateDirectory(folderPath);

		//StreamWriterTest();
		//StreamReaderTest();

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Json
		JsonSerializerSettings serializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects }; //Typen in File zusätzlich speichern

		string json = JsonConvert.SerializeObject(fahrzeuge, Formatting.Indented, serializerSettings); //Objekt zu Json-String konvertieren
		string filePath = Path.Combine(folderPath, "Test.txt");
		File.WriteAllText(filePath, json); //Schnell Text schreiben

		string read = File.ReadAllText(filePath); //Schnell Json einlesen
		List<Fahrzeug> fzg = JsonConvert.DeserializeObject<List<Fahrzeug>>(read, serializerSettings); //Json-String zu Objekt über Generic
		#endregion

		#region XML
		XmlSerializer xml = new XmlSerializer(typeof(List<Fahrzeug>));
		Stream s = new FileStream(filePath, FileMode.Create);
		xml.Serialize(s, fahrzeuge);
		s.Dispose();

		Stream readStream = new FileStream(filePath, FileMode.Open);
		List<Fahrzeug> readFahrzeuge = xml.Deserialize(readStream) as List<Fahrzeug>;
		#endregion
	}

	public static void StreamWriterTest()
	{
		//Pfad vom Desktop (C:\Users\<User>\Desktop
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory);

		//Path für Pfadoperationen
		string folderPath = Path.Combine(desktop, "M015");

		if (!Directory.Exists(folderPath)) //Directory Klasse für alles zum Thema Ordner
			Directory.CreateDirectory(folderPath);

		StreamWriter streamWriter = new StreamWriter(Path.Combine(folderPath, "Test.txt"));
		streamWriter.WriteLine("Line"); //Text in den Buffer schreiben
		streamWriter.WriteLine("Test");
		streamWriter.Flush(); //Text auf die Festplatte schreiben
		streamWriter.Dispose(); //Entfernen

		using StreamWriter sw = new StreamWriter(Path.Combine(folderPath, "Test.txt")) { AutoFlush = true }; //Direkt nach jedem WriteLine schreiben
		sw.WriteLine("Line");
		sw.WriteLine("Test");
		//Hier wird automatisch disposed
	}

	public static void StreamReaderTest()
	{
		//Pfad vom Desktop (C:\Users\<User>\Desktop
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory);

		//Path für Pfadoperationen
		string folderPath = Path.Combine(desktop, "M015");

		if (!Directory.Exists(folderPath)) //Directory Klasse für alles zum Thema Ordner
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt");
		if (File.Exists(filePath)) //File Klasse für File Operationen
		{
			using StreamReader sr = new StreamReader(filePath);
			string[] lines = sr.ReadToEnd().Split(NewLine, StringSplitOptions.RemoveEmptyEntries); //File einlesen und zu string[] Konvertieren

			sr.BaseStream.Position = 0; //Reader auf File Anfang zurücksetzen

			List<string> list = new List<string>(); //Zeile für Zeile einlesen (große Files)
			string read = sr.ReadLine();
			list.Add(read);
			while (!sr.EndOfStream)
			{
				read = sr.ReadLine();
				list.Add(read);
			}
		}
	}
}

//Record: Model Klasse generiert Code darunter
//Wertetyp statt Referenztyp
//== und != vergleichen die Werte statt den HashCodes
public record Fahrzeug(int MaxGeschwindigkeit, FahrzeugMarke Marke);

//public class Fahrzeug
//{
//	public int MaxGeschwindigkeit;

//	public FahrzeugMarke Marke;

//	public Fahrzeug(int v, FahrzeugMarke fm)
//	{
//		MaxGeschwindigkeit = v;
//		Marke = fm;
//	}

//	public Fahrzeug() { }
//}

public enum FahrzeugMarke
{
	BMW,
	Audi,
	VW
}
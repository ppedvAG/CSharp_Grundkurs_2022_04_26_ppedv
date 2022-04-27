using M006.UnternamespaceAusserhalb;
using M006.UnternamespaceInnerhalb;
using System;
using System.IO;
using System.Linq;
using static System.Environment; //gibt statische Methoden aus der Klasse weiter

namespace M006
{
	public class Program
	{
		static void Main(string[] args)
		{
			UnterklasseAusserhalb ua;
			UnterklasseInnerhalb uia;

			Console.WriteLine(); //System
			Path.GetFullPath(""); //System.IO
			new[] { 1, 2, 3 }.Sum(); //System.Linq
			Exit(0); //aus Environment Klasse

			Member m = new Member(); //Objektinitialisierung mit new (Konstruktor ohne Parameter aufrufen)
			m.Name = "Max"; //set-Property wie Variable verwenden
			Console.WriteLine(m.Name); //get-Property wie Variable verwenden
			m.Test(); //Methodenaufruf
					  //m.Vorname = "Max"; //nicht möglich da private set
					  //m.Lieblingsfarbe = "Grün"; //nicht möglich da init
		}
	}

	namespace UnternamespaceInnerhalb
	{
		public class UnterklasseInnerhalb { }
	}
}

namespace M006.UnternamespaceAusserhalb
{
	public class UnterklasseAusserhalb { }
}
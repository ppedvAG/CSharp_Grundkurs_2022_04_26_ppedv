using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M006
{
	public class Member
	{
		private string name;

		public string Name //Property: private Variable im Hintergrund
		{
			get => name;
			set
			{
				if (!string.IsNullOrEmpty(value) && value.Length >= 2)
					name = value;
			}
		}


		public string Vorname { get; private set; } = "Max";


		private int gehalt;

		public int Gehalt => gehalt; //Get-only Property


		public string Lieblingsfarbe { get; init; } = "Blau"; //init: Nur hier oder im Konstruktor setzbar

		//ctor + Tab + Tab
		public Member()
		{
			Name = "Max";
			Vorname = "Max";
			gehalt = 2000;
			Lieblingsfarbe = "Rot";
		}

		public Member(string name, string vorname, int gehalt, string farbe)
		{
			Name = name;
			Vorname = vorname;
			this.gehalt = gehalt;
			Lieblingsfarbe = farbe;
		}

		public void Test() => Console.WriteLine("Ich bin ein Test");
	}
}

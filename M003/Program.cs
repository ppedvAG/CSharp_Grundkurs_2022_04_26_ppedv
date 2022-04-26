#region Arrays
int[] zahlen = new int[5]; //Array mit Länge 5 (0-4)
zahlen[1] = 5; //Stellen fangen bei 0 an (und enden bei 4)
Console.WriteLine(zahlen[1]);

int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Direkte Initialisierung

int[] zahlenDirektKurz = new[] { 1, 2, 3, 4, 5 }; //Kurzschreibweise

int[] zahlenDirektNochKuerzer = { 1, 2, 3, 4, 5 }; //Noch kürzer

Console.WriteLine(zahlenDirekt.Length); //Anzahl an Plätzen (5)

Console.WriteLine(zahlenDirekt.Sum()); //Liste aufsummieren

bool hatDrei = zahlen.Contains(3); //Schauen ob Element enthalten ist


/*	Array Darstellung:
 *	| 0, 0, 0 |
 *	| 0, 3, 0 |
 *	| 0, 0, 0 |
 */
int[,] zweiDArray = new int[3, 3];//Matrix (3x3), beliebig viele Dimensionen mit Beistrichen
zweiDArray[1, 1] = 3;

Console.WriteLine(zweiDArray[1, 1]);
Console.WriteLine(zweiDArray.Length); //Anzahl Felder (9)
Console.WriteLine(zweiDArray.Rank); //Anzahl Dimensionen (2)
Console.WriteLine(zweiDArray.GetLength(1)); //Gibt Länge einer Dimension zurück (3)

//Direkte Initialisierung
int[,] zweiDDirekt =
{
	{ 0, 0, 0 },
	{ 0, 3, 0 },
	{ 0, 0, 0 }
};
#endregion

#region Bedingungen
int zahl1 = 5;
int zahl2 = 7;

if (zahl1 == 5)
{

}
else
{

}

bool z1Groesserz2 = zahl1 > zahl2;

if (!z1Groesserz2)
{

}

if (zahl1 == 5 && zahl2 == 7)
{
	Console.WriteLine("Zahl1 ist 5 und Zahl2 ist 7");
}

//Fragezeichen Operator (?, :): ? ist if, : ist else, braucht immer ein else
Console.WriteLine(zahl1 == 5 && zahl2 == 7 ? "Zahl1 ist 5 und Zahl2 ist 7" : "");

string name = null;
string name2 = name ?? throw new NotImplementedException(); //Null-Coalescing Operator: mach links wenn nicht null, sonst rechts
#endregion
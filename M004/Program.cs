#region Schleifen
int a = 0;
int b = 10;
while (a < b)
{
	Console.WriteLine("while: " + a);
	if (a == 5)
		break; //springt aus der Schleife raus
	a++;
}

while (true) //Endlosschleife
{
	break;
}

int c = 0;
int d = 10;
do //läuft mindestens einmal
{
	c++;
	if (c == 5)
		continue; //continue springt zu Schleifenkopf zurück
	Console.WriteLine("do-while: " + c);
}
while (c < d);


for (int i = 0; i < 10; i++)
{
	if (i == 5)
		continue; //Iterator wird weiterhin erhöht
	Console.WriteLine("for: " + i);
}

for (int i = 9; i >= 0; i--) //Rückwärtsschleife
{

}

for (int i = 0; ; i++) //Endlosschleife mit Zähler
{
	break;
}

for(;;) { break; } //kürzeste Endlosschleife

//mehrere Zählervariablen und Iterierungen
//nicht zwingend ++ sondern *= z.B.
for (int i = 0, j = 0; ; i++, j *= 2)
{
	break;
}

int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
for (int i = 0; i < zahlen.Length; i++) //Array iterieren
{
	Console.WriteLine(zahlen[i]);
}

foreach (int i in zahlen) //Kann nicht daneben greifen
{
	Console.WriteLine(i);
}

string s = "Test";
foreach (char character in s) //string iterieren
{

}
#endregion

#region Enums
Wochentag wochentag = Wochentag.Dienstag; //Variable
Console.WriteLine(wochentag);

Wochentag intWochentag = (Wochentag) 3; //Enumwert über Cast erhalten

Wochentag stringWochentag = (Wochentag) Enum.Parse(typeof(Wochentag), Console.ReadLine());
Wochentag stringWochentagGeneric = Enum.Parse<Wochentag>(Console.ReadLine()); //string oder int zu Wochentag umwandeln
Console.WriteLine(stringWochentagGeneric);

switch (wochentag)
{
	case Wochentag.Montag:
		Console.WriteLine("Wochenanfang");
		break;
	case Wochentag.Dienstag:
	case Wochentag.Mittwoch:
	case Wochentag.Donnerstag:
		Console.WriteLine("Normaler Wochentag");
		break;
	case Wochentag.Freitag:
	case Wochentag.Samstag:
	case Wochentag.Sonntag:
		Console.WriteLine("Wochende");
		break;
	default:
		Console.WriteLine("Etwas ist schiefgelaufen");
		break;
}

switch (wochentag)
{
	case >= Wochentag.Montag and <= Wochentag.Freitag:
		Console.WriteLine("Wochentag");
		break;
	case Wochentag.Samstag or Wochentag.Sonntag:
		Console.WriteLine("Wochende");
		break;
}

Wochentag wochentage = Wochentag.Montag | Wochentag.Dienstag | Wochentag.Mittwoch; //0000111
if (wochentage.HasFlag(Wochentag.Montag))
	Console.WriteLine("Montag ist dabei");
#endregion

[Flags] //Binärflags, Enum Werte müssen Zweierpotenzen sein
public enum Wochentag //fixe Sammlung an Werten
{
	Montag = 1, //Werte anpassen, darunterliegende Werte werden aufgeschoben
	Dienstag = 2,
	Mittwoch = 4,
	Donnerstag = 8, //Hier auch aufschieben
	Freitag = 16,
	Samstag = 32,
	Sonntag = 64
}
#region Variablen
//Variable: <Typ> <Name>;
int zahl;
zahl = 5; //Wertzuweisung
Console.WriteLine(zahl); //cw + Tab + Tab

int zahl2 = 5; //Definition + Zuweisung
Console.WriteLine(zahl2);

int zahlMalZwei = zahl * 2; //Arithmetik
Console.WriteLine(zahlMalZwei);

/*
 Mehrzeilige
 Kommentare
 */

string stadt = "Berlin"; //Text
Console.WriteLine(stadt);

char zeichen = 'S'; //Einzelnes Zeichen
Console.WriteLine(zeichen);

double kommazahl = 5.39;
Console.WriteLine(kommazahl);

float kommaFloat = 5.39f; //Kommazahl mit f am Ende

decimal kommaDecimal = 20_957_234_905.44m; //m für Decimal, Decimal für Geldwerte, _ für Trennzeichen
#endregion

#region Stringoperationen
string kombination = "Ein string: " + kommazahl; //String verbinden

string interpolation = $"Mehrere Zahlen {zahl}, {zahl2}, {kommaDecimal}"; //$ Zeichen vor String um Code im String zu erlauben

Console.WriteLine("Alter von Max: {0}", zahl); //Indexschreibweise

//https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-escapes-in-regular-expressions
Console.WriteLine($"Alter von Max: \n{zahl}"); //Umbruch

Console.WriteLine($"Alter von Max: \t{zahl}"); //Tabulator

Console.WriteLine("C:\\Users\\..."); //Einzelner \ mit \\

Console.WriteLine(@"Verbatim
String	\ \n"); //Verbatim String: Alles nehmen wie es im Code steht

Console.WriteLine(@"C:\Users\..."); //Verbatim String besonders praktisch bei Pfaden
#endregion

#region Eingabe
Console.ReadKey(); //Einzelnen Key einlesen, blockiert Programm

ConsoleKeyInfo info = Console.ReadKey(); //Eingabe in Variable speichern
Console.WriteLine(info.Key); //Key holen
Console.WriteLine(info.KeyChar); //Zeichen holen

string input = Console.ReadLine(); //Mehrere Zeichen einlesen, weiter mit Enter

int intInput = int.Parse(input); //Parse um String in Zahl umzuwandeln

double doubleInput = double.Parse(input); //Parse String zu Dezimalzahl

bool boolInput = bool.Parse(input);
#endregion

//Strg + K, Strg + C: Alle markierten Zeilen auskommentieren
//Strg + K, Strg + U: Alle markierten Zeilen einkommentieren

#region Typecasting
string toStr = zahl.ToString(); //ToString() -> Konvertierung zum String

int ganzZahl = 25;
double implizit = ganzZahl; //Hier direkter Cast da Konvertierung immer ein Erfolg sein wird
int explizit = (int) implizit; //Expliziter Cast: Umwandlung erzwingen (weil Kommastellen)
#endregion

#region Mathematik
int zahlM1 = 5;
int zahlM2 = 7;

Math.Min(zahlM1, zahlM2);
Math.Max(zahlM1, zahlM2);

Math.Round(33.335, 2); //Runden auf 2 Stellen, 32.5 -> 32, rundet auf näheste gerade Zahl
Math.Floor(33.44); //Immer abrunden
Math.Ceiling(33.44); //Immer aufrunden

Math.Pow(5, 3); //Potenzieren: 5^3
Math.Sqrt(10); //Wurzel ziehen
#endregion
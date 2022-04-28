public class LabCode
{
	static void Main2(string[] args)
    {
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
    }
}

public class Fahrzeug
{
    public int MaxGeschwindigkeit;
    public FahrzeugMarke Marke;
    public List<Sitzplatz> Sitze;

    public Fahrzeug(int v, FahrzeugMarke fm)
    {
        MaxGeschwindigkeit = v;
        Marke = fm;
        Sitze = new List<Sitzplatz>();
        int sitze = v <= 150 ? 6 : v <= 250 ? 5 : 4;
        for (int i = 0; i < sitze; i++)
            Sitze.Add(new Sitzplatz());
        for (int i = 0; i < v % (sitze + 1); i++)
            Sitze[i].IstBesetzt = true;
    }
}

public class Sitzplatz
{
    public bool IstBesetzt;
}

public enum FahrzeugMarke
{
    BMW,
    Audi,
    VW
}
namespace M008
{
	internal class AccessModifier { }

	class Mensch //Klasse ohne Modifier ist Internal
	{
		public string Name { get; set; } //Kann überall gesehen werden (auch außerhalb vom Projekt)

		private int Groesse { get; set; } //Kann nur in Mensch gesehen werden

		internal string Wohnort { get; set; } //Kann überall gesehen werden aber nur im Projekt


		protected string Lieblingsfarbe { get; set; } //Kann nur in Mensch und Unterklassen gesehen werden (auch außerhalb vom Projekt)

		protected internal string Lieblingsnahrung { get; set; } //Kann im gesamten Projekt gesehen werden und in Unterklassen außerhalb

		protected private DateTime Geburtsdatum { get; set; } //Kann nur in Mensch und Unterklassen von Mensch gesehen werden (nur im Projekt)
	}
}

Task<string> t = Task.Run(() =>
{
	Thread.Sleep(3000);
	return "";
});
t.ContinueWith(t => Folgetask(t.Result)); //Weiteren Task starten bei einem Ergebnis, Ergebnis weitergeben
t.ContinueWith(t => Fehlertask(), TaskContinuationOptions.OnlyOnFaulted); //Nur weiteren Task starten bei Exception
t.ContinueWith(t => Erfolgstask(), TaskContinuationOptions.OnlyOnRanToCompletion); //Nur weiteren Task starten bei Erfolg

void Folgetask(string s)
{

}

void Fehlertask()
{

}

void Erfolgstask()
{

}
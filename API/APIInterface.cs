public class APIInterface
{
	private const string DefaultUrl = "https://api.example.com/";

	private static HttpClient Client = new HttpClient();

	public static async Task<string> Get(string uri, params string[] parameters)
	{
		HttpResponseMessage resp = await Client.GetAsync(CreateUri(uri, DefaultUrl, parameters));
		if (resp.IsSuccessStatusCode)
		{
			return await resp.Content.ReadAsStringAsync();
		}
		throw new HttpRequestException();
	}

	public static async Task<string> Post(string uri, HttpContent body = null)
	{
		//StringContent str = new StringContent("Text"); <- HttpContent
		HttpResponseMessage resp = await Client.PostAsync(uri, body);
		if (resp.IsSuccessStatusCode)
		{
			return await resp.Content.ReadAsStringAsync();
		}
		throw new HttpRequestException();
	}

	//https://api.com + /pfad/zur/api/schnittstelle + ?param1=123&param2=456&param3=abc
	private static Uri CreateUri(string apiUrl, string url = DefaultUrl, params string[] par)
	{
		string full = url + apiUrl + (par.Length != 0 ? "?" : "");
		string req = string.Join("&", par);
		return new Uri(full + req);
	}
}
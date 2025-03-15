using Newtonsoft.Json;
using RadioPlayer.Domain;
using RadioPlayer.Services.Abstracts;

namespace RadioPlayer.Services;

public class RadioService(HttpClient httpClient, IDnsService dnsService) : IRadioService
{
    public async Task<List<Country>> GetCountriesAsync()
    {
        var response = await httpClient.GetStringAsync($"https://{dnsService.ApiUrl}/json/countries");
        var countries = JsonConvert.DeserializeObject<List<Country>>(response);
        if (countries == null)
        {
            throw new Exception("Cannot obtain list of countries");
        }

        return countries.OrderBy(x => x.Name).ToList();
    }

    public async Task<List<RadioStation>> GetStationsByCountryAsync(string country)
    {
        var url = $"https://{dnsService.ApiUrl}/json/stations/bycountry/{country}";
        var response = await httpClient.GetStringAsync(url);
        var stations = JsonConvert.DeserializeObject<List<RadioStation>>(response);
        if (stations == null)
        {
            throw new Exception("Cannot obtain list of stations");
        }

        return stations;
    }

    public async Task<byte[]?> DownloadIconFromUrlAsync(string url)
    {
        if (string.IsNullOrEmpty(url)) return null;
        try
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            return await httpClient.GetByteArrayAsync(url, cts.Token);
        }
        catch (Exception e)
        {
            return null;
        }
    }

}
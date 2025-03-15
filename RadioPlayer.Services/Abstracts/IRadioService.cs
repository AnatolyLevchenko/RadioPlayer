using RadioPlayer.Domain;

namespace RadioPlayer.Services.Abstracts;

public interface IRadioService
{
    Task<List<Country>> GetCountriesAsync();
    Task<List<RadioStation>> GetStationsByCountryAsync(string country);

}
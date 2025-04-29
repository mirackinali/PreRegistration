using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class LokasyonApiController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private const string RestCountriesApiUrl = "https://restcountries.com/v3.1/all?fields=name,cca2";
    private const string GeoNamesApiBaseUrl = "http://api.geonames.org/searchJSON";
    private const string GeoNamesUsername = "DEMO"; // Gerçek bir API anahtarı almanız gerekir

    public LokasyonApiController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet("ulkeler")]
    public async Task<ActionResult<IEnumerable<object>>> GetUlkelerFromApi()
    {
        try
        {
            var response = await _httpClient.GetAsync(RestCountriesApiUrl);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var countriesData = JsonSerializer.Deserialize<List<CountryResponse>>(json);

            if (countriesData != null)
            {
                return Ok(countriesData.Select(c => new { id = c.cca2, tanım = c.name.common }));
            }

            return NotFound();
        }
        catch
        {
            return StatusCode(500, "Ülkeler alınırken bir hata oluştu.");
        }
    }

    [HttpGet("sehirler/{ulkeKodu}")]
    public async Task<ActionResult<IEnumerable<object>>> GetSehirlerFromApi(string ulkeKodu)
    {
        try
        {
            var apiUrl = $"{GeoNamesApiBaseUrl}?country={ulkeKodu}&featureClass=P&orderby=population&username={GeoNamesUsername}";
            var response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var citiesData = JsonSerializer.Deserialize<GeoNamesResponse>(json);

            if (citiesData?.geonames != null)
            {
                return Ok(citiesData.geonames.Select(c => new { id = c.geonameId, tanım = c.name }));
            }

            return NotFound();
        }
        catch
        {
            return StatusCode(500, "Şehirler alınırken bir hata oluştu.");
        }
    }
}

public class CountryResponse
{
    public NameResponse name { get; set; }
    public string cca2 { get; set; }
}

public class NameResponse
{
    public string common { get; set; }
}

public class GeoNamesResponse
{
    public List<CityInfo> geonames { get; set; }
}

public class CityInfo
{
    public int geonameId { get; set; }
    public string name { get; set; }
}
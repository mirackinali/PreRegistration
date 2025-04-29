using System.Collections.Generic;
using System.Linq;

namespace KullaniciGiris.Models
{
    public static class LokasyonStatikData
    {
        public static List<Ulke> Ulkeler = new List<Ulke>
        {
            new Ulke { Id = "TR", Ad = "Türkiye" },
            new Ulke { Id = "DE", Ad = "Almanya" },
            new Ulke { Id = "US", Ad = "Amerika Birleşik Devletleri" },
            // ... Diğer ülkeleri buraya ekleyebilirsiniz
        };

        public static Dictionary<string, List<Sehir>> Sehirler = new Dictionary<string, List<Sehir>>
        {
            { "TR", new List<Sehir> {
                new Sehir { Id = "34", Ad = "İstanbul" },
                new Sehir { Id = "06", Ad = "Ankara" },
                new Sehir { Id = "35", Ad = "İzmir" },
                // ... Türkiye şehirleri
            }},
            { "DE", new List<Sehir> {
                new Sehir { Id = "030", Ad = "Berlin" },
                new Sehir { Id = "040", Ad = "Hamburg" },
                new Sehir { Id = "089", Ad = "Münih" },
                // ... Almanya şehirleri
            }},
            { "US", new List<Sehir> {
                new Sehir { Id = "NY", Ad = "New York" },
                new Sehir { Id = "CA", Ad = "Los Angeles" },
                new Sehir { Id = "IL", Ad = "Chicago" },
                // ... ABD şehirleri
            }},
            // ... Diğer ülkelerin şehirleri
        };
    }

    public class Ulke
    {
        public string Id { get; set; }
        public string Ad { get; set; }
    }

    public class Sehir
    {
        public string Id { get; set; }
        public string Ad { get; set; }
    }
}
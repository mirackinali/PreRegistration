public class Lokasyon
{
    public int ID { get; set; }
    public string Tanım { get; set; }
    public int? UstID { get; set; }

    // Kendine referans özelliği (isteğe bağlı, navigasyon için)
    public Lokasyon UstLokasyon { get; set; }
    public ICollection<Lokasyon> AltLokasyonlar { get; set; }
}
namespace KullaniciGiris.Models
{
    public class PreRegistration
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string? SelectedCity { get; set; }
    }
}
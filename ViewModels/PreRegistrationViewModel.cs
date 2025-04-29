using Microsoft.AspNetCore.Mvc.Rendering;
using KullaniciGiris.Models;
using System.Collections.Generic;

namespace KullaniciGiris.ViewModels
{
    public class PreRegistrationViewModel
    {
        public PreRegistration PreRegistration { get; set; }

        public List<SelectListItem> CountryList { get; set; }

        public List<SelectListItem> CityList { get; set; }
    }
}
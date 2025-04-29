using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KullaniciGiris.Models;
using KullaniciGiris.ViewModels;
using System.Collections.Generic;

namespace KullaniciGiris.Controllers
{
    public class PreRegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new PreRegistrationViewModel
            {
                PreRegistration = new PreRegistration(),
                CountryList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Türkiye", Value = "Türkiye" },
                    new SelectListItem { Text = "Almanya", Value = "Almanya" },
                    new SelectListItem { Text = "Fransa", Value = "Fransa" }
                },
                CityList = new List<SelectListItem>() // JS ile yüklenecek
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(PreRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Veriyi kaydet, veri tabanı vs.
                return RedirectToAction("Create"); // Veya başka bir sayfaya yönlendir
            }

            // Ülkeleri tekrar yükle (postta gitmiş olur)
            model.CountryList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Türkiye", Value = "Türkiye" },
                new SelectListItem { Text = "Almanya", Value = "Almanya" },
                new SelectListItem { Text = "Fransa", Value = "Fransa" }
            };

            return View(model);
        }
    }
}

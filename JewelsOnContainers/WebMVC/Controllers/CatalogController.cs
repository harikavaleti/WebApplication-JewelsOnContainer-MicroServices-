using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? brandFilterapplied, int? typesFilterApplied)
        {
            var itemsOnPage = 10;

            
            var catalog = await _service.GetCatalogItemsAsync(page ?? 0, itemsOnPage, brandFilterapplied, typesFilterApplied);
           
            var itemsonPage = (catalog.Count);
          
            itemsOnPage = (catalog.Count > itemsOnPage) ? itemsOnPage : int.Parse(itemsonPage.ToString());
                       
            var vm = new CatalogIndexViewModel
            {

                CatalogItems = catalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },

                Brands = await _service.GetTypeAsync(),
                Types = await _service.GetBrandAsync(),
                BrandFilterApplied = brandFilterapplied ?? 0,
                TypesFilterApplied = typesFilterApplied ?? 0

            };

            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }
    }
}
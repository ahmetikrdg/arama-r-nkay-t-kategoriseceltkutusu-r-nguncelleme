using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Data;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class HomeController : Controller
    {   
        public IActionResult Index()
        {         
        var productsViewModel = new ProductViewModel
        {
            Products = ProductRepository.Products
        };

            return View(productsViewModel);
        }
        public IActionResult Abouth()
        {
            return View();
        }
         public IActionResult Contact()
        {
            return View("MyView");
        }
    }
}
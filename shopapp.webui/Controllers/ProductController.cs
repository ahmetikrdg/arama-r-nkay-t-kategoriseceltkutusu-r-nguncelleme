using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shopapp.webui.Data;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult list(int? id,string q)
        { 
           // Console.WriteLine(q);
            //Console.WriteLine(HttpContext.Request.Query["q"].ToString()); -- iki türlüde searc sonucunu alırsın
            var products=ProductRepository.Products;
            if(id!=null)
            {
                products=products.Where(p=>p.CategoryId==id).ToList();
            }
        
           if (!string.IsNullOrEmpty(q))
           {
                products = products.Where(i=>i.Name.Contains(q)).ToList();//search
           }
           var productsViewModel = new ProductViewModel
           {
            Products =products
           };
            return View(productsViewModel);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(ProductRepository.GetProductById(id));
        }
        [HttpGet] //gelir
        public IActionResult Create(){
            ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return View();
        }
        [HttpPost] //gönderir
        public IActionResult Create(Product p)
        {           
            ProductRepository.AddProduct(p);
            return RedirectToAction("list"); 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return View(ProductRepository.GetProductById(id));//bir product gönderir oda editin üzerine tek tek gelir bilgiler
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            ProductRepository.EditProduct(p);
            return RedirectToAction("list");

        }



    }
}
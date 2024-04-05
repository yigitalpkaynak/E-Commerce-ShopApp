using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Data;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class ProductController: Controller
    {
        public IActionResult Index()
        {
            var product = new Product {Name = "Iphone x", Price = 6000, Description = "Güzel Telefon"};

            // ViewData["Category"] = "Telefonlar";
            // ViewData["Product"] = product;

            ViewBag.Category = "Telefonlar";
            // ViewBag.Product = product;

            return View(product);
        }
        public IActionResult list(int? id)
        {
            // Console.WriteLine(RouteData.Values["controller"]);
            // Console.WriteLine(RouteData.Values["action"]);
            // Console.WriteLine(RouteData.Values["id"]);

            var products = ProductRepository.Products;

            if(id!=null)
            {
                products = products.Where(p => p.CategoryId == id).ToList();
            }

            var productViewModel = new ProductViewModel()
            {
                Products = products
            };

            return View(productViewModel);
        }

        public IActionResult Details(int id)
        {
            

            return View(ProductRepository.GetProductById(id));
        }
    }
}
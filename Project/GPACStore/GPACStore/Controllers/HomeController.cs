using GPACStore.Models;
using GPACStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GPACStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IProductRepository productRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productRepository = new ProductRepository();
        }

        public IEnumerable<Product> PopulateProducts()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product { productName = "DbProd1", ProductPrice = 5 });
            products.Add(new Product { productName = "DbProd2", ProductPrice = 5 });
            products.Add(new Product { productName = "DbProd3", ProductPrice = 5 });
            products.Add(new Product { productName = "DbProd4", ProductPrice = 5 });

            return products;
        }

        public IActionResult Index()
        {
            //foreach(var item in PopulateProducts())
            //{
            //    productRepository.Insert(item);
            //}
            return View();
        }

        public IActionResult ShowProducts()
        {
            return View(productRepository.GetAll());
        }


        [HttpGet]
        public IActionResult ProductInsertion()
        {
            return View();
        }


        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        [HttpPost]
        public ActionResult ProductInsertion(Product productObj)
        {
            var nwProduct = new Product
            {
                Id = GetRandomNumber(1, 9),
                productName = productObj.productName,
                ProductPrice = productObj.ProductPrice,
                ArrivalDate = DateTime.Now,
            };
            productRepository.Insert(nwProduct);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MayaFoods.Models;

namespace MayaFoods.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepo;

        public IActionResult Index()
        {
            return View(productRepo.Products.Take(3));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

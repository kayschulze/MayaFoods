using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MayaFoods.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MayaSpecialtyFoods.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepo;

        public ProductsController(IProductRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = thisRepo;
            }
        }

        public IActionResult AllProducts()
        {
            return View(productRepo.Products.ToList());
        }

        public IActionResult Index()
        {
            Product newProduct = new Product();
            var lastthree = newProduct.GetLastThree();
            var bestthree = newProduct.GetBestThree();

            Dictionary<string, IEnumerable<Product>> frontPage = new Dictionary<string, IEnumerable<Product>>();
            frontPage.Add("last", lastthree);
            frontPage.Add("best", bestthree);

            return View(frontPage);
        }

        public IActionResult Details(int id)
        {
            ViewBag.thisProduct = productRepo.Products;
            var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productRepo.Save(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            productRepo.Edit(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Product thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            productRepo.Remove(thisProduct);
            return RedirectToAction("Index");
        }
    }
}
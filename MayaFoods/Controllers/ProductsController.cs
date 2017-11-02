using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            return View(productRepo.Products.ToList());
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

        public ActionResult Delete(int id)
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
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sun.DAL.Data;
using Sun.DAL.Models;
using Sun.PL.Areas.Dashboard.ViewModels;
using Sun.PL.Helper;

namespace Sun.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var products = context.products.ToList();
            var productVm = mapper.Map<IEnumerable<ProductShowVm>>(products);
            return View(productVm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductFormVm viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.ImageName = FilesSetting.UploadFile(viewModel.Image, "product");
            var product = mapper.Map<Product>(viewModel);
            context.products.Add(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = context.products.Find(id);
            if (product is null)
            {
                return NotFound();
            }
            var productVm = mapper.Map<ProductDetailsVm>(product);
            return View(productVm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.products.Find(id);
            if (product is null)
            {
                return NotFound();
            }
            var productVm = mapper.Map<ProductShowVm>(product);
            return View(productVm);
        }
        //ActionName("Delete")
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAbout(int id)
        {
            var product = context.products.Find(id);
            if (product is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FilesSetting.DeleteFile(product.ImageName, "product");

            context.products.Remove(product);
            context.SaveChanges();
            return Ok(new { message = "product deleted" });
        }

        public IActionResult Edit(int id)
        {
            var product = context.products.Find(id);
            if (product is null)
            {
                return NotFound();
            }
            var viewModel = mapper.Map<ProductFormVm>(product);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductFormVm vm)
        {
            var productvm = context.products.Find(vm.Id);
            if (productvm is null)
            {
                return NotFound();
            }
            if (vm.Image is null)
            {

                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(productvm.ImageName, "product");
                vm.ImageName = FilesSetting.UploadFile(vm.Image, "product");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mapper.Map(vm, productvm);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sun.DAL.Data;
using Sun.DAL.Models;
using Sun.PL.Areas.Dashboard.ViewModels;
using Sun.PL.Helper;

namespace Sun.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PackageController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PackageController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var package = context.packages.ToList();
            var packageVm = mapper.Map<IEnumerable<PackageShowVm>>(package);
            return View(packageVm);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PackageFormVm viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var package = mapper.Map<Package>(viewModel);
            context.packages.Add(package);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var package = context.packages.Find(id);
            if(package is null)
            {
                return NotFound();
            }
            var PackageVm = mapper.Map<PackageDetailsVm>(package);
            return View(PackageVm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Package = context.packages.Find(id);
            if (Package is null)
            {
                return NotFound();
            }
            var PackageVm = mapper.Map<PackageShowVm>(Package);
            return View(PackageVm);
        }
        //ActionName("Delete")
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAbout(int id) 
        {
            var Package = context.packages.Find(id);
            if (Package is null)
            {
                return RedirectToAction(nameof(Index));
            }
            context.packages.Remove(Package);
            context.SaveChanges();
            return Ok(new {message= "Package deleted" });
        }

        public IActionResult Edit(int id)
        {
            var Package = context.packages.Find(id);
            if (Package is null)
            {
                return NotFound();
            }
            var viewModel = mapper.Map<PackageFormVm>(Package);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AboutFormVm vm)
        {
            var Packagevm = context.packages.Find(vm.Id);
            if (Packagevm is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            
            mapper.Map(vm,Packagevm);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

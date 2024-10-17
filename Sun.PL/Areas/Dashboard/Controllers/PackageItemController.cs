using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sun.DAL.Data;
using Sun.DAL.Models;
using Sun.PL.Areas.Dashboard.ViewModels;
using Sun.PL.Helper;

namespace Sun.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PackageItemController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PackageItemController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //public IActionResult Index()
        //{
        //    var abouts = context.abouts.ToList();
        //    var aboutVm = mapper.Map<IEnumerable<AboutShowVm>>(abouts);
        //    return View(aboutVm);
        //}

        [HttpGet]
        public IActionResult Create() 
        {
            var packages = context.packages.ToList();
            var vm = new PackageItemFormVm
            {
                packagesList = new SelectList(packages,"Id","Name")
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PackageItemFormVm viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.ImageName = FilesSetting.UploadFile(viewModel.Image, "item");
            var packageItem = mapper.Map<PackageItem>(viewModel);
            context.packageitems.Add(packageItem);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var about = context.abouts.Find(id);
            if(about is null)
            {
                return NotFound();
            }
            var aboutVm = mapper.Map<AboutDetailsVm>(about);
            return View(aboutVm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var about = context.abouts.Find(id);
            if (about is null)
            {
                return NotFound();
            }
            var aboutVm = mapper.Map<AboutShowVm>(about);
            return View(aboutVm);
        }
        //ActionName("Delete")
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAbout(int id) 
        {
            var about = context.abouts.Find(id);
            if (about is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FilesSetting.DeleteFile(about.ImageName, "about");

            context.abouts.Remove(about);
            context.SaveChanges();
            return Ok(new {message="about deleted"});
        }

        public IActionResult Edit(int id)
        {
            var about = context.abouts.Find(id);
            if (about is null)
            {
                return NotFound();
            }
            var viewModel = mapper.Map<AboutFormVm>(about);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AboutFormVm vm)
        {
            var aboutvm = context.abouts.Find(vm.Id);
            if (aboutvm is null)
            {
                return NotFound();
            }
            if(vm.Image is null)
            {
                
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(aboutvm.ImageName, "about");
                vm.ImageName = FilesSetting.UploadFile(vm.Image, "about");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            
            mapper.Map(vm,aboutvm);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

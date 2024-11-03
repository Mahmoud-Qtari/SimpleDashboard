using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sun.DAL.Data;
using Sun.DAL.Models;
using Sun.PL.Areas.Dashboard.ViewModels;
using Sun.PL.Helper;

namespace Sun.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
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
        public IActionResult Index()
        {
            var items = context.packageitems.ToList();
            var itemVm = mapper.Map<IEnumerable<PackageItemShowVm>>(items);
            return View(itemVm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var package = context.packages.ToList();
            var vm = new PackageItemFormVm
            {
                packagesList = new SelectList(package,"Id","Name")
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
            var item = mapper.Map<PackageItem>(viewModel);
            context.packageitems.Add(item);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var item = context.packageitems.Find(id);
            if(item is null)
            {
                return NotFound();
            }
            var itemVm = mapper.Map<PackageItemDetailsVm>(item);
            return View(itemVm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = context.packageitems.Find(id);
            if (item is null)
            {
                return NotFound();
            }
            var itemVm = mapper.Map<PackageItemShowVm>(item);
            return View(itemVm);
        }
        //ActionName("Delete")
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAbout(int id) 
        {
            var item = context.packageitems.Find(id);
            if (item is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FilesSetting.DeleteFile(item.ImageName, "item");

            context.packageitems.Remove(item);
            context.SaveChanges();
            return Ok(new {message="item deleted"});
        }

        public IActionResult Edit(int id)
        {
            var item = context.packageitems.Find(id);
            if (item is null)
            {
                return NotFound();
            }
            var viewModel = mapper.Map<PackageItemFormVm>(item);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PackageItemFormVm vm)
        {
            var itemvm = context.packageitems.Find(vm.Id);
            if (itemvm is null)
            {
                return NotFound();
            }
            if(vm.Image is null)
            {
                
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(itemvm.ImageName, "item");
                vm.ImageName = FilesSetting.UploadFile(vm.Image, "item");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            
            mapper.Map(vm,itemvm);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

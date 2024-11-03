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
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ServiceController(ApplicationDbContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var services = context.services.ToList();
            var serviceVm = mapper.Map<IEnumerable<ServiceShowVm>>(services);
            return View(serviceVm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceFormVm viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.ImageName = FilesSetting.UploadFile(viewModel.Image, "service");
            var service = mapper.Map<Service>(viewModel);
            context.services.Add(service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var service = context.services.Find(id);
            if (service is null)
            {
                return NotFound();
            }
            var serviceVm = mapper.Map<ServiceDetailsVm>(service);
            return View(serviceVm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var service = context.services.Find(id);
            if (service is null)
            {
                return NotFound();
            }
            var serviceVm = mapper.Map<ServiceShowVm>(service);
            return View(serviceVm);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAbout(int id)
        {
            var service = context.services.Find(id);
            if (service is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FilesSetting.DeleteFile(service.ImageName, "service");

            context.services.Remove(service);
            context.SaveChanges();
            return Ok(new { message = "service deleted" });
        }

        public IActionResult Edit(int id)
        {
            var service = context.services.Find(id);
            if (service is null)
            {
                return NotFound();
            }
            var viewModel = mapper.Map<ServiceFormVm>(service);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceFormVm vm)
        {
            var servicevm = context.services.Find(vm.Id);
            if (servicevm is null)
            {
                return NotFound();
            }
            if (vm.Image is null)
            {

                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(servicevm.ImageName, "service");
                vm.ImageName = FilesSetting.UploadFile(vm.Image, "service");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mapper.Map(vm, servicevm);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

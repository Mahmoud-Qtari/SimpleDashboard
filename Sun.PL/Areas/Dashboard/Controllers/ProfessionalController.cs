using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sun.DAL.Data;
using Sun.DAL.Models;
using Sun.PL.Areas.Dashboard.ViewModels;
using Sun.PL.Helper;

namespace Sun.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProfessionalController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ProfessionalController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var professionalList = context.professionals.ToList();
            var professionalVm = mapper.Map<IEnumerable<ProfessionalShowVm>>(professionalList);
            return View(professionalVm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProfessionalFormVm viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.ImageName = FilesSetting.UploadFile(viewModel.Image, "professional");
            var professional = mapper.Map<Professional>(viewModel);
            context.professionals.Add(professional);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var professional = context.professionals.Find(id);
            if (professional is null)
            {
                return NotFound();
            }
            var professionalVm = mapper.Map<ProfessionalDetailsVm>(professional);
            return View(professionalVm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var professional = context.professionals.Find(id);
            if (professional is null)
            {
                return NotFound();
            }
            var professionalVm = mapper.Map<ProfessionalShowVm>(professional);
            return View(professionalVm);
        }
        //ActionName("Delete")
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAbout(int id)
        {
            var professional = context.professionals.Find(id);
            if (professional is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FilesSetting.DeleteFile(professional.ImageName, "professional");

            context.professionals.Remove(professional);
            context.SaveChanges();
            return Ok(new { message = "Professional deleted" });
        }

        public IActionResult Edit(int id)
        {
            var professional = context.professionals.Find(id);
            if (professional is null)
            {
                return NotFound();
            }
            var viewModel = mapper.Map<ProfessionalFormVm>(professional);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProfessionalFormVm vm)
        {
            var professionalvm = context.professionals.Find(vm.Id);
            if (professionalvm is null)
            {
                return NotFound();
            }
            if (vm.Image is null)
            {

                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(professionalvm.ImageName, "professional");
                vm.ImageName = FilesSetting.UploadFile(vm.Image, "professional");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mapper.Map(vm, professionalvm);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

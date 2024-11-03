using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sun.DAL.Data;
using Sun.DAL.Models;
using Sun.PL.Helper;
using Sun.PL.ViewModels;
using System.Diagnostics;

namespace Sun.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(UserManager<ApplicationUser> userManager,ILogger<HomeController> logger,ApplicationDbContext context)
        {
            this.userManager = userManager;
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var professionalList = context.professionals.ToList();
            var productList = context.products.ToList();
            var services = context.services.ToList();
            var abouts = context.abouts.ToList();
            var items = context.packageitems.ToList();
            var pacakes = context.packages.ToList();
            ViewBag.professional = professionalList;
            ViewBag.product = productList;
            ViewBag.services = services;
            ViewBag.abouts = abouts;
            ViewBag.items = items;
            ViewBag.pacakes = pacakes;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DataForm()
        {
            return View();
        }

        public async Task<IActionResult> SendFormData(Booking model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var booking = new Booking
                    {
                        Name = model.Name,
                        Phone = model.Phone,
                        NumberOfPeople = model.NumberOfPeople,
                        CreatedAt = model.CreatedAt,
                        Description = model.Description,
                        SentEmail = model.SentEmail,
                    };
                    var email = new Email
                    {
                        
                        Subject = "Booking",
                        Body = "Your Name: "+booking.Name+", Your Phone: "+booking.Phone+ ", Your Reservation At: " + booking.CreatedAt+", number Of Person: "+booking.NumberOfPeople+ ", Booking Notes: " + booking.Description+" , Your Email For Contact: "+booking.SentEmail,
                        Recevers = model.Email,
                    };

                    EmailSettings.SendEmail(email);
                }
            }
            return RedirectToAction(nameof(Privacy));
        }
    }
}

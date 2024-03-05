using Business.Abstarct;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;
using WebUI.ViewModel;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _categoryService = categoryService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            // Retrieve language preference from cookie or use default
            var culture = _httpContextAccessor.HttpContext.Request.Cookies["Culture"] ?? "az-AZ";

            // Fetch categories using the retrieved language preference
            var categories = _categoryService.GetAllCategoriesFeatured(culture);

            // Populate your view model and return the view
            var homeVM = new HomeVM
            {
                CategoryFeatureds = categories.Data
            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture)
        {
            // Set culture cookie
            Response.Cookies.Append("Culture", culture, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            // Redirect to the same page or another page
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

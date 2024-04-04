using DataBase;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly ILogger<OrganizationController> _logger;
        //private DataBaseContext _context;

        //public OrganizationController(ILogger<OrganizationController> logger, DataBaseContext context)
        //{
        //    _logger = logger;
        //    _context = context;
        //}
        public OrganizationController(ILogger<OrganizationController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() //organization
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(OrganizationModel organization) //organization
        { 
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View("Index");
        }
    }
}

using AutoMapper;
using BuissnessLayer.Interfaces;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly ILogger<OrganizationController> _logger;
        private DataBaseContext _context;
        private IMapper _mapper;
        private IOrganizationsRepository _organizationsRepo;

        public OrganizationController(ILogger<OrganizationController> logger, DataBaseContext context,
            IMapper mapper, IOrganizationsRepository organizationsRepo)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _organizationsRepo = organizationsRepo;
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

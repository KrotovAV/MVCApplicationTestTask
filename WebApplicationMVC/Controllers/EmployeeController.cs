using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationMVC.Controllers;
using WebApplicationMVC.Models;
using DataBase;
using DataBase.DB;
using AutoMapper;
using System.Collections.Specialized;
using BuissnessLayer.Interfaces;

namespace WebApplicationMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private DataBaseContext _context;
        private IMapper _mapper;
        private IOrganizationsRepository _organizationsRepo;
        public EmployeeController(ILogger<EmployeeController> logger, DataBaseContext context, 
            IMapper mapper, IOrganizationsRepository organizationsRepo)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _organizationsRepo = organizationsRepo;
        }
        //public EmployeeController(ILogger<EmployeeController> logger, DataBaseContext context)
        //{
        //    _logger = logger;
        //    _context = context;
        //}

        //public EmployeeController(ILogger<EmployeeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Show() //employee
        {
            //List<Employee> employees = _context.Employees.ToList();
            //List<EmployeeModel> employeesModel = _mapper.Map<List<EmployeeModel>>(employees);


            EmployeeModel VasiaVasin = new EmployeeModel
            {
                SurName = "Vasin",
                Name = "Vasia",
                SecondName = "Vasilievich",
                BirthDate = new DateTime(2000, 4, 16),
                SeriaPassport = "KB",
                NumberPassport = 1234567
            };

            EmployeeModel KoliaKolin = new EmployeeModel
            {
                SurName = "Kolin",
                Name = "Kolia",
                SecondName = "Nikolaevich",
                BirthDate = new DateTime(2001, 4, 16),
                SeriaPassport = "KB",
                NumberPassport = 2345678
            };

            List<EmployeeModel> employeesModel = new List<EmployeeModel> { KoliaKolin, VasiaVasin };
            return View(employeesModel);
        }


        public IActionResult Index() //employee
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(EmployeeModel employee) //employee
        {
            Console.WriteLine("привет из метода check");
            if (ModelState.IsValid) 
            {
                return Redirect("/");
            }
            return View("Index");
        }
    }
}

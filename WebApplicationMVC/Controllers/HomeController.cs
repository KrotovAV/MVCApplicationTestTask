using AutoMapper;
using DataBase;
using DataBase.DB;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataBaseContext _context;
        private IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, DataBaseContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        

        public IActionResult Index()
        {
            //Console.WriteLine("привет из метода Index()");
            List<Employee> employees = _context.Employees.ToList();
            List<EmployeeModel> employeesModel = _mapper.Map<List<EmployeeModel>>(employees);
            using (var context = _context) 
            { 
                SampleData.PrintEmployees(context);
            }
            
            return View(employeesModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
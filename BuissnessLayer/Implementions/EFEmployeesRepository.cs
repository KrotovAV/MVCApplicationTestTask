using BuissnessLayer.Interfaces;
using DataBase;
using DataBase.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Implementions
{
    //Material > Employee
    //Directory > Organization
    public class EFEmployeesRepository : IEmployeesRepository
    {
        private DataBaseContext _context;
        public EFEmployeesRepository(DataBaseContext context)
        {
            _context = context;
        }
        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees(bool includeOrganizations = false)
        {
            if (includeOrganizations)
                return _context.Set<Employee>().Include(x => x.Organization).AsNoTracking().ToList();
            else
                return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int organizationId, bool includeOrganizations = false)
        {
            if (includeOrganizations)
                //return _context.Set<Employee>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directryId);
                return _context.Set<Employee>().FirstOrDefault(x => x.Id == organizationId);
            else
                return _context.Employees.FirstOrDefault(x => x.Id == organizationId);
        }

        public void SaveEmployee(Employee employee)
        {
            if (employee.Id == 0)
                _context.Employees.Add(employee);
            else
                _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

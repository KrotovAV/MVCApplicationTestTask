using DataBase.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Interfaces
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetAllEmployees(bool includeOrganizations = false);
        Employee GetEmployeeById(int organizationId, bool includeOrganizations = false);
        void SaveEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}

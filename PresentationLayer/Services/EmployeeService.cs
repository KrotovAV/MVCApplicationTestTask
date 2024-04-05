
using BuissnessLayer;
using DataBase.DB;
using System.IO;

namespace PresentationLayer.Models
{
    public class EmployeeService
    {
        //Material > Employee
        //Directory > Organization
        
        private DataManager dataManager;
        public EmployeeService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public EmployeeViewModel EmployeeDBModelToView(int employeeId)
        {
            var _model = new EmployeeViewModel()
            {
                Employee = dataManager.EmployeesRepo.GetEmployeeById(employeeId),
            };
            var _org = dataManager.OrganizationsRepo.GetOrganizationById(_model.Employee.OrganizationId, true);

            if (_org.Employees.IndexOf(_org.Employees.FirstOrDefault(x => x.Id == _model.Employee.Id)) != _org.Employees.Count() - 1)
            {
                _model.NextEmployee = _org.Employees.ElementAt(_org.Employees.IndexOf(_org.Employees.FirstOrDefault(x => x.Id == _model.Employee.Id)) + 1);
            }
            return _model;
        }
        public EmployeeEditModel GetEmployeeEdetModel(int employeeId)
        {
            var _dbModel = dataManager.EmployeesRepo.GetEmployeeById(employeeId);
            var _editModel = new EmployeeEditModel()
            {
                Id = _dbModel.Id,
                Organizationid = _dbModel.OrganizationId,
                SurName = _dbModel.SurName,
                Name = _dbModel.Name,
                SecondName = _dbModel.SecondName,
                BirthDate = _dbModel.BirthDate,
                SeriaPassport = _dbModel.SeriaPassport,
                NumberPassport = _dbModel.NumberPassport,
            };
            return _editModel;
        }
        public EmployeeViewModel SaveMaterialEditModelToDb(EmployeeEditModel editModel)
        {
            Employee employee;
            if (editModel.Id != 0)
            {
                employee = dataManager.EmployeesRepo.GetEmployeeById(editModel.Id);
            }
            else
            {
                employee = new Employee();
            }
            employee.SurName = editModel.SurName;
            employee.Name = editModel.Name;
            employee.SecondName = editModel.SecondName;
            employee.BirthDate = editModel.BirthDate;
            employee.SeriaPassport = editModel.SeriaPassport;
            employee.NumberPassport = editModel.NumberPassport;
            employee.OrganizationId = editModel.Organizationid;
            dataManager.EmployeesRepo.SaveEmployee(employee);
            return MaterialDBModelToView(employee.Id);
        }
        public EmployeeEditModel CreateNewEmployeeEditModel(int OrganizationId)
        {
            return new EmployeeEditModel() { Organizationid = OrganizationId };
        }
    }

}
   


using BuissnessLayer;
using PresentationLayer.Models;

namespace PresentationLayer
{
    //Material > Employee
    //Directory > Organization
    public class ServicesManager
    {
        DataManager _dataManager;
        private OrganizationService _organizationService;
        private EmployeeService _employeeService;

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _organizationService = new OrganizationService(_dataManager);
            _employeeService = new EmployeeService(_dataManager);
        }
        public OrganizationService Directrys { get { return _organizationService; } }
        public EmployeeService Employees { get { return _employeeService; } }
    }
}
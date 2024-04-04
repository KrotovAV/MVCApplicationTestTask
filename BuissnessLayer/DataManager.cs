using BuissnessLayer.Interfaces;

namespace BuissnessLayer
{
    public class DataManager
    {
        private IOrganizationsRepository _organizationsRepo;
        private IEmployeesRepository _employeesRepo;

        public DataManager(IOrganizationsRepository organizationsRepo, IEmployeesRepository employeesRepo)
        {
            _organizationsRepo = organizationsRepo;
            _employeesRepo = employeesRepo;
        }
        public IOrganizationsRepository OrganizationsRepo { get { return _organizationsRepo;} }
            
        public IEmployeesRepository EmployeesRepo { get { return _employeesRepo;} }
    }
}
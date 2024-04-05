

using BuissnessLayer;
using DataBase.DB;
using System.IO;

namespace PresentationLayer.Models
{
    public class OrganizationService
    {
        //Directory > Organization
        //Material > Employee
        private DataManager _dataManager;
        private EmployeeService _employeeService;
        public OrganizationService(DataManager dataManager)
        {
            this._dataManager = dataManager;
            _employeeService = new EmployeeService(dataManager);
        }
        public List<OrganizationViewModel> GetOrganizationList()
        {
            var _orgs = _dataManager.OrganizationsRepo.GetAllOrganizations();
            List<OrganizationViewModel> _modelsList = new List<OrganizationViewModel>();
            foreach (var item in _orgs)
            {
                _modelsList.Add(OrganizationDBToViewModelById(item.Id));
            }
            return _modelsList;
        }
        public OrganizationViewModel OrganizationDBToViewModelById(int organizationId)
        {
            var _organization = _dataManager.OrganizationsRepo.GetOrganizationById(organizationId, true);

            List<EmployeeViewModel> _employeesViewModelList = new List<EmployeeViewModel>();
            foreach (var item in _organization.Employees)
            {
                _employeesViewModelList.Add(_employeeService.EmployeeDBModelToView(item.Id));
            }
            return new OrganizationViewModel() { Organization = _organization, Employees = _employeesViewModelList };
        }
        public OrganizationEditModel GetOrganizationEdetModel(int organizationid = 0)
        {
            if (organizationid != 0)
            {
                var _orgDB = _dataManager.OrganizationsRepo.GetOrganizationById(organizationid);
                var _dirEditModel = new OrganizationEditModel()
                {
                    Id = _orgDB.Id,
                    Name = _orgDB.Name,
                    AdressUri = _orgDB.AdressUri,
                    AdressFact = _orgDB.AdressFact
                };
                return _dirEditModel;
            }
            else { return new OrganizationEditModel() { }; }
        }
        public OrganizationViewModel SaveOrganizationEditModelToDb(OrganizationEditModel directryEditModel)
        {
            Organization _organizationDbModel;
            if (directryEditModel.Id != 0)
            {
                _organizationDbModel = _dataManager.OrganizationsRepo.GetOrganizationById(directryEditModel.Id);
            }
            else
            {
                _organizationDbModel = new Organization();
            }
            _organizationDbModel.Name = directryEditModel.Name;
            _organizationDbModel.Inn = directryEditModel.Inn;
            _organizationDbModel.AdressUri = directryEditModel.AdressUri;
            _organizationDbModel.AdressFact = directryEditModel.AdressFact;

            _dataManager.OrganizationsRepo.SaveOrganization(_organizationDbModel);

            return OrganizationDBToViewModelById(_organizationDbModel.Id);
        }
        public OrganizationEditModel CreateNewOrganizationEditModel()
        {
            return new OrganizationEditModel() { };
        }
    }

}
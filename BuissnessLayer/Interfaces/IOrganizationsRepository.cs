using DataBase.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Interfaces
{
    public interface IOrganizationsRepository
    {
        IEnumerable<Organization> GetAllOrganizations(bool includeEmployee = false);
        Organization GetOrganizationById(int organizationId, bool includeEmployees = false);
        void SaveOrganization(Organization organization);
        void DeleteOrganization(Organization organization);
    }
}

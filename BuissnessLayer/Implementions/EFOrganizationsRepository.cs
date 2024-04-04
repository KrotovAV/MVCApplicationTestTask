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
    public class EFOrganizationsRepository : IOrganizationsRepository
    {
        private DataBaseContext _context;
        public EFOrganizationsRepository(DataBaseContext context)
        {
            _context = context;
        }
        public void DeleteOrganization(Organization organization)
        {
            _context.Organizations.Remove(organization);
            _context.SaveChanges();
        }

        public IEnumerable<Organization> GetAllOrganizations(bool includeEmployee = false)
        {
            if (includeEmployee)
                return _context.Set<Organization>().ToList();
                //return _context.Set<Organization>().Include(x => x.Materials).AsNoTracking().ToList();
            else
                return _context.Organizations.ToList();
        }

        public Organization GetOrganizationById(int organizationId, bool includeEmployees = false)
        {
            if (includeEmployees)
                return _context.Set<Organization>().FirstOrDefault(x => x.Id == organizationId);
                //return _context.Set<Organization>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == organizationId);
            else
                return _context.Organizations.FirstOrDefault(x => x.Id == organizationId);
        }

        public void SaveOrganization(Organization organization)
        {
            if (organization.Id == 0)
                _context.Organizations.Add(organization);
            else
                _context.Entry(organization).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

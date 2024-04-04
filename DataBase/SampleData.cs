using DataBase.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public static class SampleData
    {

        public static void InitData(DataBaseContext context)
        {
            if (!context.Organizations.Any())
            {
                Organization org1 = new Organization
                {
                    Name = "Organization1",
                    Inn = 123456789,
                    AdressUri = "fhgfhgfh",
                    AdressFact = "mbmnbm "
                };
                Organization org2 = new Organization
                {
                    Name = "Organization2",
                    Inn = 234567890,
                    AdressUri = "fhgfhgfh",
                    AdressFact = "mbmnbm "
                };

                context.Organizations.AddRange(org1, org2);

                context.SaveChanges();

                Employee VasiaVasin = new Employee
                {
                    SurName = "Vasin",
                    Name = "Vasia",
                    SecondName = "Vasilievich",
                    BirthDate = new DateTime(2000, 4, 16),
                    SeriaPassport = "KB",
                    NumberPassport = 1234567,
                    Organization = org1
                };

                Employee KoliaKolin = new Employee
                {
                    SurName = "Kolin",
                    Name = "Kolia",
                    SecondName = "Nikolaevich",
                    BirthDate = new DateTime(2001, 4, 16),
                    SeriaPassport = "KB",
                    NumberPassport = 2345678,
                    Organization = org1
                };
                Employee MisaMishin = new Employee
                {
                    SurName = "Mishin",
                    Name = "Misha",
                    SecondName = "Mihailovich",
                    BirthDate = new DateTime(2001, 4, 16),
                    SeriaPassport = "KB",
                    NumberPassport = 2345678,
                    Organization = org1
                };
                context.Employees.AddRange(VasiaVasin, KoliaKolin, MisaMishin);

                context.SaveChanges();
            }
        }
        public static void ChangeNameOfEmployee(DataBaseContext context, string oldName, string newName)
        {
            Employee? employee1 = context.Employees.FirstOrDefault(e => e.Name == oldName);
            if (employee1 != null)
            {
                employee1.Name = newName;
                context.SaveChanges();
            }
        }
        public static void ChangeNameOfOrganization(DataBaseContext context, string oldName, string newName)
        {
            Organization? organization = context.Organizations.FirstOrDefault(o => o.Name == oldName);
            if (organization != null)
            {
                organization.Name = newName;
                context.SaveChanges();
            }
        }
        public static void ChangeOrganizationOfEmployee(DataBaseContext context, string name, string orgName)
        {
            Employee? employee = context.Employees.FirstOrDefault(e => e.Name == name);
            Organization? organization = context.Organizations.FirstOrDefault(o => o.Name == orgName);
            if (employee != null && organization != null)
            {
                employee.Organization = organization;
                context.SaveChanges();
            }
        }

        public static void DeleteEmployee(DataBaseContext context, string name)
        {
            Employee? employee = context.Employees.FirstOrDefault(e => e.Name == name);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
        public static void DeleteOrganization(DataBaseContext context, string name)
        {
            Organization? organization = context.Organizations.FirstOrDefault(o => o.Name == name);
            if (organization != null)
            {
                context.Organizations.Remove(organization);
                context.SaveChanges();
            }
        }


        public static void DeleteEmployees(DataBaseContext context)
        {
            if (context.Employees.Any())
            {
                context.Employees.ExecuteDelete();
            }
        }
        public static void DeleteOrganizations(DataBaseContext context)
        {
            if (context.Organizations.Any())
            {
                context.Organizations.ExecuteDelete();
            }
        }
        public static void PrintEmployees(DataBaseContext context)
        {
            Console.WriteLine("");

            var employees = context.Employees.ToList();
            Console.WriteLine("List employees:");
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.Id}.{e.SurName} {e.Name} {e.SecondName}. {e.BirthDate.ToString()} Pass:{e.SeriaPassport} {e.NumberPassport}. Org:{e.Organization.Name}");
            }
        }
        public static void PrintOrganizations(DataBaseContext context)
        {
            Console.WriteLine("");
            var organizations = context.Organizations.ToList();
            Console.WriteLine("List organizations:");
            foreach (var o in organizations)
            {
                Console.WriteLine($"{o.Id}. {o.Name} - {o.Inn} - {o.AdressFact} ({o.AdressUri})");
            }
        }
    }
}

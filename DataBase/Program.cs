using DataBase.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello, World!");

            using (DataBaseContext db = new DataBaseContext())
            {

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

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

                db.Organizations.AddRange(org1, org2);

                //db.Organizations.Add(org1);
                db.Organizations.Add(org2);
                db.SaveChanges();

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

 
                db.Employees.AddRange(VasiaVasin, KoliaKolin); 
                db.Employees.Add(KoliaKolin);
                db.Employees.Add(KoliaKolin);
                db.SaveChanges();
            }

            using (DataBaseContext db = new DataBaseContext())
            {
                Employee? employee1 = db.Employees.FirstOrDefault(e => e.Name == "Kolia");
                if (employee1 != null)
                {
                    employee1.Name = "Dima";
                    db.SaveChanges();
                }
                
                Organization? organization = db.Organizations.FirstOrDefault(o => o.Name == "Organization2");
                if (organization != null)
                {
                    organization.Name = "Organization3";
                    db.SaveChanges();
                }

                Employee? employee2 = db.Employees.FirstOrDefault(e => e.Name == "Dima");
                if (employee2 != null && organization != null)
                {
                    employee2.Organization = organization;
                    db.SaveChanges();
                }
            }

            using (DataBaseContext db = new DataBaseContext())
            {
                Employee? employee = db.Employees.FirstOrDefault(e => e.Name == "Kolia");
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }

                Organization? organization = db.Organizations.FirstOrDefault(o => o.Name == "Organization2");
                if (organization != null)
                {
                    db.Organizations.Remove(organization);
                    db.SaveChanges();
                }
            }


            using (DataBaseContext db = new DataBaseContext())
            {
                var organizations = db.Organizations.ToList();
                Console.WriteLine("List organizations:");
                foreach (var o in organizations)
                {
                    Console.WriteLine($"{o.Id}. {o.Name} - {o.Inn} - {o.AdressFact} ({o.AdressUri})");
                }

                Console.WriteLine("");

                var employees = db.Employees.ToList();
                Console.WriteLine("List employees:");
                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.Id}.{e.SurName} {e.Name} {e.SecondName}. {e.BirthDate.ToString()} Pass:{e.SeriaPassport} {e.NumberPassport}. Org:{e.Organization.Name}");
                }
            }
        }
    }
}
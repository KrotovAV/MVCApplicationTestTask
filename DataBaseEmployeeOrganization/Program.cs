
using DataBaseEmployeeOrganization.DB;
using System.Runtime.Intrinsics.X86;

namespace DataBaseEmployeeOrganization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


            //------------
            Organization org1 = new Organization
            {
                Name = "Organization1",
                Inn = 123456789,
                AdressUri = "fhgfhgfh",
                AdressFact = "mbmnbm "
            };

            using (DataBaseContext db = new DataBaseContext())
            {
                // пересоздадим базу данных
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                // создание и добавление моделей
                //Organization org1 = new Organization
                //{
                //    Name = "Organization1",
                //    Inn = 123456789,
                //    AdressUri = "fhgfhgfh",
                //    AdressFact = "mbmnbm "
                //};
                db.Organizations.Add(org1);
                //db.Organizations.AddRange(org1);
                db.SaveChanges();
                //Organization org2 = new Organization { Name = "Organization2" };

                //db.Organizations.AddRange(org1, org2);

                //Employee tom = new Employee { 
                //    SurName = "Sur1", 
                //    Name = "Vasia", 
                //    SecondName = "SecondName1",
                //    BirthDate = new DateTime(2000, 4, 16),
                //    SeriaPassport ="KB",
                //    NumberPassport = 1234567,
                //    Organization = org1 
                //};
                //Employee bob = new Employee { Name = "Bob", Organization = org1 };
                //Employee alice = new Employee { Name = "Alice", Organization = org2 };
                //db.Employees.AddRange(tom, bob, alice);
                //db.SaveChanges();
            }

            //using (DataBaseContext db = new DataBaseContext())
            //{
            //    // вывод пользователей
            //    var employees = db.Employees.Include(u => u.Organization).ToList();
            //    foreach (Employee employee in employees)
            //        Console.WriteLine($"{employee.Name} - {employee.Organization?.Name}");

            //    // вывод компаний
            //    var organizations = db.Organizations.Include(c => c.Employees).ToList();
            //    foreach (Organization organization in organizations)
            //    {
            //        Console.WriteLine($"\n  омпани€: {organization.Name}");
            //        foreach (Employee employee in organization.Employees)
            //        {
            //            Console.WriteLine($"{employee.Name}");
            //        }
            //    }
            //}

            //using (DataBaseContext db = new DataBaseContext())
            //{
            //    // изменение имени пользовател€
            //    Employee? employee1 = db.Employees.FirstOrDefault(p => p.Name == "Tom");
            //    if (employee1 != null)
            //    {
            //        employee1.Name = "Tomek";
            //        db.SaveChanges();
            //    }
            //    // изменение названи€ компании
            //    Organization? organization = db.Organizations.FirstOrDefault(p => p.Name == "Google");
            //    if (organization != null)
            //    {
            //        organization.Name = "Alphabet";
            //        db.SaveChanges();
            //    }

            //    // смена компании сотрудника
            //    Employee? employee2 = db.Employees.FirstOrDefault(p => p.Name == "Bob");
            //    if (employee2 != null && organization != null)
            //    {
            //        employee2.Organization = organization;
            //        db.SaveChanges();
            //    }
            //}

            //using (DataBaseContext db = new DataBaseContext())
            //{
            //    Employee? employee = db.Employees.FirstOrDefault(u => u.Name == "Bob");
            //    if (employee != null)
            //    {
            //        db.Employees.Remove(employee);
            //        db.SaveChanges();
            //    }

            //    Organization? organization = db.Organizations.FirstOrDefault();
            //    if (organization != null)
            //    {
            //        db.Organizations.Remove(organization);
            //        db.SaveChanges();
            //    }
            //}
            //------------
        }
    }
}
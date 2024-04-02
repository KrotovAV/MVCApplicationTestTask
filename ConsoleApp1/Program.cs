using DataBaseEmployeeOrganization.DB;
using DataBaseEmployeeOrganization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

           
            Console.WriteLine("Hello, World!");




            using (DataBaseContext db = new DataBaseContext())
            {
                Organization org1 = new Organization
                    {
                        Name = "Organization1",
                        Inn = 123456789,
                        AdressUri = "fhgfhgfh",
                        AdressFact = "mbmnbm "
                    };

                db.Organizations.Add(org1);
                //db.Organizations.AddRange(org1);
                db.SaveChanges();
            }
            Console.WriteLine("End");
        }
    }
}
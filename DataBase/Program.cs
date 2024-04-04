using DataBase.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello, World!");
            using (DataBaseContext db = new DataBaseContext())
            {

                SampleData.InitData(db);
                SampleData.PrintEmployees(db);
                SampleData.PrintOrganizations(db);

                SampleData.ChangeNameOfEmployee(db, "Kolia", "Dima");
                SampleData.ChangeNameOfOrganization(db, "org2", "org3");
                SampleData.ChangeOrganizationOfEmployee(db, "Dima", "org3");
                SampleData.DeleteEmployee(db, "Kolia");
                SampleData.DeleteOrganization(db, "org1");
                SampleData.PrintEmployees(db);
                SampleData.PrintOrganizations(db);

                //SampleData.DeleteEmployees(db);
                //SampleData.DeleteOrganizations(db);
                //SampleData.PrintEmployees(db);
                //SampleData.PrintOrganizations(db);
            }

            Console.WriteLine("End!");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DB
{
    public class Organization
    {
        // организации (Наименование, ИНН, юр. адрес, факт. адрес
        public int Id { set; get; }
        public string Name { set; get; }
        public int Inn { set; get; }
        public string AdressUri { set; get; }
        public string AdressFact { set; get; }
        public virtual List<Employee> Employees { get; set; }

    }
}

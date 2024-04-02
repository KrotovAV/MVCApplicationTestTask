using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseEmployeeOrganization.DB
{
    public class Employee
    {
        //сотрудников (Фамилия, Имя, Отчество, дата рождения, паспорт серия, паспорт номер)

        public int Id { set; get; }
        public string SurName { set; get; }
        public string Name { set; get; }
        public string SecondName { set; get; }
        public DateTime BirthDate { set; get; }
        public string SeriaPassport { set; get; }
        public int NumberPassport { set; get; }
        public virtual Organization? Organization { set; get; }
        
    }
}

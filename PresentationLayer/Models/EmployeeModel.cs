
using DataBase.DB;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    //сотрудников (Фамилия, Имя, Отчество, дата рождения, паспорт серия, паспорт номер)
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public Employee NextEmployee { get; set; }
        
        
    }
    public class EmployeeEditModel
    {
        public int Id { set; get; }
        [Required]
        public string SurName { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string SecondName { set; get; }
        [Required]
        public DateTime BirthDate { set; get; }
        [Required]
        public string SeriaPassport { set; get; }
        [Required]
        public int NumberPassport { set; get; }
        [Required]
        public int Organizationid { set; get; }

    }
}

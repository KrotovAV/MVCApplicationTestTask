using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DB
{
    public class Employee
    {
        //сотрудников (Фамилия, Имя, Отчество, дата рождения, паспорт серия, паспорт номер)
        //Directory > Organization
        //Material > Employee
        public int Id { set; get; }
        public string SurName { set; get; }
        public string Name { set; get; }
        public string SecondName { set; get; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { set; get; }
        public string SeriaPassport { set; get; }
        public int NumberPassport { set; get; }
        public int OrganizationId { set; get; } //внешний ключ
        public virtual Organization Organization { set; get; } //навигацинное свойство

    }
}

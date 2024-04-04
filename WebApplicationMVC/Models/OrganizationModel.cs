using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class OrganizationModel
    {
        public int Id { set; get; }

        [Display(Name = "Наименование организации")]
        [Required(ErrorMessage = "обязательное поле")]
        public string Name { set; get; }

        [Display(Name = "ИНН организации")]
        [Required(ErrorMessage = "обязательное поле")]
        [Range(100000000, 1000000000, ErrorMessage = "должно быть 9 цифр")]
        public int Inn { set; get; }

        [Display(Name = "Юридический адрес организации")]
        [Required(ErrorMessage = "обязательное поле")]
        public string AdressUri { set; get; }

        [Display(Name = "Фактический адрес организации")]
        [Required(ErrorMessage = "обязательное поле")]
        public string AdressFact { set; get; }
        //public virtual List<Employee> Employees { get; set; }
    }
}

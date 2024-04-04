using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class EmployeeModel
    {
        public int Id { set; get; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "обязательное поле")]
        public string SurName { set; get; }


        [Display(Name = "Имя")]
        [Required(ErrorMessage = "обязательное поле")]
        public string Name { set; get; }


        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "обязательное поле")]
        public string SecondName { set; get; }


        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "обязательное поле")]
        public DateTime BirthDate { set; get; }


        [Display(Name = "Серия паспорта")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "должно быть две заглавные латинские буквы")]
        [Required(ErrorMessage = "обязательное поле")]
        public string SeriaPassport { set; get; }


        [Display(Name = "Номер паспорта")]
        [Required(ErrorMessage = "обязательное поле")]
        [Range(1000000, 10000000, ErrorMessage = "должно быть семь цифр")]
        public int NumberPassport { set; get; }




        //public virtual Organization? Organization { set; get; }
    }
}

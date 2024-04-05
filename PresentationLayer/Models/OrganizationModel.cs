

using DataBase.DB;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace PresentationLayer.Models
{
    // организации (Наименование, ИНН, юр. адрес, факт. адрес
    public class OrganizationViewModel
    {

        public Organization Organization { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }

    }
    public class OrganizationEditModel
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Inn { set; get; }
        [Required]
        public string AdressUri { set; get; }
        [Required]
        public string AdressFact { set; get; }
        

    }
}

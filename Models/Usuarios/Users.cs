using Scuad.Models.Cargos;
using System.ComponentModel.DataAnnotations;

namespace Scuad.Models
{
    public sealed class Users
    {

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public Charge Charges { get; set; }

        public bool IsActive { get; set; }
    }
}
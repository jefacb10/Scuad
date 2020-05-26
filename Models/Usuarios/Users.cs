using System.ComponentModel.DataAnnotations;

namespace Scuad.Models
{
    public sealed class Users
    {

        [Required(ErrorMessage = "Campo 'Usuário' é obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo 'Senha' é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
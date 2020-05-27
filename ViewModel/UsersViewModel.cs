using Scuad.Models;
using Scuad.Models.Cargos;
using System.Collections.Generic;

namespace Scuad.ViewModel
{
    public partial class UsersViewModel
    {
        public Users Users { get; set; }
        public List<Charge> Charges { get; set; }
    }

    public partial class UsersViewModel
    {
        public List<Users> UsersList { get; set; } 
    }
}
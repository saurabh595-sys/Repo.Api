using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Model
{
    public class Roles
    {

        [Key]
        public int RoleId { get; set; }
        [Required]
        public string Role { get; set; }

       
    }
}

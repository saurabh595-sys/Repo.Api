using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Roles")]
        public virtual int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Roles Roles { get; set; }





    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRole.Domain.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [MaxLength(120)]
        public string Username { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Password { get; set; }
        public int RoleId { get; set; }


        public virtual Role Role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookStore.DTO
{
    public class Role
    {
        [Key]
        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("role_name")]
        [Required]
        [StringLength(255)]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

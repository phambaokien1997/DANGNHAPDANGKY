using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccess.BookStore.DTO
{
    public class User
    {
        [Key]
        [Column("user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Column("email")]
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Column("password")]
        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.BookStore.DTO;

namespace DataAccess.BookStore.DBContext
{
    public class EBookDBContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        public EBookDBContext(DbContextOptions options) : base(options)
        {
        }
        public EBookDBContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Thiết lập chuỗi kết nối đến cơ sở dữ liệu SQL Server
                //BKS - 20240209BOY (trên lap)
                string connectionString = "Server=DESKTOP-4QUI8GB;Database=BOOKSTORE;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
                // Sử dụng SQL Server làm cơ sở dữ liệu
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookStore.DTO
{
    public class UserCreateUpdateRequestData
    {
        public int UserID { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int RoleID {  get; set; }
        public Role? Role { get; set; }
    }
}

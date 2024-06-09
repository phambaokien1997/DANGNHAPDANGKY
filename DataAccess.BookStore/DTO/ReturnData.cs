using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookStore.DTO
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string? ReturnMsg { get; set; }
        public bool Result { get; set; }
    }
    public class UserInsertReturnData : ReturnData
    {
        public User? user { get; set; }
    }
    public class UserAcountReturnData : ReturnData
    {
        public User? user { get; set;}
    }

}

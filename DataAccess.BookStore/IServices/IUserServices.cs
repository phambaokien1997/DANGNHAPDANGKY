using DataAccess.BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookStore.IServices
{
    public interface IUserServices
    {
        Task<UserInsertReturnData> UserInsertUpdateAsync(UserCreateUpdateRequestData requestData);
        Task<UserAcountReturnData> UserAcountAsync(UserAcountRequestData requestData);
    }
}

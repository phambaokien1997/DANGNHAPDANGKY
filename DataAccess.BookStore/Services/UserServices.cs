using DataAccess.BookStore.DBContext;
using DataAccess.BookStore.DTO;
using DataAccess.BookStore.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookStore.Services
{
    public class UserServices : IUserServices
    {
        private EBookDBContext _eUserDbContext;
        public UserServices()
        {
            _eUserDbContext = new EBookDBContext();
        }
        public async Task<UserInsertReturnData> UserInsertUpdateAsync(UserCreateUpdateRequestData requestData)
        {
            var returnData = new UserInsertReturnData();
            var erroItem = string.Empty;
            try
            {
                //if (requestData.RoleID != 1 || requestData.RoleID != 2)
                //{
                //    returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Error;
                //    returnData.ReturnMsg = "Khong the truy cap neu ban khong phai la admin";
                //    return returnData;
                //}
                if (requestData == null || string.IsNullOrEmpty(requestData.Email) || string.IsNullOrEmpty(requestData.Password))
                {
                    returnData.ReturnCode =(int)EBook.Common.Enum_ReturnCode.DataIsNull;
                    returnData.ReturnMsg = "Du lieu khong hop le";
                    return returnData;
                }
                //check ky tu dac biet
                if (BookCommonLibs.BookValidationData.CheckContainSpecialChar(requestData.Email) || BookCommonLibs.BookValidationData.CheckContainSpecialChar(requestData.Password))
                {
                    returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.DataInValid;
                    returnData.ReturnMsg = "Email va password khong duoc chua ky tu dac biet";
                    return returnData;
                }
                //Check trung
                var newUser = _eUserDbContext.User.Where(u => u.Email == requestData.Email).FirstOrDefault();
                if(newUser != null || newUser?.UserId > 0)
                {
                    returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.DataIsNull;
                    returnData.ReturnMsg = "Ten Email bi trung roi";
                    return returnData;
                }
                var userRequest = new User
                {

                    Email = requestData.Email,
                    Password = requestData.Password,
                    RoleId = 3
                    
                };
                await _eUserDbContext.User.AddAsync(userRequest);
                await _eUserDbContext.SaveChangesAsync();

                
                returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Success;
                returnData.ReturnMsg = "Dang ky thanh cong roi!!!";
                return returnData;
            }
            catch(Exception ex)
            {
                returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Error;
                returnData.ReturnMsg = $"Đã xảy ra lỗi: {ex.Message}";
                return returnData;
            }
        }
        public async Task<UserAcountReturnData> UserAcountAsync(UserAcountRequestData requestData)
        {
            var returnData = new UserAcountReturnData();
            var erroItem = string.Empty;
            try
            {
                var EAcount = await _eUserDbContext.User.FirstOrDefaultAsync(u => u.Email == requestData.Email);
                var PAcount = await _eUserDbContext.User.FirstOrDefaultAsync(u=>u.Password == requestData.Password);
                if (EAcount == null || PAcount == null)
                {
                    returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.DataIsNull;
                    returnData.ReturnMsg = "Email hoac mat khau khong dung";
                    returnData.Result = false;
                    return returnData;
                }
                returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Success;
                returnData.ReturnMsg = "Dang nhap thanh cong";
                returnData.Result = true;
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Error;
                returnData.ReturnMsg = $"Đã xảy ra lỗi: {ex.Message}";
                return returnData;
            }
        }
    }
}

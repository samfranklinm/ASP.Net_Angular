using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;


namespace WebAPI.Interface
{
    public interface IUser
    {
        Task<List<UserDetail>> GetAllUsers();
        Task<UserDetail> GetUserById(int id);
        Task<UserDetail> CreateUser(UserDetail userDetail);
        Task<UserDetail> UpdateUser(int id, UserDetail userDetail);
        Task<UserDetail> DeleteUser(int id);
    }
}
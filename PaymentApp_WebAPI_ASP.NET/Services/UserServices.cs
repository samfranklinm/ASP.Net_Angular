using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class UserServices : IUser
    {
        private PaymentDetailContext _context;


        public UserServices(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET
        public async Task<List<UserDetail>> GetAllUsers()
        {
            return await _context.UserDetails.ToListAsync();
        }
        // GET (by ID)
        public async Task<UserDetail> GetUserById(int id)
        {
            return await _context.UserDetails.FindAsync(id);
        }

        // POST 
        public async Task<UserDetail> CreateUser(UserDetail userDetail)
        {

            _context.UserDetails.Add(userDetail);
            await _context.SaveChangesAsync();

            return userDetail;
        }

        // PUT
        public async Task<UserDetail> UpdateUser(int id, UserDetail userDetail)
        {
            // update the provided payment details
            _context.UserDetails.Update(userDetail);
            await _context.SaveChangesAsync();

            return userDetail;
        }

        // DELETE
        public async Task<UserDetail> DeleteUser(int id)
        {

            // Find the entry by id
            var userDetail = await _context.UserDetails.FindAsync(id);

            // If no details are found
            if (userDetail == null)
            {
                throw new Exception("This user doesn't exist.");
            }

            // otherwise, delete from database
            _context.UserDetails.Remove(userDetail);
            await _context.SaveChangesAsync();

            return userDetail;
        }
    }
}
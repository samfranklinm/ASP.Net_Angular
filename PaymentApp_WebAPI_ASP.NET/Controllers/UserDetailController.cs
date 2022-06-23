using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser _userServices;

        public UserController(IUser userServices)
        {
            _userServices = userServices;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetUserDetails()
        {
            return await _userServices.GetAllUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> GetUserDetail(int id)
        {
            return await _userServices.GetUserById(id);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserDetail>> PostUserDetail(UserDetail userDetail)
        {
            return await _userServices.CreateUser(userDetail);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDetail>> PutUserDetail(int id, UserDetail userDetail)
        {
            return await _userServices.UpdateUser(id, userDetail);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDetail>> DeleteUserDetail(int id)
        {
            return await _userServices.DeleteUser(id);
        }
    }
}
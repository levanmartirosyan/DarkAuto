using DarkAuto.DTOs;
using DarkAuto.Repositories.GetAllUsers;
using DarkAuto.Repositories.Users;
using EntityFrameworkLesson.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Services
{
    public class AdminService
    {
        public ResultModel<List<GetAllUsersDTO>> GetAllUsers()
        {
            using var context = new ApplicationDbContext();

            var userRepo = new GetAllUsersRepository(context);

            var response = userRepo.GetAllUsers();

            return response;
        }

        public async Task<ResultModel<bool>> DeleteUser(int Id)
        {
            await using var context = new ApplicationDbContext();

            var userRepo = new DeleteUserRepository(context);

            var response = await userRepo.DeleteUser(Id);

            return response;
        }

        public async Task<ResultModel<bool>> AddUser(string Username, string Email, string Password, bool IsAdmin)
        {
            await using var context = new ApplicationDbContext();

            var userRepo = new AddUserRepository(context);

            var response = await userRepo.AddUser(Username, Email, Password, IsAdmin);

            return response;
        }
    }
}

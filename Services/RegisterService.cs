using DarkAuto;
using DarkAuto.DTOs;
using DarkAuto.Repositories.Users;
using EntityFrameworkLesson.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DarkAuto.Services
{
    public class RegisterService
    {
        public async Task<ResultModel<bool>> Register(string username, string email, string password)
        {
            await using var context = new ApplicationDbContext();       
            var repo = new RegisterUserRepository(context);

            var regRes = await repo.Register(username, email, password);

            return regRes;
        }

    }
}

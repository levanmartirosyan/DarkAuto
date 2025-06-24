using DarkAuto.DTOs;
using DarkAuto.Repositories.Users;
using EntityFrameworkLesson.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Services
{
    public class LogInService
    {

        public ResultModel<GetUserByCredentialsDTO> LogIn(string email, string password)
        {
            using var context = new ApplicationDbContext();

            var userRepo = new GetUserByCredentialsRepository(context);

            var loginRes = userRepo.GetUserByCredentials(email, password);

            return loginRes;
        }
    }
}

using Azure;
using DarkAuto.DTOs;
using EntityFrameworkLesson.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Repositories.Users
{
    public class RegisterUserRepository
    {
        #region Properties
        ApplicationDbContext _context;
        #endregion

        #region Constructors
        public RegisterUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public async Task<ResultModel<bool>> Register(string username, string email, string password)
        {
            var result = new ResultModel<bool>();

            try
            {

                int rowsAffected = await _context.Database.ExecuteSqlInterpolatedAsync($@"
                EXEC dbo.UsersIUD 
                @UserName = {username}, 
                @Email = {email}, 
                @Password = {password}, 
                @IsAdmin = {false}, 
                @DbAction = 0");

                result.IsSuccess = rowsAffected == -1 || rowsAffected > 0;
                result.Data = result.IsSuccess;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Data = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        #endregion
    }
}

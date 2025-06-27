using EntityFrameworkLesson.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Repositories.Users
{
    public class EditUserRepository
    {
        #region Properties
        ApplicationDbContext _context;
        #endregion

        #region Constructors
        public EditUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public async Task<ResultModel<bool>> EditUser(
                int userId,                     
                string? username,
                string? email,
                string? password,
                bool? isAdmin)
        {
            var result = new ResultModel<bool>();

            try
            {
                int rowsAffected = await _context.Database.ExecuteSqlInterpolatedAsync($@"
                 EXEC dbo.UsersIUD 
                 @UserId   = {userId},
                 @UserName = {username},
                 @Email    = {email},
                 @Password = {password},
                 @IsAdmin  = {isAdmin},
                 @DbAction = 1");       

                result.IsSuccess = rowsAffected == -1 || rowsAffected > 0;
                result.Data = result.IsSuccess;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        #endregion
    }
}

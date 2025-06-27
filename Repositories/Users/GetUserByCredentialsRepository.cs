using DarkAuto.DTOs;
using EntityFrameworkLesson.Models.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Repositories.Users
{
    public class GetUserByCredentialsRepository
    {
        #region Properties
        ApplicationDbContext _context;
        #endregion

        #region Constructors
        public GetUserByCredentialsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public ResultModel<GetUserByCredentialsDTO> GetUserByCredentials(string email, string password)
        {
            var result = new ResultModel<GetUserByCredentialsDTO>();

            var hasher = new PasswordHasher<object>();

            try
            {
                using (_context)
                {
                    var user = _context.Set<GetUserByCredentialsDTO>()
                 .FromSqlInterpolated($"SELECT * FROM GetUserByCredentials({email})")
                 .FirstOrDefault();

                    if (user is null)
                    {
                        result.IsSuccess = false;
                        result.ErrorMessage = "User not found.";
                        return result;
                    }

                    var passResult = hasher.VerifyHashedPassword(null, user.Password, password);

                    if (passResult == PasswordVerificationResult.Failed)
                    {
                        result.IsSuccess = false;
                        result.ErrorMessage = "Invalid password.";
                        return result;
                    }

                    result.IsSuccess = true;
                    result.Data = user;
                }
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

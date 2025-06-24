using DarkAuto.DTOs;
using EntityFrameworkLesson.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Repositories.GetAllUsers
{
    public class GetAllUsersRepository
    {
  
        #region Properties
            ApplicationDbContext _context;
            #endregion

        #region Constructors
            public GetAllUsersRepository(ApplicationDbContext context)
            {
                _context = context;
            }
        #endregion

        #region Methods
        public ResultModel<List<GetAllUsersDTO>> GetAllUsers(int? UserId = null)
        {
            var result = new ResultModel<List<GetAllUsersDTO>>();

            try
            {
                using (_context)
                {
                    var users = _context.Set<GetAllUsersDTO>()
                        .FromSqlInterpolated($"SELECT * FROM GetAllUsers()")
                        .ToList();

                    if (users.Any())
                    {
                        result.IsSuccess = true;
                        result.Data = users;
                    }
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

using DarkAuto.DTOs;
using DarkAuto.Repositories;
using EntityFrameworkLesson.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Repositories
{
    public class GetDeliveriesByUserRepository
    {
        #region Properties
        ApplicationDbContext _context;
        #endregion

        #region Constructors
        public GetDeliveriesByUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public ResultModel<List<GetDeliveriesByUserDTO>> GetDeliveriesByUserId(int UserId)
        {
            var result = new ResultModel<List<GetDeliveriesByUserDTO>>();

            try
            {
                using (_context)
                {
                    var deliveries = _context.Set<GetDeliveriesByUserDTO>()
                        .FromSqlInterpolated($"SELECT * FROM GetDeliveriesByUser({UserId})")
                        .ToList();

                    result.IsSuccess = true;
                    result.Data = deliveries;
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

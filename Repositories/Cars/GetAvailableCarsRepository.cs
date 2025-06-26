using DarkAuto.DTOs;
using EntityFrameworkLesson.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Repositories.Cars
{
    public class GetAvailableCarsRepository
    {
        #region Properties
        ApplicationDbContext _context;
        #endregion

        #region Constructors
        public GetAvailableCarsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public ResultModel<List<GetAllCarsDTO>> GetAvailableCars()
        {
            var result = new ResultModel<List<GetAllCarsDTO>>();

            try
            {
                using (_context)
                {
                    var cars = _context.Set<GetAllCarsDTO>()
                        .FromSqlInterpolated($"SELECT * FROM GetAvailableCars()")
                        .ToList();

                    result.IsSuccess = true;
                    result.Data = cars;
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

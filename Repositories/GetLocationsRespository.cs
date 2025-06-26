using DarkAuto.DTOs;
using EntityFrameworkLesson.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Repositories
{
    public class GetLocationsRespository
    {
        #region Properties
        ApplicationDbContext _context;
        #endregion

        #region Constructors
        public GetLocationsRespository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public ResultModel<List<GetLocationsDTO>> GetLocations()
        {
            var result = new ResultModel<List<GetLocationsDTO>>();

            try
            {
                using (_context)
                {
                    var cars = _context.Set<GetLocationsDTO>()
                        .FromSqlInterpolated($"SELECT * FROM GetLocations()")
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

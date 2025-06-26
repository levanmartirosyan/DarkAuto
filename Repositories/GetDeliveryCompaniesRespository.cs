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
    public class GetDeliveryCompaniesRespository
    {
        #region Properties
        ApplicationDbContext _context;
        #endregion

        #region Constructors
        public GetDeliveryCompaniesRespository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public ResultModel<List<GetDeliveryCompaniesDTO>> GetDeliveryCompanies()
        {
            var result = new ResultModel<List<GetDeliveryCompaniesDTO>>();

            try
            {
                using (_context)
                {
                    var cars = _context.Set<GetDeliveryCompaniesDTO>()
                        .FromSqlInterpolated($"SELECT * FROM GetDeliveryCompanies()")
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

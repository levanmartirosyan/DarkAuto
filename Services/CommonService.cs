using DarkAuto.DTOs;
using DarkAuto.Repositories;
using DarkAuto.Repositories.Cars;
using EntityFrameworkLesson.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Services
{
    public class CommonService
    {
        public ResultModel<List<GetDeliveryCompaniesDTO>> GetDeliveryCompanies()
        {
            using var context = new ApplicationDbContext();

            var Repo = new GetDeliveryCompaniesRespository(context);

            var response = Repo.GetDeliveryCompanies();

            return response;
        }

        public ResultModel<List<GetLocationsDTO>> GetLocations()
        {
            using var context = new ApplicationDbContext();

            var Repo = new GetLocationsRespository(context);

            var response = Repo.GetLocations();

            return response;
        }
    }
}

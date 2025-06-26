using DarkAuto.DTOs;
using DarkAuto.Repositories.Cars;
using EntityFrameworkLesson.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Services
{
    public class CarsService
    {
        public ResultModel<List<GetAllCarsDTO>> GetAllCars()
        {
            using var context = new ApplicationDbContext();

            var Repo = new GetAllCarsRepository(context);

            var response = Repo.GetAllCars();

            return response;
        }

        public ResultModel<List<GetAllCarsDTO>> GetAvailabeCars()
        {
            using var context = new ApplicationDbContext();

            var Repo = new GetAvailableCarsRepository(context);

            var response = Repo.GetAvailableCars();

            return response;
        }

        public ResultModel<List<GetAllCarsDTO>> GetCarsByUserId(int UserId)
        {
            using var context = new ApplicationDbContext();

            var Repo = new GetCarsByUserIdRepository(context);

            var response = Repo.GetCarsByUserId(UserId);

            return response;
        }
    }
}

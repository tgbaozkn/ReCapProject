using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecaprojectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecaprojectContext context = new RecaprojectContext()) {
                var carResult = from car in context.Cars
                                join brand in context.Brands on car.BrandId equals brand.Id
                                join color in context.Colors on car.ColorId equals color.Id
                                select new CarDetailDto
                                {
                                    Id = car.Id,
                                    Name = car.Name,
                                    BrandName = brand.BrandName,
                                    ColorName = color.ColorName,
                                    DailyPrice = car.DailyPrice,
                                    Description = car.Description,
                                    ModelYear = car.ModelYear
                                };
                return carResult.ToList();  



            }
        }
    }
}

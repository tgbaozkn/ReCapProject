using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = "20", ModelYear = "2024", Description = "abs" },
                new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = "20", ModelYear = "2024", Description = "abs" },
                new Car { Id = 3, BrandId = 1, ColorId = 1, DailyPrice = "20", ModelYear = "2024", Description = "abs" },
                new Car { Id = 4, BrandId = 1, ColorId = 1, DailyPrice = "20", ModelYear = "2024", Description = "abs" },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {
            var result = _cars.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                _cars.Remove(result);
            }
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _cars.Where(c=>c.BrandId == brandId).ToList();
        }

        public Car GetById(int id)
        {
           var car = _cars.SingleOrDefault(x=>x.Id == id);
           
           return car;

        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var result = _cars.SingleOrDefault(x => x.Id == car.Id);
            if (result != null)
            {
                result.DailyPrice = car.DailyPrice;
                result.Description = car.Description;
                result.ModelYear = car.ModelYear;   
                result.BrandId = car.BrandId;
                result.ColorId = car.ColorId;   
            }
        }
    }
}

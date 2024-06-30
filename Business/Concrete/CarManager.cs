﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal; //icardala bağlı ama hangi icardal ef mi inmemeory mi vs bu yüzden autofac
        KPSPublicSoapClient soapClient;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;  
            
        }
        public IDataResult<List<Car>> GetCars()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

            public async Task<bool> TcSorgula()
        {
            soapClient = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

            var result = await soapClient.TCKimlikNoDogrulaAsync(1111111, "aaa", "sds", 1995);
            return result.Body.TCKimlikNoDogrulaResult;
        }
        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && Int32.Parse(car.DailyPrice) > 0)
            {
                
                TcSorgula().GetAwaiter().GetResult();
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);

            }
            else
            {
                return new ErrorResult(Messages.CarNotAdded);
               
            }
           
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new  SuccessDataResult<List<Car>>( _carDal.GetAll(c=>c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColorId == id));    
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
           return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
           _carDal.Update(car);
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>( _carDal.Get(c=>c.Id == id));
        }
    }
}

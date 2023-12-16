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
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryProductDal()
        {
            _cars =new List<Car>{ 
                new Car(){CarId=1,BrandId=1,ColorId=2,ModelYear=2015,DailyPrice=1200,Description="Beyaz Renault Clio"},
                new Car(){CarId=2,BrandId=1,ColorId=2,ModelYear=2017,DailyPrice=1400,Description="Beyaz Renault Megane"},
                new Car(){CarId=3,BrandId=2,ColorId=3,ModelYear=2023,DailyPrice=1300,Description="Siyah Fiat Egea"},
                new Car(){CarId=4,BrandId=2,ColorId=2,ModelYear=2008,DailyPrice=700,Description="Beyaz Fiat Palio"},
                new Car(){CarId=5,BrandId=2,ColorId=1,ModelYear=2013,DailyPrice=850,Description="Mavi Fiat Albea"},
            };
        }
        

        public void Add(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(Car car)
        {
         Car DeleteToCar = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
         _cars.Remove(DeleteToCar);
        }

        public void Update(Car car)
        {
            Car UpdateToCar = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            UpdateToCar.BrandId=car.BrandId;
            UpdateToCar.ColorId=car.ColorId;
            UpdateToCar.ModelYear=car.ModelYear;
            UpdateToCar.DailyPrice=car.DailyPrice;
            UpdateToCar.Description=car.Description;
            
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car getByBrand(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}

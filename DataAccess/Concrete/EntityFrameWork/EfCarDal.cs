using Core.DataAccess.EntityFrameWork;
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

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {

                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join _c in context.Colors
                             on c.ColorId equals _c.ColorId
                             select new CarDetailDto
                             {
                                 CarName=c.CarName,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = b.BrandName,
                                 ColorName = _c.ColorName,
                                 CarDescription=c.Description,
                                 ModelYear = c.ModelYear,
                                 CarId=c.CarId
                             };
                return result.ToList();
                             

            }
        }
    }




}

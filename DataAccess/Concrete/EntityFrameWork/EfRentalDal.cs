using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join _c in context.Customers
                             on r.CustomerId equals _c.CustomerId
                             select new RentalDetailDto
                             {

                                 RentalId = r.CarId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CarName = c.CarName,
                                 CustomerName = _c.CompanyName

                             };
                return result.ToList();
                             




            }


        }
    }
}

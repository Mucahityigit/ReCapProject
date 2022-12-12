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
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join img in context.CarImages
                             on c.Id equals img.CarId
                             select new CarDetailDto() {CarId=c.Id,BrandId=c.BrandId, BrandName = b.Name, ColorId=c.ColorId, ColorName = cl.Name, DailyPrice = c.DailyPrice, ModelYear=c.ModelYear, Description=c.Description, ImagePath = img.ImagePath};
                return result.ToList();
            }
        }
    }
}

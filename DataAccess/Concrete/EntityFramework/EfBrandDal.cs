using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var addedBrand = context.Entry(entity);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var deletedBrand = context.Entry(entity);
                deletedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.Brands.SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.Brands.Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var updatedBrand = context.Entry(entity);
                updatedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}

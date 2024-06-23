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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RecaprojectContext context = new RecaprojectContext())
            {
                var addedEntity = context.Add(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RecaprojectContext ctx = new RecaprojectContext())
            {
                var removedEntity = ctx.Remove(entity);
                removedEntity.State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter = null)
        {
            using (RecaprojectContext ctx = new RecaprojectContext())
            {
                return ctx.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RecaprojectContext context = new RecaprojectContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();
            }
        }


        public void Update(Color entity)
        {
            using (RecaprojectContext context = new RecaprojectContext())
            {
                var updatedEntity = context.Update(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

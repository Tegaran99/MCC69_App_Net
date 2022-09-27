using API.Context;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class GeneralRepository<Entity, Primary> : iGeneralRepository<Entity, Primary>
        where Entity : class
    {
        MyContext myContext;
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Create(Entity entity)
        {
            myContext.Set<Entity>().Add(entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Delete(Primary id)
        {
            var data = myContext.Set<Entity>().Find(id);
            myContext.Set<Entity>().Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Entity> Get()
        {
            var data = myContext.Set<Entity>().ToList();
            return data;
        }

        public Entity Get(Primary id)
        {
            var data = myContext.Set<Entity>().Find(id);
            return data;
        }

        public int Update(Primary id, Entity entity)
        {
            myContext.Entry(entity).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }
    }
}

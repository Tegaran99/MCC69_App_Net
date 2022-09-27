using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface iGeneralRepository<Entity, Primary>
        where Entity : class
    {
        List<Entity> Get();
        Entity Get(Primary id);
        int Create(Entity entity);
        int Update(Primary id, Entity entity);
        int Delete(Primary id);

    }
}

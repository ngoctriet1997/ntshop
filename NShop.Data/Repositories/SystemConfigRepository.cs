using NShop.Data.Infrastructure;
using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Data.Repositories
{

    public interface ISystemConfigRepository : IRepository<SystemConfigs>
    {

    }
    public class SystemConfigRepository : RepositoryBase<SystemConfigs>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

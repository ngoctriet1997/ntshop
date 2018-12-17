using NShop.Data.Infrastructure;
using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Data.Repositories
{
    
        public interface ISupportOnliney : IRepository<SupportOnline>
        {

        }
        public class SupportOnlineRepository : RepositoryBase<SupportOnline>, ISupportOnliney
    {
            public SupportOnlineRepository(IDbFactory dbFactory) : base(dbFactory)
            {

            }
        }
    
}

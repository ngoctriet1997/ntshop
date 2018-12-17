using NShop.Data.Infrastructure;
using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Data.Repositories
{
   
        public interface IProductTagRepository
        {

        }
        public class ProductTagRepository : RepositoryBase<PostTag>, IProductTagRepository
        {
            public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
            {

            }
        }
    
}

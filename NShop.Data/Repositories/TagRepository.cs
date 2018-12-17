using NShop.Data.Infrastructure;
using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Data.Repositories
{
   
        public interface ITagRepository : IRepository<Tag>
        {

        }
        public class TagRepository : RepositoryBase<Tag>, ITagRepository
        {
            public TagRepository(IDbFactory dbFactory) : base(dbFactory)
            {

            }
        }
    
}

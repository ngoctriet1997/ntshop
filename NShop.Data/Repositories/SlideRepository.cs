using NShop.Data.Infrastructure;
using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Data.Repositories
{
  

        public interface ISlideRepository : IRepository<Slide>
        {

        }
        public class SlideRepository : RepositoryBase<Slide>, ISlideRepository
        {

            public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
            {

            }

        }


    
}

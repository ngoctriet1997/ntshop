using NShop.Data.Infrastructure;
using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Data.Repositories
{

    public interface IVisitorStatisticRepository
    {

    }
    public class VisitorStatisticRepository : RepositoryBase<VisitorStatistic>, ITagRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }

}

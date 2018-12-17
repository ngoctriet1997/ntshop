using NShop.Data.Infrastructure;
using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Data.Repositories
{
    public interface IMenuRepository
    {

    }
    public class MenuRepository : RepositoryBase<Menu>,IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}

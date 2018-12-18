using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Data.Infrastructure
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TShopDbContext dbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dbContext = DbContext;
        }
        public TShopDbContext DbContext
        {

            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }
        public void Commit()
        {
           
            dbContext.SaveChanges();
        }
    }
}

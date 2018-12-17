using NShop.Data.Infrastructure;
using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Data.Repositories
{
    public interface IPostCategoryRepository: IRepository<PostCategory>
    {

    }
    public class PostCategoryRepository:RepositoryBase<PostCategory>,IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}

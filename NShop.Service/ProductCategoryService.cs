using NShop.Data.Infrastructure;
using NShop.Data.Repositories;
using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory ProductCategory);
        void Update(ProductCategory ProductCategory);
        ProductCategory Delete(int id);
        IEnumerable<ProductCategory> GetAll();
        IEnumerable<ProductCategory> GetAllByParentID(int parentId);
        ProductCategory GetById(int id);
        IEnumerable<ProductCategory> GetAll(string keyword);
        void Save();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;
        public ProductCategoryService(IProductCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory ProductCategory)
        {
            return _postCategoryRepository.Add(ProductCategory);
        }

        public ProductCategory Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _postCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByParentID(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.Parent == parentId);
        }

        public ProductCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleByID(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory ProductCategory)
        {
            _postCategoryRepository.Update(ProductCategory);
        }
    }
}

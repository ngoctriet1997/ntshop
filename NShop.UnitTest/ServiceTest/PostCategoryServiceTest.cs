using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NShop.Data.Infrastructure;
using NShop.Data.Repositories;
using NShop.Model.Models;
using NShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.UnitTest.ServiceTest
{

 

    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategories;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object );
            _listCategories = new List<PostCategory>()
            {
                new PostCategory(){ID=1,Name="DM1",Status=true},
                new PostCategory(){ID=1,Name="DM2",Status=true},
                new PostCategory(){ID=1,Name="DM3",Status=true},
            };
        }
        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategories);

            //call action
           var result= _categoryService.GetAll() as List<PostCategory>;


            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory postCategory = new PostCategory();
            postCategory.Name = "Test";
            postCategory.Alias = "Test";
            postCategory.Status = true;
            _mockRepository.Setup(x => x.Add(postCategory)).Returns((PostCategory post)=>
            {
                post.ID=1;
                return post;
                
            });
            var result=_categoryService.Add(postCategory);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ID, 1);
        }
    }
}

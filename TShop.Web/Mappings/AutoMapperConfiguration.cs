using AutoMapper;
using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TShop.Web.Models;

namespace TShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {

            //var config = new MapperConfiguration(cfg => {

            //    cfg.CreateMap<Post, PostViewModel>();

            //});
            //IMapper iMapper = config.CreateMapper();
            //var source = new Post();
            //var destination = iMapper.Map<Post, PostViewModel>(source);
            ////
            //var config1 = new MapperConfiguration(cfg => {

            //    cfg.CreateMap<PostCategory, PostCategoryViewModel>();

            //});
            //IMapper iMapper1 = config1.CreateMapper();
            //var source1 = new PostCategory();
            //var destination1 = iMapper1.Map<PostCategory, PostCategoryViewModel>(source1);
            ////
            //var config2 = new MapperConfiguration(cfg => {

            //    cfg.CreateMap<Tag, TagViewModel>();

            //});
            //IMapper iMapper2 = config2.CreateMapper();
            //var source2 = new Tag();
            //var destination2 = iMapper2.Map<Tag, TagViewModel>(source2);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();

                cfg.CreateMap<ProductCategory,ProductCategoryViewModel>();
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductTag,ProductTagViewModel>();
            });
        }
    }
}
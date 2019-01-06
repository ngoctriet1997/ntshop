using AutoMapper;
using NShop.Model.Models;
using NShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using TShop.Web.infrastructure.Core;
using TShop.Web.infrastructure.Extensions;
using TShop.Web.Models;

namespace TShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    [Authorize]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService)
            : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string keyword ,int page,int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
             {
                 int totalRow = 0;

                 var model = _productCategoryService.GetAll(keyword);
                 totalRow = model.Count();
                 var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                 var responseDate = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);
                 PaginationSet<ProductCategoryViewModel> pageSet = new PaginationSet<ProductCategoryViewModel>()
                 {
                     Items = responseDate,
                     Page = page,
                     
                     TotalCount = totalRow,
                     TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                 };
                 var response = request.CreateResponse(HttpStatusCode.OK, pageSet);
                 return response;
             });
        }
        [Route("getbyid")]
        [HttpGet]
        public HttpResponseMessage GetByID(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request, () =>
            {
               
                var model = _productCategoryService.GetById(id);
              

                var responseDate = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);
               
                var response = request.CreateResponse(HttpStatusCode.OK, responseDate);
                return response;
            });
        }
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {

                var model = _productCategoryService.GetAll();
              
                var responseDate = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
              
                var response = request.CreateResponse(HttpStatusCode.OK, responseDate);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request,ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if(!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                    return response;
                }
                else
                {
                    var newProductCategory = new ProductCategory();
                    newProductCategory.CreatedDate = DateTime.Now;
                    newProductCategory.UpdateProductCategory(productCategoryViewModel);
                    _productCategoryService.Add(newProductCategory);
                    _productCategoryService.Save();

                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                    return response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
               
            });
        }
        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                    return response;
                }
                else
                {
                  var oldProductCategory =  _productCategoryService.Delete(id);
                    _productCategoryService.Save();
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(oldProductCategory);
                    return response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategories)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                    return response;
                }
                else
                {
                    var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);
                    foreach (var item in listProductCategory)
                    {
                        var oldProductCategory = _productCategoryService.Delete(item);
                    }
                    _productCategoryService.Save();
                    return response = request.CreateResponse(HttpStatusCode.Created, listProductCategory.Count);
                }

            });
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                    return response;
                }
                else
                {
                    var dbProductCategory = _productCategoryService.GetById(productCategoryViewModel.ID);
                    dbProductCategory.UpdateProductCategory(productCategoryViewModel);
                    dbProductCategory.UpdateDate = DateTime.Now;
                    _productCategoryService.Update(dbProductCategory);  
                    _productCategoryService.Save();

                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(dbProductCategory);
                    return response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

            });
        }
    }
}

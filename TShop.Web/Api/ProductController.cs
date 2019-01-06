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
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : ApiControllerBase
    {
        IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService)
            : base(errorService)
        {
            this._productService = productService;
        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;

                var model = _productService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseDate = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query);
                PaginationSet<ProductViewModel> pageSet = new PaginationSet<ProductViewModel>()
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
        public HttpResponseMessage GetByID(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {

                var model = _productService.GetById(id);


                var responseDate = Mapper.Map<Product, ProductViewModel>(model);

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

                var model = _productService.GetAll();

                var responseDate = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseDate);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel ProductViewModel)
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
                    var newProduct = new Product();
                    newProduct.CreatedDate = DateTime.Now;
                    newProduct.UpdateProduct(ProductViewModel);
                    _productService.Add(newProduct);
                    _productService.Save();

                    var responseData = Mapper.Map<Product, ProductViewModel>(newProduct);
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
                    var oldProductCategory = _productService.Delete(id);
                    _productService.Save();
                    var responseData = Mapper.Map<Product, ProductViewModel>(oldProductCategory);
                    return response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProducts)
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
                    var listProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkedProducts);
                    foreach (var item in listProduct)
                    {
                        var oldProduct = _productService.Delete(item);
                    }
                    _productService.Save();
                    return response = request.CreateResponse(HttpStatusCode.Created, listProduct.Count);
                }

            });
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productViewModel)
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
                    var dbProduct = _productService.GetById(productViewModel.ID);
                    dbProduct.UpdateProduct(productViewModel);
                    dbProduct.UpdateDate = DateTime.Now;
                    _productService.Update(dbProduct);
                    _productService.Save();

                    var responseData = Mapper.Map<Product, ProductViewModel>(dbProduct);
                    return response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

            });
        }
    }
}

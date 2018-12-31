using AutoMapper;
using NShop.Model.Models;
using NShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TShop.Web.infrastructure.Core;
using TShop.Web.Models;

namespace TShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategoryService;
        
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService)
            :base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
             {
                 var model = _productCategoryService.GetAll();
                 var responseDate = Mapper.Map<List<ProductCategory>, List<ProductCategoryViewModel>>(model.ToList());
                 var response = request.CreateResponse(HttpStatusCode.OK, responseDate);
                 return response;
             });
        }
    }
}

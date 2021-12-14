﻿using Emerce_API.Infrastructure;
using Emerce_Model;
using Emerce_Model.Product;
using Emerce_Service.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Emerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [LoginFilter]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController( IProductService _productService, IMemoryCache _memoryCache ) : base(_memoryCache)
        {
            productService = _productService;
        }
        //Insert Product
        [HttpPost]
        public General<ProductCreateModel> Insert( [FromBody] ProductCreateModel newProduct )
        {
            newProduct.Iuser = CurrentUser.Id;
            return productService.Insert(newProduct);
        }

        //Get Product
        [HttpGet]
        public General<ProductViewModel> Get()
        {
            return productService.Get();
        }
        //Get Product By Id
        [HttpGet("{id}")]
        public General<ProductViewModel> GetById( int id )
        {
            return productService.GetById(id);
        }

        //Update Product
        [HttpPut("{id}")]
        public General<ProductUpdateModel> Update( [FromBody] ProductUpdateModel updatedProduct, int id )
        {
            updatedProduct.Uuser = CurrentUser.Id;
            return productService.Update(updatedProduct, id);
        }
        //Delete Product
        [HttpDelete("{id}")]
        public General<ProductViewModel> Delete( int id )
        {
            return productService.Delete(id);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo.DTO;
using Repo.Model;
using Repo.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repo.Api.Controllers
{
    [Authorize]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Product>))]
        public async Task<IActionResult> GetProductList()
        {
            IEnumerable<Product> products = await _productService.GetAllProduct();
            return Ok(products);
        }

        [Authorize(Policy = "All")]
        [HttpPost]
        [Produces(typeof(Product))]
        public async Task<IActionResult> AddProduct(ProductAddDTO addDTO)
        {
            return Ok(await _productService.AddProduct(addDTO));
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        [Route("{id}")]
        [Produces(typeof(User))]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO productDTO)
        {
            return Ok(await _productService.UpdateProduct(productDTO));
        }
        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        [Produces(typeof(bool))]
        public async Task<bool> DeleteProduct(int id)
        {
            return await _productService.DeleteProduct(id);
        }
    }
}

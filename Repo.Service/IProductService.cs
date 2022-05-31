using Repo.DTO;
using Repo.Model;
using Repo.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Service
{
    public  interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int id);
        Task<bool> AddProduct(ProductAddDTO productAdd);
        Task<bool> UpdateProduct(ProductUpdateDTO productUpdate);
        Task<bool> DeleteProduct(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> AddProduct(ProductAddDTO productDTO)
        {
            try
            {
                var product = new Product();
                product.ProductName = productDTO.productName;
                product.CategoryId = productDTO.catagoryId;

                await _productRepository.Add(product);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product product = await GetProductById(id);
            if (product != null)
            {
                await _productRepository.Delete(product);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _productRepository.Get();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<bool> UpdateProduct(ProductUpdateDTO productDTO)
        {
            try
            {
                Product _product = await GetProductById(productDTO.ProductId);
                if (_product != null)
                {
                    _product.ProductName = productDTO.productName;
                    _product.CategoryId = productDTO.catagoryId;
                    await _productRepository.Update(_product);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

       
    }
}

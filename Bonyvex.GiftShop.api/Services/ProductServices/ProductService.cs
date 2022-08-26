using Bonyvex.GiftShop.api.Data;
using Bonyvex.GiftShop.api.Library;
using Bonyvex.GiftShop.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly APIDbContext _context;
        private readonly IUsefullFunctions _usefullFunctions;

        public ProductService(APIDbContext context, IUsefullFunctions usefullFunctions)
        {
            _context = context;
            _usefullFunctions =usefullFunctions;
        }


        public async Task<ServiceResponse> AddProduct(ProductModel product)
        {
            try
            {
                product.Id = Guid.NewGuid().ToString();
                product.CreationDate = DateTime.Now;

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();


                return new ServiceResponse()
                {
                    Success = true,
                    Message = "Product added into Database"
                };

            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Success = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<ServiceResponse> DeleteProduct(string id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    return new ServiceResponse()
                    {
                        Success = false,
                        Message = "Given Id doesn't exist in Database"
                    };
                }

                _context.Remove(product);
                _context.SaveChanges();

                return new ServiceResponse()
                {
                    Success=true,
                    Message = "Product with the given id deleted from database!"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse();
            }
        }

        public async Task<ServiceResponse> UpdateProduct(ProductModel productToUpdate)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productToUpdate.Id);

                product.ImagePath = string.IsNullOrEmpty(productToUpdate.ImagePath) ? product.ImagePath : productToUpdate.ImagePath;
                product.Name = string.IsNullOrEmpty(productToUpdate.Name) ? product.Name : productToUpdate.Name;
                product.Description = string.IsNullOrEmpty(productToUpdate.Description) ? product.Description : productToUpdate.Description;
                product.Price = await _usefullFunctions.IsNullOrEmptyDecimal(productToUpdate.Price) ? product.Price : productToUpdate.Price;

                await _context.SaveChangesAsync();

                return new ServiceResponse()
                {
                    Success = true,
                    Message = "Product Updated."
                };

            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Success = false,
                    Message =ex.Message
                };
            }
        }

        public async Task<ProductModel> GetProductById(string id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

                if (product == null)
                {
                    return null;
                }

                return product;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            try
            {
                var response = await _context.Products.ToListAsync();

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}

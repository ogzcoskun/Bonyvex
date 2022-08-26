using Bonyvex.GiftShop.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Services.ProductServices
{
    public interface IProductService
    {
        Task<ServiceResponse> AddProduct(ProductModel product);
        Task<ServiceResponse> DeleteProduct(string id);
        Task<ServiceResponse> UpdateProduct(ProductModel productToUpdate);
        Task<ProductModel> GetProductById(string id);
        Task<List<ProductModel>> GetAllProducts();
    }
}

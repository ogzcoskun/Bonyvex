using Bonyvex.GiftShop.api.Models;
using Bonyvex.GiftShop.api.Services.ProductServices;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Commands.Handlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ServiceResponse>
    {
        private readonly IProductService _productService;

        public AddProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ServiceResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var response = await _productService.AddProduct(new ProductModel()
                {
                    Id = request.Product.Id,
                    Name = request.Product.Name,
                    Price = request.Product.Price,
                    ImagePath = request.Product.ImagePath,
                    Description = request.Product.Description,
                    CreationDate = DateTime.Now,
                }) ;

                return response;

            }catch(Exception ex)
            {
                return new ServiceResponse()
                {
                    Success = false,
                    Message = ex.Message ,
                };
            }

            
        }
    }
}

using Bonyvex.GiftShop.api.Models;
using Bonyvex.GiftShop.api.Services.ProductServices;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Commands.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        

        public async Task<ServiceResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            try
            {

                var response = await _productService.UpdateProduct(request.UpdatedProduct);
                return response;

            }catch(Exception ex)
            {
                return new ServiceResponse()
                {
                    Success = false,
                    Message = "An error occured while trying to update product."
                };
            }


            throw new System.NotImplementedException();
        }
    }
}

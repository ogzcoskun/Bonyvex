using Bonyvex.GiftShop.api.Models;
using Bonyvex.GiftShop.api.Services.ProductServices;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Commands.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ServiceResponse>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ServiceResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _productService.DeleteProduct(request.ProductId);


                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse();
            }
        }
    }
}

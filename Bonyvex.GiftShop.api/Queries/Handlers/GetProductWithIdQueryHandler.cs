using Bonyvex.GiftShop.api.Models;
using Bonyvex.GiftShop.api.Services.ProductServices;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Queries.Handlers
{
    public class GetProductWithIdQueryHandler : IRequestHandler<GetProductWithIdQuery, ProductModel>
    {
        private readonly IProductService _productService;

        public GetProductWithIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ProductModel> Handle(GetProductWithIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _productService.GetProductById(request.Id);
                return response;
            }
            catch 
            {
                return null;
            }
        }
    }
}

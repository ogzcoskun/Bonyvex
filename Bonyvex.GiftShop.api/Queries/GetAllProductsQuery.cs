using Bonyvex.GiftShop.api.Models;
using MediatR;
using System.Collections.Generic;

namespace Bonyvex.GiftShop.api.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductModel>>
    {
    }
}

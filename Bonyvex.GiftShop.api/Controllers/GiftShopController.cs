using Bonyvex.GiftShop.api.Commands;
using Bonyvex.GiftShop.api.Models;
using Bonyvex.GiftShop.api.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GiftShopController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GiftShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel product)
        {
            try
            {
                var response = await _mediator.Send(new AddProductCommand()
                {
                    Product = product
                });
                

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
 
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct([FromBody] string id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteProductCommand()
                {
                    ProductId = id
                });


                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel product)
        {
            try
            {

                if (String.IsNullOrEmpty(product.Id))
                {
                    return BadRequest("Product Id can't be null or empty");
                }

                var response = await _mediator.Send(new UpdateProductCommand()
                {
                    UpdatedProduct = product
                });


                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductWithId([FromBody] string id)
        {

            try
            {
                var product = await _mediator.Send(new GetProductWithIdQuery()
                {
                    Id = id
                });

                if(product == null)
                {
                    return BadRequest("Given id doesn't exist in Database");
                }

                return Ok(product);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var product = await _mediator.Send(new GetAllProductsQuery());

                if (product == null)
                {
                    return BadRequest("Given id doesn't exist in Database");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendPayment([FromBody] PaymentModel payment)
        {
            try
            {
                var response = await _mediator.Send(new SendPaymentCommand()
                {
                    Payment = payment
                });

                return Ok(response);

            }
            catch(Exception ex)
            {
                return BadRequest(new ServiceResponse()
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        
    }
}

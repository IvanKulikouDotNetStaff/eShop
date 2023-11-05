using Basket.API.Enities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IBasketRepository _basketRepository;
        private readonly DiscountGrpcService _discountGrpcService;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            ShoppingCart basket = await _basketRepository.GetBasket(userName);

            return Ok(basket);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {

            //foreach (var item in basket.Items) 
            //{
            //    var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
            //    item.Price -= coupon.Price;
            //}

            ShoppingCart updatedBasket = await _basketRepository.UpdateBasket(basket);

            return Ok(updatedBasket);
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBakset(string userName)
        {
            await _basketRepository.DeleteBasket(userName);

            return Ok();
        }
    }
}

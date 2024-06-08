using FurnitureSellingCore.DTO.Cart;
using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.ItemRequest;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.DTO.WishList;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace FurnitureSelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {private readonly ICartItemServices _cartItemServices;
        private readonly ICartServices _cartServices;
        private readonly IWishListServices _wishListServices;
        private readonly IItemRequestServices _itemRequestServices;
        public CustomerController(IItemRequestServices itemRequestServices,ICartItemServices cartItemServices, ICartServices cartServices, IWishListServices wishListServices) { 
            _cartItemServices=cartItemServices;
            _cartServices=cartServices;
            _wishListServices=wishListServices;
            _itemRequestServices=itemRequestServices;
}



        #region wishList
        //get id by wishList
     
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetwishListbyid([FromRoute] int id)
        {

            try
            {
                var wishList = await _wishListServices.GetByIdWishList(id);
                return Ok(wishList);

            }
            catch
            {
                return BadRequest("cannot found this wishList");
            }
        }

        //get all wishList       
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllwishList()
        {

            try
            {
                var wishList = await _wishListServices.GetAllWishList();    
                return Ok(wishList);

            }
            catch
            {
                return BadRequest("con not found  wishList");
            }
        }



        //greate wishList
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewWishList(CardWishListDTO d)
        {
            try
            {
                await _wishListServices.CreateWishList(d);  
                return Ok("done to add New  WishList");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        //update WishList
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdatWishList(WishListDTO dto)
        {
            try
            {
                var WishList = _wishListServices.UpdateWishList(dto);
                return Ok("done to update this");

            }
            catch 
            {

                return BadRequest("Can't updates this WishList");
            }
        }
        //delete wishList
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteWishList([FromRoute] int id)
        {

            try
            {
                await _wishListServices.DeleteWishList(id);
                return Ok("delete this WishList");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


 


        #endregion
        #region CartItem

        //get id by CartItem

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCartItembyid([FromRoute]int id)
        {

            try
            {
                var CartItem = await _cartItemServices.GetByIdCartItem(id);
                return Ok(CartItem);

            }
            catch
            {
                return BadRequest("con not found  CartItem");
            }
        }

        //get all CartItem       
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCartItem()
        {

            try
            {
                var CartItem = await _cartItemServices.GetAllCartItem();
                return Ok(CartItem);

            }
            catch
            {
                return BadRequest("con not found  CartItem");
            }
        }

        //greate cartItem
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewCartItem(CreateCartItemDTO c)
        {
            try
            {
                await _cartItemServices.CreateCartItem(c);
                return Ok("create new cart item");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        //update cartItem
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCartItem(CartItemDTO dto)
        {
            try
            {
                var CartItem = _cartItemServices.UpdateCartItem(dto);
                return Ok(CartItem);

            }
            catch (Exception ex)
            {

                return BadRequest("Can't updates this CartItem");
            }
        }
        //delete CartItem
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteCartItem([FromRoute] int id)
        {

            try
            {
                await _cartItemServices.DeleteCartItem(id);
                return Ok("delete this CartItem");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
        #region Cart
        //get id by Cart
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCartbyid([FromRoute]int id)
        {

            try
            {
                var Cart = await _cartServices.GetByIdCart(id);
                return Ok(Cart);

            }
            catch
            {
                return BadRequest("can not found  Cart");
            }
        }

        //get all Cart
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCartAll()
        {

            try
            {
                var Carts = await _cartServices.GetAllCart();
                return Ok(Carts);

            }
            catch
            {
                return BadRequest("can not found  Carts");
            }
        }

        //greate Cart
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewCart([FromBody] CartDTO c)
        {
            try
            {
                await _cartServices.CreateCart(c); 
                return Ok("create new cart");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        //update Cart
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCart([FromBody] CardCartDTO dto)
        {
            try
            {
                var Cart = _cartServices.UpdateCart(dto);
                return Ok(Cart);

            }
            catch (Exception ex)
            {

                return BadRequest("Con't updates this Cart");
            }
        }
        //delete Cart
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteCart([FromRoute]int id)
        {

            try
            {
                await _cartServices.DeleteCart(id);
                return Ok("delete this Cart");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region ItemRequest
     
        //greate Item Request
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateItemRequest([FromBody] ItemRequestDTO i)
        {
            try
            {
                await _itemRequestServices.CreateItemRequest(i);
                return Ok("new item request is add");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        //update Item Request
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateItemReuest([FromBody] CardItemRequestDTO dto)
        {
            try
            {
                await _itemRequestServices.UpdatetemRequest(dto);
                return Ok("Update item Request");

            }
            catch 
            {

                return BadRequest("Can't updates this item Request");
            }
        }
        //delete Item Request
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteItemRequest([FromRoute] int id)
        {

            try
            {
                await _itemRequestServices.DeleteItemRequest(id);
                return Ok("delete this Item Request");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion 
    }
}

using Azure;
using FurnitureSellingCore.DTO.Cart;
using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.ItemRequest;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.DTO.WishList;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Repos;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetWishListById
        ///     {        
        ///       "Id": "Enter the id of whish List" 
        ///     }
        /// </remarks>
        /// <returns>wishList</returns>
        /// <response code="400">cann't get the wishList</response>
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetWishListById([FromRoute] int Id)
        {
            try
            {
                Log.Debug("start GetWishListById-controller", Id);
                var wishList = await _wishListServices.GetByIdWishList(Id);
                return Ok(wishList);

            }
            catch
            {
                Log.Error("cannot found this wishList");
                return BadRequest("cannot found this wishList");
            }
        }

        //get all wishList

        /// <returns>wishList</returns>
        /// <response code="400">cann't  get the all  wishList</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllWishList()
        {

            try
            {
                Log.Debug("start GetAllWishList-controller");
                var wishList = await _wishListServices.GetAllWishList();    
                return Ok(wishList);

            }
            catch
            {
                Log.Error("con not found  wishList");
                return BadRequest("con not found  wishList");
            }
        }



        //greate wishList
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/NewWishList
        ///     {        
        ///        UserId: "Enter the id of user the need to add  whish List" 
        ///        ItemId: "Enter the id of  Item the need to add in whish List" 
        ///     }
        /// </remarks>
        /// <response code="201">add new  wishList</response>
        /// <response code="400">cann't  add the wishList</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewWishList(CardWishListDTO d)
        {
            try
            {
                Log.Debug("start NewWishList-controller");
                await _wishListServices.CreateWishList(d);  
                return StatusCode(201, "done to add New  WishList");

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        //update WishList
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateWishList
        ///     {        
        ///     Id: "Enter the id of WishList that need to update" 
        ///        UserId: "Enter the id of user the need to add  whish List" 
        ///        ItemId: "Enter the id of  Item the need to add in whish List" 
        ///     }
        /// </remarks>
        /// <response code="400">cann't Update the wishList</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateWishList(WishListDTO dto)
        {
            try
            {
                Log.Debug("start UpdateWishList-controller");
                var WishList = _wishListServices.UpdateWishList(dto);
                return Ok("done to update this");

            }
            catch 
            {
                Log.Error("Can't updates this WishList");
                return BadRequest("Can't updates this WishList");
            }
        }
        //delete wishList
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteWishList
        ///     {        
        ///       "Id": "Enter the id of whish List to delete" 
        ///     }
        /// </remarks>
    /// <response code="201"> delete the wishList</response>
        /// <response code="400">cann't delete the wishList</response>
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteWishList([FromRoute] int Id)
        {
            try
            {
                Log.Debug("start DeleteWishList-controller{Id}",Id);
                await _wishListServices.DeleteWishList(Id);
                return StatusCode(201, "delete this WishList");

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);  
                return BadRequest(ex.Message);
            }
        }





        #endregion
        #region CartItem

        //get id by CartItem
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetCartItemById
        ///     {        
        ///       "Id": "Enter the id of Cart Item" 
        ///     }
        /// </remarks>
        /// <returns>Cart Item</returns>
        /// <response code="400">cann't get the Cart Item</response>

        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetCartItemById([FromRoute]int Id)
        {

            try
            {
                Log.Debug("start GetCartItemById-controller{Id}", Id);
                var CartItem = await _cartItemServices.GetByIdCartItem(Id);
                return Ok(CartItem);

            }
            catch
            {  Log.Error("con not found  CartItem");
                return BadRequest("con not found  CartItem");
            }
        }

        //get all CartItem
        /// <returns>all CartItem</returns>
        /// <response code="400">cann't get the all  CartItem</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCartItem()
        {

            try
            {
                Log.Debug("start GetAllCartItem-controller");
                var CartItem = await _cartItemServices.GetAllCartItem();
                return Ok(CartItem);

            }
            catch
            {
                Log.Error("con not found  CartItem");
                return BadRequest("con not found  CartItem");
            }
        }

        //greate cartItem
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/NewCartItem
        ///     {        
        ///        CartId: "Enter the id of user the Cart to add item" 
        ///        ItemId: "Enter the id of  Item the need to add in CartItem" 
        ///     Quantity: "Enter the Quantity of   Item the need to add in CartItem" 
        /// }   
        /// </remarks>
        /// <returns>cartItem</returns>
    /// <response code="201">add  cartItem</response>
        /// <response code="400">cann't add the cartItem</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewCartItem(CreateCartItemDTO c)
        {
            try
            {
                Log.Debug("start NewCartItem-controller");
                await _cartItemServices.CreateCartItem(c);
                return StatusCode(201, "create new cart item");

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);

            }
        }
        //update cartItem
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateCartItem
        ///     {        
        ///     Id: "Enter the id of cartItem that need to update" 
        ///     CartId: "Enter the id of user the Cart to add item" 
        ///        ItemId: "Enter the id of  Item the need to add in CartItem" 
        ///     Quantity: "Enter the Quantity of   Item the need to add in CartItem" 
        ///     }
        /// </remarks>
        /// <response code="400">cann't Update the cartItem</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCartItem(UpdateCartItemDTO dto)
        {
            try
            {
                Log.Debug("start UpdateCartItem-controller{Id}",dto.CartItemId);
                await _cartItemServices.UpdateCartItem(dto);
                return Ok("done to update this CartItem");

            }
            catch 
            {
                Log.Error("Can't updates this CartItem");
                return BadRequest("Can't updates this CartItem");
            }
        }
        //delete CartItem
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteCartItem
        ///     {        
        ///       "Id": "Enter the id of CartItem to delete" 
        ///     }
        /// </remarks>
        /// <response code="201"> delete this CartItem</response>
        /// <response code="400">cann't delete the CartItem</response>
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteCartItem([FromRoute] int Id)
        {

            try
            {
                Log.Debug("start DeleteCartItem-controller{Id}",Id);
                await _cartItemServices.DeleteCartItem(Id);
                return StatusCode(201, "delete this CartItem");

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        #endregion
        #region Cart
        //get id by Cart
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetCartById
        ///     {        
        ///       "Id": "Enter the id of Cart" 
        ///     }
        /// </remarks>
        /// <returns>Cart</returns>
        /// <response code="400">cann't get the Cart</response>
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetCartById([FromRoute]int Id)
        {

            try
            {
                Log.Debug("start GetCartById-controller{Id}", Id);
                var Cart = await _cartServices.GetByIdCart(Id);
                return Ok(Cart);

            }
            catch
            {   
                Log.Error("can not found  Cart");
                return BadRequest("can not found  Cart");
            }
        }

        //get all Cart

        /// <returns>Cart</returns>
        /// <response code="400">cann't get the all  Cart</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCartAll()
        {

            try
            {
                Log.Debug("start GetCartAll-controller");
                var Carts = await _cartServices.GetAllCart();
                return Ok(Carts);

            }
            catch
            {   
                Log.Error("can not found  Carts");
                return BadRequest("can not found  Carts");
            }
        }

        //greate Cart
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/NewCart
        ///     {        
        ///        UserId : "Enter the id of user the Cart to add order" 
        ///        OrderId : "Enter the id of   Order the need to add in Cart" 
        ///        IsActive: "Enter the true or false if the cart is active " 
        /// }   
        /// </remarks>
        /// <returns>cartItem</returns>
        /// <response code="201">add the cart</response>
        /// <response code="400">cann't add the cartItem</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewCart([FromBody] CartDTO c)
        {
            try
            {
                Log.Debug("start NewCart-controller");
                await _cartServices.CreateCart(c);
                return StatusCode(201, "done to add New  Cart");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        //update Cart
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateCart
        ///     {        
        ///         Id: "Enter the id of cart that need to update" 
        ///        UserId : "Enter the id of user the Cart to add order" 
        ///        OrderId : "Enter the id of   Order the need to add in Cart" 
        ///        IsActive: "Enter the true or false if the cart is active " 
        ///     }
        /// </remarks>
        /// <response code="400">cann't Update the cartItem</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCart([FromBody] Cart c)
        {
            try
            {
               await _cartServices.UpdateCart(c);
                return Ok("done to update this cart");

            }
            catch 
            {

                return BadRequest("Can't updates this Cart");
            }
        }
        //delete Cart
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteCart
        ///     {        
        ///       "Id": "Enter the id of  Cart to delete" 
        ///     }
        /// </remarks>
        /// <response code="201"> delete the Cart</response>
        /// <response code="400">cann't delete the Cart</response>
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteCart([FromRoute]int Id)
        {

            try
            {
                Log.Debug("start DeleteCart-controller{Id}",Id);
                await _cartServices.DeleteCart(Id);
                return StatusCode(201, "delete this  Cart");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        #endregion
        #region ItemRequest

        //greate Item Request
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/ItemRequest
        ///     {        
        ///         Title: "Enter the name ofItemRequest " 
        ///         Description: "if have note of ItemRequest" 
        ///         Image : "if have image of ItemRequest" 
        /// CategoryId: "Enter the id of Category of item" 
        /// </remarks>
        ///  <response code="201">create the ItemRequest</response>
        /// <response code="400">cann't create the ItemRequest</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateItemRequest([FromBody] ItemRequestDTO i)
        {
            try
            {
                Log.Debug("start CreateItemRequest-controller");
                await _itemRequestServices.CreateItemRequest(i);
                return StatusCode(201, "done to add New  item request ");

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        //update Item Request
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateItemRequest
        ///     {        
        ///         Id: "Enter the id of ItemRequest that need to update" 
        ///         Title: "Enter the name ofItemRequest " 
        ///         Description: "if have note of ItemRequest" 
        ///         Image : "if have image of ItemRequest" 
        ///          CategoryId: "Enter the id of Category of item"
        ///     }
        /// </remarks>
        /// <response code="400">cann't Update the cartItem</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateItemRequest([FromBody] CardItemRequestDTO dto)
        {
            try
            {
                Log.Debug("start UpdateItemRequest-controller");
                await _itemRequestServices.UpdateItemRequest(dto);
                return Ok("Update item Request");

            }
            catch 
            {
                Log.Error("Can't updates this item Request");
                return BadRequest("Can't updates this item Request");
            }
        }
        //delete Item Request
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteItemRequest
        ///     {        
        ///       "Id": "Enter the id of Item Request to delete" 
        ///     }
        /// </remarks>
        /// <response code="201"> delete the ItemRequest</response>
        /// <response code="400">cann't delete the ItemRequest</response>
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteItemRequest([FromRoute] int Id)
        {

            try
            {
                Log.Debug("start DeleteItemRequest-controller{Id}", Id);
                await _itemRequestServices.DeleteItemRequest(Id);
                return StatusCode(201, "done to delete this item request ");
            }
            catch (Exception ex)
            {
                 Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        #endregion 
    }
}

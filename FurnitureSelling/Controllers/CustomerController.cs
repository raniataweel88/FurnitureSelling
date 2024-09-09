using Azure;
using FurnitureSellingCore.DTO.Cart;
using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.ItemRequest;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.DTO.Rating;
using FurnitureSellingCore.DTO.WishList;
using FurnitureSellingCore.helper;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Repos;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ZstdSharp.Unsafe;

namespace FurnitureSelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    { private readonly ICartItemServices _cartItemServices;
        private readonly ICartServices _cartServices;
        private readonly IWishListServices _wishListServices;
        private readonly IItemRequestServices _itemRequestServices;
        private readonly IProductWarrantyServies _service;
        private readonly IRaviewServices _rating;
        public CustomerController(
            IRaviewServices RaviewServices,
            IItemRequestServices itemRequestServices,
            ICartItemServices cartItemServices,
            ICartServices cartServices,
            IWishListServices wishListServices, 
            IProductWarrantyServies service)
        {
            _cartItemServices = cartItemServices;
            _cartServices = cartServices;
            _wishListServices = wishListServices;
            _itemRequestServices = itemRequestServices;
            _service = service;
            _rating= RaviewServices;
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
        public async Task<IActionResult> GetWishListById([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start GetWishListById-controller", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var wishList = await _wishListServices.GetByIdWishList(Id);
                        return Ok(wishList); ;
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("cannot found this wishList");
                    return BadRequest("cannot found this wishList");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }





        //get all wishList

        /// <returns>wishList</returns>
        /// <response code="400">cann't  get the all  wishList</response>
        [HttpGet]
        [Route("[action]/{userId}")]
        public async Task<IActionResult> GetAllWishList(int userId, [FromHeader] string token)
        {
            Log.Debug("start GetAllWishList-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var wishList = await _wishListServices.GetAllWishList( userId);
                        return Ok(wishList);
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("con not found  wishList");
                    return BadRequest("con not found  wishList");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        public async Task<IActionResult> NewWishList([FromBody] CardWishListDTO d, [FromHeader] string token)
        {
            Log.Debug("start NewWishList-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token)) {
                        await _wishListServices.CreateWishList(d);
                        return Ok( "done to add New  WishList");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        public async Task<IActionResult> UpdateWishList([FromBody] WishListDTO dto, [FromHeader] string token)
        {
            Log.Debug("start UpdateWishList-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _wishListServices.UpdateWishList(dto);
                        return Ok("done to update this");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("Can't updates this WishList");
                    return BadRequest("Can't updates this WishList");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        public async Task<ActionResult> DeleteWishList([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start DeleteWishList-controller{Id}", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _wishListServices.DeleteWishList(Id);
                        return Ok("delete this item in wishlist");

                    }
                    else
                    {
                        return BadRequest( "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        public async Task<IActionResult> GetCartItemById([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start GetCartItemById-controller{Id}", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var CartItem = await _cartItemServices.GetByIdCartItem(Id);
                        return Ok(CartItem);

                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("con not found  CartItem");
                    return BadRequest("con not found  CartItem");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }



        //get all CartItem
        /// <returns>all CartItem</returns>
        /// <response code="400">cann't get the all  CartItem</response>
        [HttpGet]
        [Route("[action]/{CartId}")]
        public async Task<IActionResult> GetAllCartItem([FromHeader] string token, [FromRoute]int CartId)
        {
            Log.Debug("start GetAllCartItem-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var CartItem = await _cartItemServices.GetAllCartItem(CartId);
                        return Ok(CartItem);

                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {

                    Log.Error("con not found  CartItem");
                    return BadRequest("con not found  CartItem");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }

        //get all CartItemReview
        /// <returns>all CartItemReview</returns>
        /// <response code="400">cann't get the all  CartItemReview</response>
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetAllCartItemReview([FromHeader] string token, [FromRoute] int Id)
        {
            Log.Debug("start GetAllCartItemReview-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var CartItem = await _cartItemServices.GetAllCartItemReview(Id);
                        return Ok(CartItem);

                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {

                    Log.Error("con not found  CartItemReview");
                    return BadRequest("con not found  CartItemReview");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        public async Task<IActionResult> NewCartItem([FromBody] CreateCartItemDTO c, [FromHeader] string token)
        {
            Log.Debug("start NewCartItem-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _cartItemServices.CreateCartItem(c);
                        return Ok("create new cart item");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {

                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }

            else
            {
                throw new ArgumentNullException("token");
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
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemDTO dto, [FromHeader] string token)
        {
            Log.Debug("start UpdateCartItem-controller{Id}", dto.CartItemId);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _cartItemServices.UpdateCartItem(dto);
                        return Ok("done to update this CartItem");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("Can't updates this CartItem");
                    return BadRequest("Can't updates this CartItem");
                }
            }

            else
            {
                throw new ArgumentNullException("token");
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
        public async Task<ActionResult> DeleteCartItem([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start DeleteCartItem-controller{Id}", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _cartItemServices.DeleteCartItem(Id);
                        return Ok("delete this CartItem");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }

            else
            {
                throw new ArgumentNullException("token");
            }

        }


        #endregion
        #region Cart
        //get id by Cart
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetCart ById
        ///     {        
        ///       "Id": "Enter the id of Cart" 
        ///     }
        /// </remarks>
        /// <returns>Cart</returns>
        /// <response code="400">cann't get the Cart</response>
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetCartById([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start GetCartById-controller{Id}", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var Cart = await _cartServices.GetByIdCart(Id);
                        return Ok(Cart);
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("can not found  Cart");
                    return BadRequest("can not found  Cart");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
        //get all Cart

        /// <returns>Cart</returns>
        /// <response code="400">cann't get the all  Cart</response>
        [HttpGet]
        [Route("[action]/{UserId}")]
        public async Task<IActionResult> GetCartAll([FromHeader] string token,[FromRoute] int UserId)
        {
            Log.Debug("start GetCartAll-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var Carts = await _cartServices.GetAllCart(UserId);
                        return Ok(Carts);
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("can not found  Carts");
                    return BadRequest("can not found  Carts");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        public async Task<IActionResult> NewCart([FromBody] CartDTO c, [FromHeader] string token)
        {
            Log.Debug("start NewCart-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                     var id=   await _cartServices.CreateCart(c);

                        return Ok(id);

                        Log.Debug("finished CreateCart-Controller");

                    }

                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        public async Task<IActionResult> UpdateCart([FromBody] CardCartDTO c, [FromHeader] string token)
        {
            Log.Debug("start UpdateCart-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _cartServices.UpdateCart(c);
                        return Ok("done to update this cart");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    return BadRequest("Can't updates this Cart");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        [HttpPut]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteCart([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start DeleteCart-controller{Id}", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _cartServices.DeleteCart(Id);
                        return Ok("delete this  Cart");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
        #endregion
        #region ItemRequest
        //get all ItemRequest
        /// <returns>List of ItemRequest</returns>
        /// <response code="400">can not Get All Item Request</response>   
        [HttpGet]
        [Route("[action]/{userId}")]
        public async Task<IActionResult> GetAllItemRequestForUser([FromRoute]int userId)
        {

            try
            {
                Log.Debug("start GetAllItemRequest-controller");
                var ItemRequests = await _itemRequestServices.GetAllItemRequestfromuser(userId);
                return Ok(ItemRequests);

            }
            catch
            {
                Log.Error("con not found  ItemRequest");
                return BadRequest("con not found  ItemRequests");
            }
        }
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
        public async Task<IActionResult> CreateItemRequest([FromBody] ItemRequestDTO i, [FromHeader] string token)
        {
            Log.Debug("start CreateItemRequest-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _itemRequestServices.CreateItemRequest(i);
                        return Ok( "done to add New  item request ");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }

        //update Item Request
        // <summary>
        /// Updates an existing ItemRequest.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/UpdateItemRequest
        ///     {
        ///         "ItemRequestId": 1,
        ///         "Title": "Sample Item Title",
        ///         "Description": "This is a sample description for the item.",
        ///         "Image": "http://example.com/sample-image.jpg",
        ///         "CategoryId": 2
        ///     }
        /// </remarks>
        /// <response code="400">Cannot update the ItemRequest.</response>
        /// <response code="404">ItemRequest not found.</response>
        /// <response code="200">ItemRequest updated successfully.</response>

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateItemRequest([FromBody] CardItemRequestDTO dto, [FromHeader] string token)
        {
            Log.Debug("start UpdateItemRequest-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _itemRequestServices.UpdateItemRequest(dto);
                        return Ok("Update item Request");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("Can't updates this item Request");
                    return BadRequest("Can't updates this item Request");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        /// <param name="Id">The ID of the ItemRequest to delete</param>
        /// <response code="201"> delete the ItemRequest</response>
        /// <response code="400">cann't delete the ItemRequest</response>
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteItemRequest([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start DeleteItemRequest-controller{Id}", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _itemRequestServices.DeleteItemRequest(Id);
                        return Ok("done to delete this item request ");
                    }

                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
        #endregion
        #region  ProductWarranty
        // Get Product Warranty by ID
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET api/GetProductWarrantyById/{Id}
        /// </remarks>
        /// <param name="Id">The ID of the product warranty to retrieve.</param>
        /// <returns>Returns the product warranty with the specified ID.</returns>
        /// <response code="200">Returns the product warranty.</response>
        /// <response code="404">Cannot find the product warranty with the specified ID.</response>
        /// <response code="400">Cannot retrieve the product warranty due to a bad request.</response>
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetProductWarrantyById([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("Start GetProductWarrantyById-controller {Id}", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                         var productWarranty=  await _service.GetProductWarrantyById(Id);
                         return Ok(productWarranty);
                    }
                
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error occurred while retrieving ProductWarranty with ID {Id}", Id);
                    return BadRequest("Cannot retrieve the product warranty");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
        // Get all Product Warranties
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET api/GetAllProductWarranties
        /// </remarks>
        /// <returns>Returns a list of all product warranties.</returns>
        /// <response code="200">Returns the list of all product warranties.</response>
        /// <response code="404">No product warranties found.</response>
        /// <response code="400">Cannot retrieve product warranties due to a bad request.</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProductWarranties([FromHeader] string token)
        {
            Log.Debug("Start GetAllProductWarranties-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var productWarranties = await _service.GetAllProductWarranties();
                        if (productWarranties == null || !productWarranties.Any())
                        {
                            Log.Warning("No product warranties found");
                            return NotFound("No product warranties found");
                        }
                        return Ok(productWarranties);
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error occurred while retrieving all product warranties");
                    return BadRequest("Cannot retrieve product warranties");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }

        }

        #endregion
        #region Raview
        //get id by Raview
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetRaview ById
        ///     {        
        ///       "Id": "Enter the id of Raview" 
        ///     }
        /// </remarks>
        /// <returns>Cart</returns>
        /// <response code="400">cann't get the Raview</response>
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetRaviewById([FromRoute] int Id)
        {
            Log.Debug("start GetRaviewById-controller{Id}", Id);
          
                try
                {
                   
                        var Rating = await _rating.GetByIdRaview_Repose(Id);
                        return Ok(Rating);
                   
                }
                catch
                {
                    Log.Error("can not found  Rating");
                    return BadRequest("can not found  Rating");
                }
         
        }
        //get all Raview

        /// <returns>Raview</returns>
        /// <response code="400">cann't get the all  Raview</response>
        [HttpGet]
        [Route("[action]/{ItemId}")]
        public async Task<IActionResult> GetRaviewAll([FromRoute]int ItemId)
        {
            Log.Debug("start GetCartAll-controller");
         
                try
                {
                    
                        var rating = await _rating.GetAllRaview_Repose(ItemId);
                        return Ok(rating);
                    
                   
                }
                catch
                {
                    Log.Error("can not found  _rating");
                    return BadRequest("can not found  _rating");
                }
            }


        //greate Raview
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/NewRaview
        ///     {        
        ///        UserId : "Enter the id of user the Cart to add order" 
        ///        OrderId : "Enter the id of   Order the need to add in Cart" 
        ///        IsActive: "Enter the true or false if the cart is active " 
        /// }   
        /// </remarks>
        /// <returns>cartItem</returns>
        /// <response code="201">add the Raview</response>
        /// <response code="400">cann't add the Raview</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewRaview([FromBody]  CreateRaviewDTO dto, [FromHeader] string token)
        {
            Log.Debug("start NewRaview-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                         await _rating.CreateRaview_Repose(dto);

                        return Ok("Raview viw");

                        Log.Debug("finished CreateRaview-Controller");

                    }

                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
        //update Raview
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateRaview
        ///     {        
        ///         Id: "Enter the id of cart that need to update" 
        ///        UserId : "Enter the id of user the Cart to add order" 
        ///        OrderId : "Enter the id of   Order the need to add in Cart" 
        ///        IsActive: "Enter the true or false if the cart is active " 
        ///     }
        /// </remarks>
        /// <response code="400">cann't Update the Raview</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateRaview([FromBody] CradRaviewDTO d, [FromHeader] string token)
        {
            Log.Debug("start UpdateRaview-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _rating.UpdateRaview_Repose(d);
                        return Ok("done to update this Raview");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    return BadRequest("Can't updates this Raview");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
        //delete Raview
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteRaview
        ///     {        
        ///       "Id": "Enter the id of  Raview to delete" 
        ///     }
        /// </remarks>
        /// <response code="201"> delete the Raview</response>
        /// <response code="400">cann't delete the Raview</response>
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteReview([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start DeleteRaviewg_Repose", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _rating.DeleteRaview_Repose(Id);
                        return Ok("delete this  Rating");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
        #endregion

    }
}

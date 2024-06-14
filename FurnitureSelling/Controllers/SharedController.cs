﻿using FurnitureSellingCore.DTO.Authantication;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics.Eventing.Reader;
using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IItemServices _ItemServices;
        private readonly IItemRequestServices _itemRequestServices;
        private readonly IOrderServices _OrderServices;
        private readonly ICategoryServices _CategoryServices;

        public SharedController(IItemServices ItemServices, IUserServices userServices, IItemRequestServices itemRequestServices, ICategoryServices CategoryServices, IOrderServices OrderServices)
        {
            _userServices = userServices;
            _ItemServices = ItemServices;
            _itemRequestServices = itemRequestServices;
            _CategoryServices = CategoryServices;
            _OrderServices = OrderServices;
        }
        #region Authentication
        //login

        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/login
        ///     {        
        ///       "ID": "Enter Your ID to login",   
        ///     }
        /// </remarks>
        /// <returns>Login</returns>
        /// <response code="400">can not loggin</response>       
        [HttpPut]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> login([FromRoute]int Id)
        {
            try
            {
                Log.Debug("start login-controller{Id}", Id);
                await _userServices.Login(Id);
                return Ok("login");

            }
            catch 
            {   
                Log.Error("Can't login");
                return BadRequest("Can't login");
            }
        }
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/logout
        ///     {        
        ///       "ID": "Enter Your ID to logout",   
        ///     }
        /// </remarks>
        /// <returns>logout</returns>
        /// <response code="400">can not logout</response>       
        //logout
        [HttpPut]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> logout([FromRoute]int Id)
        {
            try
            {
                Log.Debug("start logout-controller{Id}", Id);
                var logout = _userServices.Logout(Id);
                return Ok("logout is done ");

            }
            catch
            {
                Log.Error($"Can't  Logged");
                return BadRequest("Can't logout");
            }
        }
        //restpassword

        /// <remarks>
        /// Sample restpassword:
        /// 
        ///     Put api/login
        ///     {        
        ///       "ID"         : "Enter Your ID to Login", 
        ///       "NewPassword": "Enter NewPassword to Login", 
        ///     }
        /// </remarks>
        /// <returns>new pass</returns>
        /// <response code="400">can not rest password</response>     
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> restpassword([FromBody] ResetPasswordDTO dto)
        {
            try
            {
                Log.Debug("start restpassword-controller");
                var logout = _userServices.ResetPassword(dto);
                return Ok("create new password");

            }
            catch 
            {
                Log.Error("Can't rest password");
            return BadRequest("Can't rest password");
            }
        }
        #endregion
        #region Order
        //get id by order
        /// <remarks>
        /// Sample request:
        /// 
        ///    Get api/GetOrder
        ///     {        
        ///       "ID": "Enter order ID to Get Order" 
        ///     }
        /// </remarks>
        /// <returns>Order</returns>
        /// <response code="400">can not Get Order</response>   
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetOrder([FromRoute] int Id)
        {
          
                try
            {
                Log.Debug("start GetOrder-controller");
                var Order = await _OrderServices.GetByIdOrder(Id);
                    return Ok(Order);

                }
                catch
                {Log.Error("not found this order");
                    return BadRequest("not found this Order");
                }
            }
        //get all order
        /// <returns>AllOrder</returns>
        /// <response code="400">Cann't Get All Order</response>   
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllOrder()
        {

            try
            {
                Log.Debug("start GetAllOrder-controller");
                var Order = await _OrderServices.GetAllOrder();
                return Ok(Order.ToList()); ;

            }
            catch
            {
                Log.Error("can not found orders");
                return BadRequest("can not found orders");
            }
        }

        //greate order
        /// <response code="201">add Order</response>  
        /// <response code="400">can not create Order</response>  
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO dto)
        {
           
                try
                {
                Log.Debug("start CreateOrder-controller");
                await _OrderServices.CreateOrder(dto);
                    return StatusCode(201, "done to add new  Order ");


                }
                catch (Exception ex)
                {
                Log.Error($"Error {ex.Message}", ex);
                    return BadRequest(ex.Message);
                }
         
        }

        //update Order
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateOrder
        ///     {        
        ///       "ID": "Enter Your ID to Update Order" 
        ///     }
        /// </remarks>
        /// <response code="400">can not Update Order</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateOrder([FromBody] DetailsOrdertDTO dto)
        {
            try
            {
                Log.Debug("start UpdateOrder-controller{Id}",dto.Id);
                await _OrderServices.UpdateOrder(dto);
                return Ok("Update Order");

            }
            catch 
            {
                Log.Error("Can't updates this profile");
                return BadRequest("Can't updates this profile");
            }
        }
        //delete order
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteOrder
        ///     {        
        ///       "ID": "Enter Your ID to delete Order" 
        ///     }
        /// </remarks>
        /// <response code="204">done to delete this Order</response>  
        /// <response code="400">can not Delete this  Order</response>  
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteOrder([FromRoute] int Id)
        {

            try
            {
                Log.Debug("start DeleteOrder-controller{Id}", Id);
                await _OrderServices.DeleteOrder(Id);
                return StatusCode(204, "done to delete this Order ");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return BadRequest(ex.Message);
            }
        }

        #endregion
        #region user
        //get id by user
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetProfile([FromRoute] int Id)
        {
         
                try
                 {
                       Log.Debug("start GetProfile-controller{Id}", Id);
                       var profile = await _userServices.GetByIdUser(Id);
                       return Ok(profile);

                }
                catch 
                {
                        Log.Error("can not found this profile");
                        return BadRequest("can not found this profile");
                }
           
        }
        //get all user
        /// <returns>List of User</returns>
        /// <response code="400">can not Get All User</response> 
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUsers()
        {

            try
            {
                   Log.Debug("start GetUsers-controller");
                   var profile = await _userServices.GetAllUser();
                   return Ok(profile.ToList());

            }
            catch
            {
                   Log.Error("can not found all user");
                   return BadRequest("can not found all user");
            }
        }



        //greate user  
        /// <response code="201"> add new user</response>  
        /// <response code="400">can not add new user</response>  
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewProfile([FromBody] CreateUserDTO dto)
        {
             try
                {
                         Log.Debug("start NewProfile-controller");
                         await _userServices.CreateUser(dto);
                         return StatusCode(201, "done to add this user");
                }
                catch (Exception ex)
                {
                        Log.Error(ex.Message);
                        return BadRequest(ex.Message);
                }
      
        }
        //update user
        //get id by order
        /// <remarks>
        /// Sample request:
        /// 
        ///    Put api/UpdateProfile
        ///     {        
        ///       "ID": "Enter Your ID to Update Profile" 
        ///     }
        /// </remarks>
        /// <response code="400">can not Update Profile</response>   
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProfile(DetailsUserDTO dto)
        {
            try
            {
                        Log.Debug("start UpdateProfile-controller");
                       await _userServices.UpdateUser(dto);
                       return Ok("done to updates this profile");
            }
            catch 
            {
                Log.Error("Can't updates this profile");
                return BadRequest("Can't updates this profile");
            }
        }

        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteAccout
        ///     {        
        ///       "ID": "Enter Your ID to delete profile" 
        ///     }
        /// </remarks>
       /// <response code="204">Delete this  profile</response> 
        /// <response code="400">can not Delete this  profile</response> 
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteAccount([FromRoute] int Id)
        {

            try
            {
                    Log.Debug("start DeleteAccount-controller",Id);
                    await _userServices.DeleteUser(Id);
                    return StatusCode(204, "done to delete this record");
            }
            catch (Exception ex)
            {
                    Log.Error($"{ex.Message}");
                    return BadRequest(ex.Message);
            }
        }
        #endregion
        #region Category
        //get id by Category
        /// <remarks>
        /// Sample request:
        /// 
        ///    Get api/GetCategory
        ///     {        
        ///       "ID": "Enter Your ID to Get Category" 
        ///     }
        /// </remarks>
        /// <returns>Order</returns>
        /// <response code="400">can not Get Category</response>   
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCategory([FromRoute]int Id)
        {
            
                try
                {
                     Log.Debug("start GetCategory-controller", Id);
                     var Category = await _CategoryServices.GetByIdCategory(Id);
                     return Ok(Category);

                }
                catch
                {
                     Log.Error($"Could not find category: {Id}");
                     return BadRequest("can not found this Category");
                }
          

        }

        //get all Category
        /// <returns>List of Category</returns>
        /// <response code="400">can not Get All Item Request</response> 
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCategory()
        {

            try
            {
                Log.Debug("start GetAllCategory-controller");
                var Categorys = await _CategoryServices.GetAllCategory();
                return Ok(Categorys.ToList());

            }
            catch
            {
                Log.Error("con not found  Categories");
                return BadRequest("con not found  Categories");
            }
        }


        #endregion
        #region Item
        //get id by Item
        /// <returns>Item</returns>
        /// <response code="400">can not Get  Item </response> 
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetItemById([FromRoute]int Id)
        {
                try
                {
                       Log.Debug("start GetItemById-controller", Id);
                       var Item = await _ItemServices.GetByIdItem(Id);
                       return Ok(Item);

                }
                catch 
                {
                       Log.Error("not found this Item");
                       return BadRequest("not found this Item");
                }


        }

        //get all Item
        /// <returns>List of Item</returns>
        /// <response code="400">can not Get All Item </response> 
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllItem()
        {

            try
            {
                Log.Debug("start GetAllItem-controller");
                var AllItem = await _ItemServices.GetAllItem();
                return Ok(AllItem.ToList());

            }
            catch 
            {Log.Error("can not found  Item");
                return BadRequest("can not found  Item");
            }
        }

        // Search Item 
        /// <returns>Item</returns>
        /// <response code="400">can not Get Item</response>   
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SearchItem(string? name, string? description, int? price)
        {
            try
            {
                Log.Debug("start SearchItem-controller");
                var i = await _ItemServices.SearchItem(name, description, price);
                return Ok(i);
            }
            catch 
            {Log.Error("can not found  Item");
                return BadRequest("can not found  Item");
            }

        }


        #endregion
        #region Item Request
        //Get by Id Item Request
        /// <returns> Item Request</returns>
        /// <response code="400">can not Get  Item Request</response> 
            [HttpGet]
            [Route("[action]")]
            public async Task<IActionResult> GetItemRequestById([FromRoute]int Id)
            {
                try
                {
                    Log.Debug("start GetItemRequestById-controller",Id);
                    var it = await _itemRequestServices.GetByIdItemRequest(Id);
                    return Ok(it);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex.Message);
                }
            }

        //get all ItemRequest
        /// <returns>List of ItemRequest</returns>
        /// <response code="400">can not Get All Item Request</response>   
                 [HttpGet]
                 [Route("[action]")]
                     public async Task<IActionResult> GetAllItemRequest()
                     {

                          try
                          {
                                   Log.Debug("start GetAllItemRequest-controller");
                                   var ItemRequests = await _itemRequestServices.GetAllItemRequest();
                                   return Ok(ItemRequests);
                              
                          }
                          catch
                          {
                                   Log.Error("con not found  ItemRequest");
                                   return BadRequest("con not found  ItemRequests");
                          }
                     }
        #endregion
      
       
   
}




}
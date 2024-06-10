using FurnitureSellingCore.DTO.Authantication;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        [Route("[action]/{id}")]
        public async Task<IActionResult> login([FromRoute]int id)
        {
            try
            {
                await _userServices.Login(id);
                return Ok("login");

            }
            catch (Exception ex)
            {

                return BadRequest("Con't login");
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
        [Route("[action]/{id}")]
        public async Task<IActionResult> logout([FromRoute]int id)
        {
            try
            {
                var logout = _userServices.Logout(id);
                return Ok("logout is done ");

            }
            catch (Exception ex)
            {

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
        /// <response code="400">can not restpassword</response>     
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> restpassword([FromBody] ResetPasswordDTO dto)
        {
            try
            {
                var logout = _userServices.ResetPassword(dto);
                return Ok("create new password");

            }
            catch (Exception ex)
            {

                return BadRequest("Can't restpassword");
            }
        }
        #endregion
        #region Order
        // Managment order
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
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetOrder([FromRoute] int id)
        {
            if (id != null)
            {
                try
                {
                    var Order = await _OrderServices.GetByIdOrder(id);
                    return Ok(Order);

                }
                catch (Exception ex)
                {
                    return BadRequest("not found this Order");
                }
            }
            else
            {
                return BadRequest("the id is emptye");
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
                var Order = await _OrderServices.GetAllOrder();
                return Ok(Order.ToList()); ;

            }
            catch
            {
                return BadRequest("not found this profile");
            }
        }

        //greate order
        /// <response code="400">can not create Order</response>  
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO dto)
        {
            if (dto != null)
            {
                try
                {
                    await _OrderServices.CreateOrder(dto);
                    return Ok("New Order has Created");

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Please Full All Data");
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
        public async Task<IActionResult> UpdateOrder([FromBody] DetailsOrdertDTO dto, int? userType)
        {
            try
            {
               await _OrderServices.UpdateOrder(dto, userType);
                return Ok("Update Order");

            }
            catch 
            {

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
        /// <response code="400">can not Delete this  Order</response>  
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteOrder([FromRoute] int id)
        {

            try
            {
                await _OrderServices.DeleteOrder(id);
                return Ok("delete this Order");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
        #region user
        //get id by user
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetProfile([FromRoute] int id)
        {
            if (id != null)
            {
                try
                {
                    var profile = await _userServices.GetByIdUser(id);
                    return Ok(profile);

                }
                catch 
                {
                    return BadRequest("not found this profile");
                }
            }
            else
            {
                return BadRequest("the id is empty");
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
                var profile = await _userServices.GetAllUser();
                return Ok(profile.ToList());

            }
            catch
            {
                return BadRequest("not found this profile");
            }
        }



        //greate user
        /// <response code="400">can not add new user</response>  
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewProfile([FromBody] CreateUserDTO dto)
        {
            if (dto != null)
            {
                try
                {
                    await _userServices.CreateUser(dto);
                    return Ok("New Account has Created");

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Please Full All Data");
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
                var user = _userServices.UpdateUser(dto);
                return Ok("done to updates this profile");

            }
            catch 
            {

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
        /// <response code="400">can not Delete this  profile</response> 
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteAccount([FromRoute] int id)
        {

            try
            {
                await _userServices.DeleteUser(id);
                return Ok("delete this record");
            }
            catch (Exception ex)
            {
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
        public async Task<IActionResult> GetCategory([FromRoute]int id)
        {
            if (id != null)
            {
                try
                {
                    var Category = await _CategoryServices.GetByIdCategory(id);
                    return Ok(Category);

                }
                catch (Exception ex)
                {
                    return BadRequest("not found this Category");
                }
            }
            else
            {
                return BadRequest("please enter id ");
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
                var Categorys = await _CategoryServices.GetAllCategory();
                return Ok(Categorys.ToList());

            }
            catch
            {
                return BadRequest("con not found  Categorys");
            }
        }


        #endregion
        #region Item
        //get id by Item
        /// <returns>Item</returns>
        /// <response code="400">can not Get  Item </response> 
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetItemById([FromRoute]int id)
        {
            if (id != null)
            {
                try
                {
                    var Item = await _ItemServices.GetByIdItem(id);
                    return Ok(Item);

                }
                catch 
                {
                    return BadRequest("not found this Item");
                }
            }
            else
            {
                return BadRequest("the id is empty");
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
                var AllItem = await _ItemServices.GetAllItem();
                return Ok(AllItem.ToList());

            }
            catch 
            {
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
              var i= await _ItemServices.SearchItem(name, description, price);
                return Ok(i);
            }
            catch 
            {
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
                var it = await _itemRequestServices.GetByIdItemRequest(Id);
                return Ok(it);
            }
            catch (Exception ex)
            {
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
                      var ItemRequests = await _itemRequestServices.GetAllItemRequest();
                      return Ok(ItemRequests);

                  }
                  catch
                  {
                      return BadRequest("con not found  ItemRequests");
                  }
              }
        #endregion
      
       
   
}




}
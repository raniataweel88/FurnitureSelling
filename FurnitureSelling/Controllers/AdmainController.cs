using FurnitureSellingCore.DTO.Catagory;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.ItemRequest;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FurnitureSelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmainController : ControllerBase
    {
      private  readonly IItemServices _itemServices;
      private readonly IUserServices _UserServices;
        private readonly ICategoryServices _CategoryServices;
        private readonly IItemRequestServices _ItemRequestServices;

        public AdmainController(IItemServices ItemServices, IUserServices UserServices, ICategoryServices CategoryServices,IItemRequestServices ItemRequestservices)
        {
            _itemServices = ItemServices;
            _UserServices = UserServices;
            _CategoryServices = CategoryServices;
            _ItemRequestServices = ItemRequestservices;
        }

        #region Category

        //greate Category
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/NewCategory
        ///     {        
        ///       "Title": "Enter the name of category" 
        ///     }
        /// </remarks>
        /// <returns>new Category</returns>
       /// <response code="201"> add new Category</response>
        /// <response code="400">can not add Category</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewCategory([FromBody] CategoryDTO c)
        {
            try
            {
                Log.Debug("start NewCategory-controller");
                await _CategoryServices.CreateCategory(c);
                return StatusCode(201, " add new  Category");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);

            }

        }
        //update Category
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateCategory
        ///     {        
        ///       "ID": "Enter Your ID that need to Update" 
        ///      "Title": "Enter Your name of Category to update" 
        ///     }
        /// </remarks>
        /// <returns>Update Category</returns>
        /// <response code="400">can not Update Category</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCategory([FromBody] CardCategoryDTO dto)
        {

            try
            {
                Log.Debug("start UpdateCategory-controller{id}",dto.Id);
                await _CategoryServices.UpdateCategory(dto);
                return Ok("update this Category");

            }
            catch
            {
                Log.Error("Can't updates this Category");
                return BadRequest("Can't updates this Category");
            }

        }
        //delete Category
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteCategory
        ///     {        
        ///       "ID": "Enter Your ID to Delete Category" 
        ///     }
        /// </remarks>
        /// <returns>Delete Category</returns>
        /// <response code="400">can not Delete Category</response>
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteCategory([FromRoute] int Id)
        {
            Log.Debug("start DeleteCategory-controller {id}", Id);

            try
            {
              await  _CategoryServices.DeleteCategory(Id);
                return StatusCode(204, "delete this Category");


            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
        #endregion
        #region Item

        //greate Item
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/NewItem
        ///     {  
        ///      Name :"Enter the name of item" 
        ///      Description :"Enter the details of item" 
        ///      Image :"add the img" 
        ///       Price: "add the Price of item" 
        ///       Category :"add the Category of this item" 
        /// <returns>new Category</returns>
        /// <response code="201">Create New Item</response>
        /// <response code="400">can not add Item</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewItem([FromBody] CreateItemDTO c)
        {
            try
            {
                Log.Debug("start NewItem-controller");
                await _itemServices.CreateItemServices(c);
                return StatusCode(201, " create new  item");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);   
                return BadRequest(ex.Message);

            }
        }

        //update Item
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateItem
        ///     {   
        ///      "ID": "Enter Your ID of item to Update " 
        ///      Name :"Enter the name of item" 
        ///      Description :"Enter the details of item" 
        ///      Image :"add the img" 
        ///      Price: "add the Price of item" 
        ///      Category :"add the Category of this item" 
        ///     }
        /// </remarks>
        /// <returns>Update Item</returns>
        /// <response code="400">Cann't update item</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateItem([FromBody] DetailsItemDTO dto)
        {
            try
            {
                Log.Debug("start UpdateItem-controller {id}", dto.ItemId);
                await _itemServices.Updateitem(dto);
                return Ok("Update this Item");

            }
            catch 
            {
                Log.Error("Can't updates this Item", dto.ItemId);
                return BadRequest("Can't updates this Item");
            }
        }
        //delete Item
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteItem
        ///     {        
        ///       "ID": "Enter Your ID to Delete Item" 
        ///     }
        /// </remarks>
        /// <returns>Delete Item</returns>
       /// <response code="204"> Delete this item</response>
        /// <response code="400">Cann't Delete Item</response>

        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteItem([FromRoute] int Id)
        {
            Log.Debug("start DeleteItem-controller", Id);
            try
            {
                await _itemServices.DeleteItem(Id);
                Log.Information("try DeleteItem-controller");
                return StatusCode(204, "delete this Item");

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region user
        //get all user
        /// <returns>All user </returns>
        /// <response code="400">Cann't Get All user</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                Log.Debug("start GetUsers-controller");
                var user = await _UserServices.GetAllUser();
                Log.Information($"User: {user}");
                return Ok(user);

            }
            catch
            {
                Log.Error("can not found  users");
                return BadRequest("can not found  users");
            }
        }


        //delete user
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteUser
        ///     {        
        ///       "ID": "Enter Your ID to Delete  User" 
        ///     }
        /// </remarks>
        /// <returns>Delete User</returns>
        /// <response code="204"> Delete this User</response>
        /// <response code="400">Cann't Delete User</response>

        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int Id)
        {


            try
            {
                Log.Debug("start DeleteUser-controller{ID}", Id);
                await _UserServices.DeleteUser(Id);
                return StatusCode(204, "delete this User");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        #endregion
        //response of item request
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateItemRequest
        ///     {        
        ///       "ID": "Enter Your Id for this item request" 
        ///      "price": "Enter Your price for this item request" 
        ///      "Note": "Enter Your Note for this item request" 
        ///     }
        /// </remarks>
        /// <response code="400">can not response item</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateItemRequest([FromBody] ItemRequestFromAdmain dto)
        {

            try
            {
                Log.Debug("start UpdateItemRequest-controller{id}", dto.Id);
                await _ItemRequestServices.UpdateItemFromAdmain(dto);
                return Ok("response Item Request");

            }
            catch
            {
                Log.Error("Can't response this item requst");
                return BadRequest("Can't updates this response");
            }

        }
      
    }
}
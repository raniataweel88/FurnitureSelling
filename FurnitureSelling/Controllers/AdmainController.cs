using FurnitureSellingCore.DTO.Catagory;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureSelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmainController : ControllerBase
    {
      private  readonly IItemServices _itemServices;
      private readonly IUserServices _UserServices;
        private readonly ICategoryServices _CategoryServices;
        public AdmainController(IItemServices itemServices, IUserServices UserServices, ICategoryServices CategoryServices)
        {
            _itemServices = itemServices;
            _UserServices = UserServices;
            _CategoryServices = CategoryServices;
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
        /// <response code="400">can not add Category</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewCategory([FromBody] CategoryDTO c)
        {
            try
            {
                await _CategoryServices.CreateCategory(c);
                return Ok();
            }
            catch (Exception ex)
            {
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
             await  _CategoryServices.UpdateCategory(dto);
                return Ok("update this Category");

            }
            catch
            {

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
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteCategory([FromRoute] int id)
        {

            try
            {
              await  _CategoryServices.DeleteCategory(id);
                return Ok("delete this Category");
            }
            catch (Exception ex)
            {
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
        /// <response code="400">can not add Item</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewItem([FromBody] CreateItemDTO c)
        {
            try
            {
                await _itemServices.CreateItemServices(c);
                return Ok("create new item");
            }
            catch (Exception ex)
            {
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
                await _itemServices.Updateitem(dto);
                return Ok("Update this Item");

            }
            catch 
            {

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
        /// <response code="400">can not Delete Item</response>

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteItem([FromRoute] int id)
        {

            try
            {
                await _itemServices.DeleteItem(id);
                return Ok("delete this Item");
            }
            catch (Exception ex)
            {
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
                var user = await _UserServices.GetAllUser();
                return Ok(user);

            }
            catch
            {
                return BadRequest("not found  users");
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
        /// <response code="400">can not Delete User</response>

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {

            try
            {
                await _UserServices.DeleteUser(id);
                return Ok("delete this user");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion




    }
}
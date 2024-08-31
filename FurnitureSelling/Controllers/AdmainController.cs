using FurnitureSellingCore.DTO.Catagory;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.ItemRequest;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.DTO.ProductWarranty;
using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.helper;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FurnitureSelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmainController : ControllerBase
    {
        private readonly IItemServices _itemServices;
        private readonly IUserServices _UserServices;
        private readonly ICategoryServices _CategoryServices;
        private readonly IItemRequestServices _ItemRequestServices;
        private readonly IProductWarrantyServies IProductWarrantyServies;


        public AdmainController(IItemServices ItemServices, IUserServices UserServices, ICategoryServices CategoryServices, IItemRequestServices ItemRequestservices, IProductWarrantyServies service)
        {
            _itemServices = ItemServices;
            _UserServices = UserServices;
            _CategoryServices = CategoryServices;
            _ItemRequestServices = ItemRequestservices;
            IProductWarrantyServies = service;
        }

        #region Category
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> home( [FromHeader] string token)
        {

            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                      var e=  await _CategoryServices.Expectations();
                        return Ok(e);

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
        public async Task<IActionResult> NewCategory([FromBody] CategoryDTO c, [FromHeader] string token)
        {
            Log.Debug("start NewCategory-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _CategoryServices.CreateCategory(c);
                        return StatusCode(201, " add new  Category");

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
        public async Task<IActionResult> UpdateCategory([FromBody] CardCategoryDTO dto, [FromHeader] string token)
        {

            Log.Debug("start UpdateCategory-controller{id}", dto.Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _CategoryServices.UpdateCategory(dto);
                        return Ok("update this Category");

                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }

                }
                catch 
                {

                    Log.Error("Can't updates this Category");
                    return BadRequest("Can't updates this Category");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        public async Task<ActionResult> DeleteCategory([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start DeleteCategory-controller {id}", Id);

            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                       await _CategoryServices.DeleteCategory(Id);
                    return StatusCode(201, "delete this Category");

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

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewUserAdmain([FromBody] DetailsUserAdmainDTO dto, [FromHeader] string token)
        {
            Log.Debug("start Newuser-controller");

            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {

                        await _UserServices.CreateUserAdmain(dto);
                        return Ok( " create new  user");
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
        ///       }
        /// <returns>new Category</returns>
        /// <response code="201">Create New Item</response>
        /// <response code="400">can not add Item</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewItem([FromBody] CreateItemDTO dto, [FromHeader] string token)
        {
            Log.Debug("start NewItem-controller");

            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {

                        await _itemServices.CreateItemServices(dto);
                        return StatusCode(201, " create new  item");
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
        public async Task<IActionResult> UpdateItem([FromBody] DetailsItemDTO dto, [FromHeader] string token)
        {
            Log.Debug("start UpdateItem-controller {id}", dto.ItemId);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {

                        await _itemServices.Updateitem(dto);
                        return Ok("Update this Item");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }

                }
                catch 
                {
                    Log.Error("Can't updates this Item", dto.ItemId);
                    return BadRequest("Can't updates this Item");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        
    }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> AddDiscountForItem([FromBody] DiscountItemDTO i, [FromHeader] string token)
        {
            Log.Debug("start DiscountItem-controller {id}", i.ItemId);
 
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {


                        await _itemServices.DiscountItem(i);
                        return Ok("add  Discount of this Item");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }

                }
                catch
                {
                    Log.Error("Can't add  Discount of this Item", i.ItemId);
                    return BadRequest("Can't add  Discount of this Item");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
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
        /// <response code="201"> Delete this item</response>
        /// <response code="400">Cann't Delete Item</response>

        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteItem([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start DeleteItem-controller", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token)) { 
                        await _itemServices.DeleteItem(Id);
                    Log.Information("try DeleteItem-controller");
                    return StatusCode(201, "delete this Item");
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
        #region user

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
        /// <response code="201"> Delete this User</response>
        /// <response code="400">Cann't Delete User</response>

        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start DeleteUser-controller{ID}", Id);

            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _UserServices.DeleteUser(Id);
                        return StatusCode(201, "delete this User");
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
        public async Task<IActionResult> UpdateItemRequest([FromBody] ItemRequestFromAdmain dto, [FromHeader] string token)
        {
            Log.Debug("start UpdateItemRequest-controller{id}", dto.ItemRequestId);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _ItemRequestServices.UpdateItemFromAdmain(dto);
                        return Ok("response Item Request");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }

                }
                catch
                {

                    Log.Error("Can't response this item requst");
                    return BadRequest("Can't updates this response");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }

        }
        #region  ProductWarranty
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateProductWarranty
        ///     {
        ///       "ItemId": 101,
        ///       "WarrantyCode": "SampleCode",
        ///       "WarrantyStartDate": "2024-01-01T00:00:00",
        ///       "WarrantyEndDate": "2025-01-01T00:00:00"
        ///     }
        /// </remarks>
        /// <returns>Create Product Warranty</returns>
        /// <response code="201">Product warranty created successfully</response>
        /// <response code="400">Cannot create product warranty</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProductWarranty([FromBody] CreateProductWarrantyDTO dto, [FromHeader] string token)
        {
            Log.Debug("Start CreateProductWarranty-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await IProductWarrantyServies.CreateProductWarranty(dto);
                        return StatusCode(201, "Created new product warranty");
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
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT api/UpdateProductWarranty
        ///     {
        ///       "ProductWarrantyId": 1,
        ///       "ItemId": 101,
        ///       "WarrantyCode": "UpdatedCode",
        ///       "WarrantyStartDate": "2024-01-01T00:00:00",
        ///       "WarrantyEndDate": "2025-01-01T00:00:00"
        ///     }
        /// </remarks>
        /// <returns>Update Product Warranty</returns>
        /// <response code="204">Product warranty updated successfully</response>
        /// <response code="400">Cannot update product warranty</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProductWarranty([FromBody] ProductWarrantyDTO dto, [FromHeader] string token)
        {
            Log.Debug("Start UpdateProductWarranty-controller {id}", dto.ProductWarrantyId);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await IProductWarrantyServies.UpdateProductWarranty(dto);
                        return Ok("Product warranty updated successfully");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }

                catch
                {
                    Log.Error("Cannot update the product warranty");
                    return BadRequest("Cannot update the product warranty");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteProductWarranty/{Id}
        ///     {        
        ///       "ID": "Enter Your ID to Delete Product Warranty" 
        ///     }
        /// </remarks>
        /// <returns>Delete Product Warranty</returns>
        /// <response code="201"> Delete this product warranty</response>
        /// <response code="400">Cannot delete product warranty</response>
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> DeleteProductWarranty([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("Start DeleteProductWarranty-controller", Id);
        
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await IProductWarrantyServies.DeleteProductWarranty(Id);
                        Log.Information("Successfully deleted product warranty");
                        return StatusCode(201, "Deleted this product warranty");
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
    }
   
   

    #endregion
}

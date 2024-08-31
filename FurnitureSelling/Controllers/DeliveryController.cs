using FurnitureSellingCore.DTO.Order.Delivery;
using FurnitureSellingCore.helper;
using FurnitureSellingCore.IServices;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FurnitureSelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IOrderServices _service;

        public DeliveryController(IOrderServices services)
        {
            _service = services;
         
        }

        //get id by order
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetOrderByDeliveryId
        ///     {        
        ///       "Id": "Enter the id of Cart" 
        ///     }
        /// </remarks>
        /// <returns>order</returns>
        /// <response code="400">cann't get the Order</response>
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetordertByDeliveryId([FromRoute] int Id, [FromHeader] string token)
        {
            Log.Debug("start GetCartById-controller{Id}", Id);
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var order = await _service.GetByIdOrder_Delivary(Id);
                        return Ok(order);
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
        //get all order
        /// <returns>Order</returns>
        /// <response code="400">cann't  get the all  Order</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllOrderbyDelivery([FromHeader] string token)
       {
            Log.Debug("start GetAllOrderbyDelivery-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var d = await _service.GetAllOrderforDelivery();
                        return Ok(d.ToList());
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("can not get this order");
                    return BadRequest("can not get this order");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
        //update order
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateOrder
        ///     {        
        ///       "ID": "Enter Your ID to Update Order" 
        ///       "StatusDelivery":if user receive 
        ///     }
        /// </remarks>
        /// <response code="400">can not Update Order</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateOrderbyDelivery([FromBody] DeliveryOrder_updatetDTO dto, [FromHeader] string token)
        {
            Log.Debug("start UpdateOrderbyDelivery-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        await _service.UpdateOrderforDelivery(dto);
                        return Ok("done to update this order");
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("can not update this order");
                    return BadRequest("can not update this order");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
        //serach by address
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/SearchDelivery
        ///     {        
        ///       "Address": "Enter the address of user to search" 
        ///     }
        /// </remarks>
        /// <returns>order</returns>
        /// <response code="400">cann't get the Order</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SearchDelivery(string? address, [FromHeader] string token)
        {
            Log.Debug("start SearchDelivery-controller");
            if (token != null)
            {
                try
                {
                    if (TokenHelper.IsVaildToken(token))
                    {
                        var d = await _service.SearchOrderforDelivery(address);
                        return Ok(d);
                    }
                    else
                    {
                        return StatusCode(401, "you unatharized to use this function");
                    }
                }
                catch
                {
                    Log.Error("can not get this address");
                    return BadRequest("can not get this address");
                }
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }
    }
}

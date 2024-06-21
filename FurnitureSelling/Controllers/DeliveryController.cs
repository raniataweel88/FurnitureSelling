using FurnitureSellingCore.DTO.Order.Delivery;
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
        private readonly ICartServices _iservice;

        public DeliveryController(IOrderServices services, ICartServices iservice)
        {
            _service = services;
            _iservice = iservice;
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
        public async Task<IActionResult> GetCartByDeliveryId([FromRoute] int Id)
        {

            try
            {
                Log.Debug("start GetCartById-controller{Id}", Id);
                var Cart = await _service.GetByIdOrder(Id);
                return Ok(Cart);

            }
            catch
            {
                Log.Error("can not found  Cart");
                return BadRequest("can not found  Cart");
            }
        

    }
        //get all order
        /// <returns>Order</returns>
        /// <response code="400">cann't  get the all  Order</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllOrderbyDelivery()
        {
            try
            {
                Log.Debug("start GetAllOrderbyDelivery-controller");
                var d = await _service.GetAllOrderforDelivery();
                return Ok(d.ToList());
            }
            catch
            {Log.Error("can not get this order");
                return BadRequest("can not get this order");
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
        public async Task<IActionResult> UpdateOrderbyDelivery([FromBody] DeliveryOrder_updatetDTO dto)
        {
            try
            {
                Log.Debug("start UpdateOrderbyDelivery-controller");
                await _service.UpdateOrderforDelivery(dto);
                return Ok("done to update this order");
            }
            catch
            {Log.Error("can not update this order");
                return BadRequest("can not update this order");
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
        public async Task<IActionResult> SearchDelivery(string? address)
        {
            try
            {
                Log.Debug("start SearchDelivery-controller");
                var d = await _service.SearchOrderforDelivery(address);
                return Ok(d);
            }
            catch
            {Log.Error("can not get this address");
                return BadRequest("can not get this address");
            }
        }
    }
}

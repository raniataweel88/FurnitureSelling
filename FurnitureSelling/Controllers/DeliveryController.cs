using FurnitureSellingCore.IServices;
using FurnitureSellingInfra.Repos;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCartByDeliveryId([FromRoute] int id)
        {

            try
            {
                var Cart = await _iservice.GetByIdCart(id);
                return Ok(Cart);

            }
            catch
            {
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
                var d = await _service.GetAllOrderforDelivery();
                return Ok(d.ToList());
            }
            catch
            {
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
        ///       "StatusDelivery":if user receive فاث خقيثق
        ///     }
        /// </remarks>
        /// <response code="400">can not Update Order</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateOrderbyDelivery([FromBody] DeliveryOrder_updatetDTO dto)
        {
            try
            {
                await _service.UpdateOrderforDelivery(dto);
                return Ok("done to update this order");
            }
            catch
            {
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
        public async Task<IActionResult> SearchDelivery(string? Address)
        {
            try
            {
                var d = await _service.SearchOrderforDelivery(Address);
                return Ok(d);
            }
            catch
            {
                return BadRequest("can not get this address");
            }
        }
    }
}

using FurnitureSellingCore.IServices;
using FurnitureSellingInfra.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetOrderbyDelivery([FromRoute]int Id)
        {
            try
            {
                var d = await _service.GetByIdOrderforDelivery(Id);
                return Ok(d);
            }
            catch
            {
                return BadRequest("can not get this order");
            }

        }
        //get all order
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
        [HttpPost]
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

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Searchdelivery(string? Address)
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

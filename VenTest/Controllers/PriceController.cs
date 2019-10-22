using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VenTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        IPrices _price;
        IItemCollection _itemcollect;
        IDiscount _discount;
        public PriceController(IPrices price)
        {
            _price = price;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("calculateTotal")]
        public IActionResult DisplayPrice([FromBody] Item item)
        {
            // _price = new Prices(_itemcollect, _discount);


            if (CalculateTotalPrice(item) == null)
            {
                return BadRequest("the result is null");
            }
            double result = CalculateTotalPrice(item);
            return Ok(result);
        }

        private double CalculateTotalPrice(Item item)
        {
            return _price.CalculateTotalPrice(item);
        }
    }
}
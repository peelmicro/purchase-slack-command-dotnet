using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseSlackCommandDotNet.Models;
namespace PurchaseSlackCommandDotNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromForm] SlashCommandPayload value)
        {
            if (value == null) return BadRequest();
            return Ok("OK!");
        }
}

    }
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PurchaseSlackCommandDotNet.Models;
using PurchaseSlackCommandDotNet.Services;

namespace PurchaseSlackCommandDotNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {

        private readonly ISlackService _slackService;
        private readonly string _ceoMemberId;
        public PurchaseController(ISlackService slackService, IConfiguration configuration) {
            _slackService = slackService;
            _ceoMemberId = configuration["slackSettings:CeoMemberId"];            
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromForm] SlashCommandRequest request)
        {
            if (request == null) return BadRequest();
            _slackService.SendDirectMessage(
                _ceoMemberId, 
                $"Hi! <@{request.UserId}> would like to order *{request.Text}*. Do you authorise this purchase request?"
            );
            var response = new SlashCommandResponse { 
                Text = $"Thanks for your puchase request of *{request.Text}*. We will message the CEO now for authorisation" 
            };
            
            return Ok(response);
        }
    }

}
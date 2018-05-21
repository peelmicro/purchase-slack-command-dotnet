using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PurchaseSlackCommandDotNet.Models.Slack;
using PurchaseSlackCommandDotNet.Services;

namespace PurchaseSlackCommandDotNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly ISlackService _slackService;
        private readonly IFirebaseService _firebaseService;
        private readonly string _ceoMemberId;
        public PurchaseController(ISlackService slackService, IFirebaseService firebaseService, IConfiguration configuration)
        {
            _slackService = slackService;
            _firebaseService = firebaseService;
            _ceoMemberId = configuration["SlackSettings:CeoMemberId"];
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromForm] SlackCommandRequest request)
        {
        if (request == null) return BadRequest();

        var key = await _firebaseService.SavePurchaseRequestAsync(request.UserId, request.Text);

        await _slackService.SendDirectMessage(
            _ceoMemberId,
            $"Hi! <@{request.UserId}> would like to order *{request.Text}*. Do you authorise this purchase request?",
            new List<SlackAttachment> {
                    new SlackAttachment {
                        Text = "Do you authorise this purchase request?",
                        CallbackId = "purchase_request",
                        Actions = new List<SlackAction> {
                            new SlackAction {
                                Name = key,
                                Text = "Yes, I approve",
                                Type = "button",
                                Value = "approved"
                            },
                            new SlackAction {
                                Name = key,
                                Text = "No",
                                Type = "button",
                                Value = "declined"
                            }
                        }
                    }
            }
        );
        var response = new SlackCommandResponse
        {
            Text = $"Thanks for your puchase request of *{request.Text}*. We will message the CEO now for authorisation"
        };
        return Ok(response);
        }


    }

}
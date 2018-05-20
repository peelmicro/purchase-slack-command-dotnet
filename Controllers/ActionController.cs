using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PurchaseSlackCommandDotNet.Models;
using PurchaseSlackCommandDotNet.Services;

namespace PurchaseSlackCommandDotNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActionController: ControllerBase
    {
        private readonly ISlackService _slackService;
        public ActionController(ISlackService slackService)
        {
            _slackService = slackService;
        }
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromForm] SlackActionPayload request) {
            if (request == null) return BadRequest();
            var actionRequest = JsonConvert.DeserializeObject<SlackActionRequest>(request.Payload);
            var requestApproved = actionRequest.Actions[0].Value == "approved";
            var orginalTextMessage = actionRequest.OriginalMessage.Text;

            // send the orginial purchase requester feedback on the decision
            var regex = new Regex(@"@(.+)>.+\*(.+)\*");
            var matches = regex.Matches(orginalTextMessage);
            if (matches.Count>0 && matches[0].Groups.Count>1) {
                _slackService.SendDirectMessage(
                     matches[0].Groups[1].ToString(),
                    $"Hi! Your purchase request for *{matches[0].Groups[2].ToString()}* has been *{(requestApproved ? "approved" : "denied")}*."
                );
            }

            // sending the CEO feedback on what they decided        
            var response = new SlackActionResponse
            {
                Text = orginalTextMessage,
                Attachments = new List<SlackAttachment> {
                    new SlackAttachment {
                        Text = requestApproved 
                            ? "You *approved* this purchase request" 
                            : "You *denied* this purchase request"
                    }
                }
            };
            return Ok(response);
        }
    }
}
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PurchaseSlackCommandDotNet.Models.Slack;
using PurchaseSlackCommandDotNet.Services;

namespace PurchaseSlackCommandDotNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActionController: ControllerBase
    {
        private readonly IFirebaseService _firebaseService;
        private readonly ISlackService _slackService;
        public ActionController(ISlackService slackService, IFirebaseService firebaseService)
        {
            _slackService = slackService;
            _firebaseService = firebaseService;
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromForm] SlackActionPayload request) {
            if (request == null) return BadRequest();
            var actionRequest = JsonConvert.DeserializeObject<SlackActionRequest>(request.Payload);
            var requestApproved = actionRequest.Actions[0].Value == "approved";
            var orginalTextMessage = actionRequest.OriginalMessage.Text;
            var key = actionRequest.Actions[0].Name;

            // record decision of CEO in database
            await _firebaseService.RecordPurchaseRequestDecisionAsync( key, requestApproved );

            // read data using key from database (or response)
            var purchaseRequest = await _firebaseService.ReadPurchaseRequestAsync(key);
            var regex = new Regex(@"@(.+)>.+\*(.+)\*");
            var matches = regex.Matches(orginalTextMessage);
            var userId = purchaseRequest != null ? purchaseRequest.UserId: matches[0].Groups[2].ToString();
            var item = purchaseRequest != null ? purchaseRequest.Item: matches[0].Groups[1].ToString();

            // send the orginial purchase requester feedback on the decision
            await _slackService.SendDirectMessage(
                userId,
                $"Hi! Your purchase request for *{item}* has been *{(requestApproved ? "approved" : "denied")}*."
            );

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
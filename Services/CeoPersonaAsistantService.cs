using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PurchaseSlackCommandDotNet.Models.Slack;

namespace PurchaseSlackCommandDotNet.Services 
{
    public class CeoPersonaAsistantService : ICeoPersonaAsistantService
    {

        private readonly ISlackService _slackService;
        private readonly IFirebaseService _firebaseService;        
        private readonly string _ceoMemberId;

        public CeoPersonaAsistantService(ISlackService slackService, IFirebaseService firebaseService, IConfiguration configuration)
        {
             _slackService = slackService;
            _firebaseService = firebaseService;
            _ceoMemberId = configuration["SlackSettings:CeoMemberId"];
        }
        public async Task RemindPurchasesNotDecided(int minutes) {
            var purchaseRequests = await _firebaseService.ReadAllPurchaseRequestsAsync();

            var remindersSlackAttachments =  purchaseRequests
                .Where( purchase => purchase.Approved == null 
                    && DateTimeOffset.Now
                        .Subtract(DateTimeOffset.FromUnixTimeMilliseconds((long)purchase.TimeStamp))
                        .TotalMinutes > minutes)
                .Select( purchase => new SlackAttachment 
                    { Text = $"*{purchase.Item}* requested by <@{purchase.UserId}>" } 
                );
            await _slackService.SendDirectMessage(
                _ceoMemberId,
                $"Hi! Here are the purshases requests that still need a decision from you.",
                remindersSlackAttachments.ToList()
            );
        }
    }
}
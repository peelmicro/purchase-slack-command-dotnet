using System.Collections.Generic;
using System.Threading.Tasks;
using PurchaseSlackCommandDotNet.Models;

namespace PurchaseSlackCommandDotNet.Services 
{
    public interface ISlackService 
    {
        Task<SlackChatPostMessageResponse> SendDirectMessage(string users, string message
            , List<SlackAttachment> attachments = null);
    }
}
using System.Threading.Tasks;
using PurchaseSlackCommandDotNet.Models;

namespace PurchaseSlackCommandDotNet.Services 
{
    public interface ISlackService 
    {
        Task<SlashChatPostMessageResponse> SendDirectMessage(string users, string message);
    }
}
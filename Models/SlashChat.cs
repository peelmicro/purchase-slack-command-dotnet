using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PurchaseSlackCommandDotNet.Models
{
    public class SlashChatPostMessageRequest {
        [JsonProperty("channel")]
        public string Channel {get; set;}
        [JsonProperty("text")]
        public string Text {get; set;}    
    }
    public class SlashChatPostMessageResponse {
        public bool Ok {get; set;}
        public string Channel {get; set;}
        public string Ts {get; set;}
        public SlackMessage Message {get; set;}
    }  
}
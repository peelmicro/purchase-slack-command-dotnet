using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PurchaseSlackCommandDotNet.Models
{
    public class SlashConversationOpenRequest {
        [JsonProperty("users")]
        public string Users {get; set;}
    }
    public class SlashConversationOpenResponse {
        public bool Ok {get; set;}
        [JsonProperty("no_op")]
        public bool NoOp {get; set;}
        [JsonProperty("already_open")]
        public bool AlreadyOpen {get; set;}
        public SlackChannel Channel {get; set;}

    }  
}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PurchaseSlackCommandDotNet.Models
{
    public class SlackConversationOpenRequest {
        [JsonProperty("users")]
        public string Users {get; set;}
    }
    public class SlackConversationOpenResponse {
        public bool Ok {get; set;}
        [JsonProperty("no_op")]
        public bool NoOp {get; set;}
        [JsonProperty("already_open")]
        public bool AlreadyOpen {get; set;}
        [JsonProperty("error")]
        public string Error {get; set;}
        [JsonProperty("channel")]
        public SlackChannel Channel {get; set;}

    }  
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PurchaseSlackCommandDotNet.Models
{
    public class SlackChatPostMessageRequest {
        [JsonProperty("channel")]
        public string Channel {get; set;}
        [JsonProperty("text")]
        public string Text {get; set;} 
        [JsonProperty("attachments")]
        public List<SlackAttachment> Attachments {get; set;}
    }
    public class SlackChatPostMessageResponse {
        [JsonProperty("ok")]
        public bool Ok {get; set;}
        [JsonProperty("channel")]
        public string Channel {get; set;}
        [JsonProperty("ts")]
        public string Ts {get; set;}
        [JsonProperty("error")]
        public string Error {get; set;}
        [JsonProperty("message")]
        public SlackMessage Message {get; set;}
    }  
}
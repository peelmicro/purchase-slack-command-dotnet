using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PurchaseSlackCommandDotNet.Models
{
    public class SlackMessage {
        [JsonProperty("text")]
        public string Text {get; set;}
        [JsonProperty("username")]
        public string UserName {get; set;}
        [JsonProperty("bot_id")]
        public string BotId {get; set;}
        [JsonProperty("type")]
        public string Type {get; set;}
        [JsonProperty("subtype")]
        public string SubType {get; set;}
        [JsonProperty("ts")]
        public string Ts {get; set;}
        [JsonProperty("attachments")]
        public List<SlackAttachment> Attachments { get; set; }        
    }  
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PurchaseSlackCommandDotNet.Models.Slack
{
	public class  SlackAction {
        [JsonProperty("name")]
        public string Name {get; set;}
        [JsonProperty("type")]
        public string Type {get; set;}		
        [JsonProperty("text")]
        public string Text {get; set;}
        [JsonProperty("value")]
         public string Value {get; set;}		
        [JsonProperty("url")]
        public string Url {get; set;}		
	}
    public class SlackActionPayload
    {
        [FromForm(Name = "payload")]
        public string Payload { get; set; }

    }    
    public class SlackActionRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("callback_id")]
        public string CallbackId { get; set; }
        [JsonProperty("actions")]
        public List<SlackAction> Actions { get; set; }
        [JsonProperty("original_message")]
        public SlackMessage OriginalMessage { get; set; }        
  }

    public class SlackActionResponse
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("attachments")]
        public List<SlackAttachment> Attachments { get; set; }
    }
}
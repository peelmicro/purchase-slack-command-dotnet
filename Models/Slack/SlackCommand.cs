using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PurchaseSlackCommandDotNet.Models.Slack
{
    public class SlackCommandRequest
    {
        [FromForm(Name = "token")]
        public string Token { get; set; }
        [FromForm(Name = "team_id")]
        public string TeamId { get; set; }
        [FromForm(Name = "team_domain")]
        public string TeamDomain { get; set; }
        [FromForm(Name = "enterprise_id")]
        public string EnterpriseId { get; set; }
        [FromForm(Name = "enterprise_name")]
        public string EnterpriseName { get; set; }
        [FromForm(Name = "channel_id")]
        public string ChannelId { get; set; }
        [FromForm(Name = "channel_name")]
        public string ChannelName { get; set; }
        [FromForm(Name = "user_id")]
        public string UserId { get; set; }
        [FromForm(Name = "user_name")]
        public string UserName { get; set; }
        [FromForm(Name = "command")]
        public string Command { get; set; }
        [FromForm(Name = "text")]
        public string Text { get; set; }
        [FromForm(Name = "response_url")]
        public string ResponseUrl { get; set; }
        [FromForm(Name = "trigger_id")]
        public string TriggerId { get; set; }
    }

    public class SlackCommandResponse
    {
        [JsonProperty("response_type")]
        public string ResponseType {get; set;}
        [JsonProperty("text")]
        public string Text {get; set;}
    }  
}
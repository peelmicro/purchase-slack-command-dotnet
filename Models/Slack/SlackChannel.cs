using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PurchaseSlackCommandDotNet.Models.Slack
{
	public class  SlackChannel {
			[JsonProperty(propertyName: "id")]
    	public string Id {get; set;}		
	}
}
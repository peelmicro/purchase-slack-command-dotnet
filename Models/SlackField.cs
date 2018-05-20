using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PurchaseSlackCommandDotNet.Models
{
	public class  SlackField {
			[JsonProperty("title")]
    	public string Title {get; set;}		
			[JsonProperty("value")]
    	public string Value {get; set;}		
			[JsonProperty("short")]
    	public bool Short {get; set;}		
	}
}
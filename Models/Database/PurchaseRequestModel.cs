using Newtonsoft.Json;
namespace PurchaseSlackCommandDotNet.Models.Database
{
  public class PurchaseRequestModel
  {
    [JsonProperty("approved")]
    public bool? Approved { get; set; }
    [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
    public string Item { get; set; }
    [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
    public long? TimeStamp { get; set; }
    [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
    public string UserId { get; set; }
  }
}
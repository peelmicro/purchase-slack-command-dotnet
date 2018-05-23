using Newtonsoft.Json;
namespace PurchaseSlackCommandDotNet.Models.Database
{
  public class PurchaseRequestModel
  {
    [JsonProperty("approved")]
    public bool? Approved { get; set; }
    [JsonProperty("item")]
    public string Item { get; set; }
    [JsonProperty("timestamp")]
    public long? TimeStamp { get; set; }
    [JsonProperty("userId")]
    public string UserId { get; set; }
  }
}
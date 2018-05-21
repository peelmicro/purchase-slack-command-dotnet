using System.Collections.Generic;
using System.Threading.Tasks;
using PurchaseSlackCommandDotNet.Models.Database;

namespace PurchaseSlackCommandDotNet.Services
{
  public interface IFirebaseService
  {
    Task<string> SavePurchaseRequestAsync(string userId, string item);
    Task<PurchaseRequestModel> ReadPurchaseRequestAsync(string key);
    Task RecordPurchaseRequestDecisionAsync(string key, bool approved);
  }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PurchaseSlackCommandDotNet.Models.Database;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Linq;

namespace PurchaseSlackCommandDotNet.Services
{
  public class FirebaseService : IFirebaseService
  {
    private const string PurchaseRequestPath = "purchase-request";
    FirebaseClient _firebaseClient;
    public FirebaseService(IConfiguration configuration)
    {
      var firebaseSecretKey = configuration["FirebaseSettings:SecretKey"];
      var firebaseUrl = configuration["FirebaseSettings:Url"];
      _firebaseClient = new FirebaseClient(firebaseUrl,
          new FirebaseOptions
          {
            AuthTokenAsyncFactory = () => Task.FromResult(firebaseSecretKey)
          });
    }

    public async Task RecordPurchaseRequestDecisionAsync(string key, bool approved)
    {
        var current = await ReadPurchaseRequestAsync(key);
        if (current == null || current?.Approved == approved)
        {
            return;
        }
        await _firebaseClient
            .Child(PurchaseRequestPath)
            .Child(key)
            .PutAsync(new PurchaseRequestModel
            {
                UserId = current.UserId,
                Item = current.Item,
                TimeStamp = current.TimeStamp,
                Approved = approved
            });
    }

    public async Task<PurchaseRequestModel> ReadPurchaseRequestAsync(string key)
    {
        var record = await _firebaseClient
            .Child(PurchaseRequestPath)
            .Child(key)
            .OnceSingleAsync<PurchaseRequestModel>();
        return record;
    }

    public async Task<List<PurchaseRequestModel>> ReadAllPurchaseRequestsAsync()
    {
        var records = await _firebaseClient
            .Child(PurchaseRequestPath)
            .OnceAsync<PurchaseRequestModel>();
        return records.Select(record => record.Object).ToList();
    }
    public async Task<string> SavePurchaseRequestAsync(string userId, string item)
    {
        var result = await _firebaseClient
            .Child(PurchaseRequestPath)
            .PostAsync(new PurchaseRequestModel
            {
                UserId = userId,
                Item = item,
                TimeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds()
            });
        return result.Key;
    }
  }
}
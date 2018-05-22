using System.Threading.Tasks;

namespace PurchaseSlackCommandDotNet.Services 
{
    public interface ICeoPersonaAsistantService 
    {
        Task RemindPurchasesNotDecided(int minutes);
    }
}
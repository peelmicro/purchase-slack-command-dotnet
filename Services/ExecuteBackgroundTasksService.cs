using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PurchaseSlackCommandDotNet.Services 
{
  public class ExecuteBackgroundTasksService : BackgroundService
  {
    private readonly int _delay;
    private readonly int _minutes;
    private readonly ICeoPersonaAsistantService _ceoPersonaAsistantService;        

    public ExecuteBackgroundTasksService(ICeoPersonaAsistantService ceoPersonaAsistantService
        , IConfiguration configuration) {
        _ceoPersonaAsistantService = ceoPersonaAsistantService;
        _delay = Convert.ToInt32(configuration["BackgroundTasks:Delay"]);
        _minutes = Convert.ToInt32(configuration["CeoPersonaAsistantService:Minutes"]);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _ceoPersonaAsistantService.RemindPurchasesNotDecided(_minutes);

            await Task.Delay(_delay, stoppingToken);
        }        
    }

  }
}
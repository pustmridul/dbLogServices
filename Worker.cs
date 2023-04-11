using Serilog;
using dbLogServices.Interfaces;

namespace dbLogServices
{
    public class Worker : BackgroundService
    {
   
        private readonly IRChallan _rChallan;
        private readonly IRChallanSync _rChallanSync;
        public Worker( IRChallan rChallan, IRChallanSync rChallanSync)
        {
            _rChallan = rChallan;
            _rChallanSync = rChallanSync;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var rChallan = _rChallan.RCHALLAN_GetNewRecord();

                 _rChallanSync.RchallanSync();
                foreach(var r in rChallan)
                {
                    Log.Information("New RChallan :" + r.BarCode);
                }

                
                await Task.Delay(5*1000, stoppingToken);
            }
        }
    

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Information("Service starting...");
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information("Service stopping...");
            await base.StopAsync(cancellationToken);
        }
}
}
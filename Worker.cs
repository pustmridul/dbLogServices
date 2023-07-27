using Serilog;
using dbLogServices.Interfaces;

namespace dbLogServices
{
    public class Worker : BackgroundService
    {
   
        private readonly IRChallan _rChallan;
        private readonly IRChallanSync _rChallanSync;
        private readonly ISetup _setup;
        private readonly IProductStockService _productStockService;
        public Worker( IRChallan rChallan, IRChallanSync rChallanSync, ISetup setup, IProductStockService productStockService)
        {
            _rChallan = rChallan;
            _rChallanSync = rChallanSync;
            _setup = setup;
            _productStockService = productStockService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //  var rChallan = _rChallan.RCHALLAN_GetNewRecord();

                // _rChallanSync.RchallanSync();

                //var shop = _setup.Shop_GetRecord();
                //var shopAck = _setup.Shop_SaveWriteAcknowledege(shop);

                //var stock =  _productStockService.GetAllProductStock();

                 _productStockService.GetAllDataFIKDAL();

                //foreach(var r in rChallan)
                //{
                //    //Log.Information("New RChallan :" + r.BarCode);
                //}

                
                //await Task.Delay(1000, stoppingToken);
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
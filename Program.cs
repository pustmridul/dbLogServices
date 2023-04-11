using dbLogServices;
using dbLogServices.Interfaces;
using dbLogServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
       
        services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

        services.AddSingleton<IRChallan, RChallanService>();
        services.AddSingleton<IRChallanSync, RChallanSyncService>();


        services.AddHostedService<Worker>();
        Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(hostContext.Configuration)
        .MinimumLevel.Debug()
        .WriteTo.Logger(c =>c.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug)
        .WriteTo.File($"D:/LaernCore/Logs/serilog/DEBUG.log", rollingInterval: RollingInterval.Minute))
        .WriteTo.Logger(c =>c.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
        .WriteTo.File($"D:/LaernCore/Logs/serilog/Info.log", rollingInterval: RollingInterval.Minute))
        .WriteTo.Logger(c => c.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
        .WriteTo.File($"D:/LaernCore/Logs/serilog/ERROR.log", rollingInterval: RollingInterval.Minute))
        .CreateLogger();

    })
    .UseSerilog()
    .UseWindowsService()
    .Build();

await host.RunAsync();

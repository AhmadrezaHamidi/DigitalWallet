//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

//namespace DIgitalWallet.Commmon;

//public static class DIRegister
//{
//    public class SerilogService : ISerilogService
//    {
//        private readonly ILogger<SerilogService> _logger;

//        public SerilogService(ILogger<SerilogService> logger)
//        {
//            _logger = logger;
//        }

//        public void CustomLog(LogLevel logLevel, string source, string serviceName, int line = 0, string? userId = "", string? description = "", object? data = null, string? exception = "")
//        {
//            string message = $"{description}, User: {userId}, Data: {data}";
//            switch (logLevel)
//            {
//                case LogLevel.Information:
//                    _logger.CustomeLogInformation(message, line, source, serviceName, exception);
//                    break;
//                case LogLevel.Warning:
//                    _logger.CustomeLogWarning(message, line, source, serviceName, exception);
//                    break;
//                case LogLevel.Error:
//                    _logger.CustomeLogError(message, line, source, serviceName, exception);
//                    break;
//                default:
//                    _logger.LogInformation(message); // Default logging
//                    break;
//            }
//        }
//    }


public interface ISerilogService
{
    void CustomLog(LogLevel logLevel, string source, string serviceName, int line = 0, string? userId = "", string? description = "", object? data = null, string? exception = "");
}


//    public static IServiceCollection AddCommonInjections(this IServiceCollection services, IConfiguration configuration)
//    {
//        services.AddSingleton<ISerilogService, SerilogService>();
//     services.AddCommonInjections\

//        var seqServerUrl = configuration["Seq:localSeqServer"];



//        return services;
//    }
using Microsoft.Extensions.Configuration;
using Serilog.Events;
using Serilog;
using Microsoft.Extensions.DependencyInjection;

public static class DIRegister
{

    public static IServiceCollection AddCommonInjections(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ISerilogService, SerilogService>();
        var seqServerUrl = configuration["Seq:localSeqServer"];

//        Log.Logger = new LoggerConfiguration()
//.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//.Enrich.FromLogContext()
//.WriteTo.Console()
//.WriteTo.Seq(seqServerUrl)
//.CreateLogger();



        return services;
    }



}


//}

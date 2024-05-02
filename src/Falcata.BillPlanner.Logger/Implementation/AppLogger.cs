using Microsoft.Extensions.Logging;

namespace Falcata.BillPlanner.Logger.Implementation;

public class AppLogger<TClass>: IAppLogger<TClass> where TClass: class
{
    private readonly ILogger<TClass> _logger;

    public AppLogger(ILogger<TClass> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    private void Log(LogLevel logLevel, string message)
    {
        _logger.Log(logLevel, message);
    }
    
    private void LogException(LogLevel logLevel, Exception ex, string message)
    {
        _logger.Log(logLevel, ex, message);
    }

    public void Trace(string message) => Log(LogLevel.Trace, message);

    public void Debug(string message) => Log(LogLevel.Debug, message);

    public void Info(string message) => Log(LogLevel.Information, message);

    public void Warning(string message) => Log(LogLevel.Warning, message);

    public void Warning(string message, Exception exception) => Log(LogLevel.Warning, message);

    public void Error(string message) => Log(LogLevel.Error, message);

    public void Error(string message, Exception exception) => Log(LogLevel.Error, message);

    public void Critical(string message) => Log(LogLevel.Critical, message);

    public void None(string message) => Log(LogLevel.None, message);
}
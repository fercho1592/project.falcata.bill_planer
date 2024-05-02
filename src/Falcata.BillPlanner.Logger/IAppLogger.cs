namespace Falcata.BillPlanner.Logger;

public interface IAppLogger<TClass> where TClass: class
{
    void Trace(string message);
    void Debug(string message);
    void Info(string message);
    void Warning(string message);
    void Warning(string message, Exception exception);
    void Error(string message);
    void Error(string message, Exception exception);
    void Critical(string message);
    void None(string message);
}
using P01.Logger.Loggers.Enums;

namespace P01.Logger.Appenders.Contracts
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}

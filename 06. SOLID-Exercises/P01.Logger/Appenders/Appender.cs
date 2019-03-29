namespace P01.Logger.Appenders
{
    using Appenders.Contracts;
    using Loggers.Enums;
    using P01.Logger.Layouts.Contracts;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        protected ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}

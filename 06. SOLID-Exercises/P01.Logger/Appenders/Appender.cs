namespace P01.Logger.Appenders
{
    using Appenders.Contracts;
    using Loggers.Enums;
    using Layouts.Contracts;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        protected int MessageCount { get; set; }
        protected ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}

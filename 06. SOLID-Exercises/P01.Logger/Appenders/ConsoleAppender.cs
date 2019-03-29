namespace P01.Logger.Appenders
{
    using Layouts.Contracts;
    using Loggers.Enums;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
                this.MessageCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {base.ReportLevel}, Messages appended: {MessageCount}";
        }
    }
}

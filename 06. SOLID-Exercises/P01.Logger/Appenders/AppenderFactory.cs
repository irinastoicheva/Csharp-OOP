﻿namespace P01.Logger.Appenders
{
    using Appenders.Contracts;
    using Layouts.Contracts;
    using P01.Logger.Layouts;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid append type!");
            }
        }
    }
}

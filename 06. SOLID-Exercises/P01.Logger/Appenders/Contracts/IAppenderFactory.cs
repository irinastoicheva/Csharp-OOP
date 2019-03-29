﻿namespace P01.Logger.Appenders.Contracts
{
    using Layouts.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}

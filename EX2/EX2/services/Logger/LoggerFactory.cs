﻿using Microsoft.Extensions.DependencyInjection;

namespace EX2.services.Logger
{
    public class LoggerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public LoggerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILoggerService GetLogger(string useFileLogger)
        {
            if (useFileLogger == "file")
            {
                return _serviceProvider.GetRequiredService<FileLoggerService>();
            }
            else if(useFileLogger == "consoleLog")
            { 
                return _serviceProvider.GetRequiredService<ILoggerService>();
            }
            else
            {
                return _serviceProvider.GetRequiredService<DataLoggerService>();
            } 
        }
    }
}

// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Infrastructure.Exceptions
{
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message) : base(message)
        {
        }

        public ConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class DevelopmentException : Exception
    {
        public DevelopmentException(string message) : base(message)
        {
        }

        public DevelopmentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
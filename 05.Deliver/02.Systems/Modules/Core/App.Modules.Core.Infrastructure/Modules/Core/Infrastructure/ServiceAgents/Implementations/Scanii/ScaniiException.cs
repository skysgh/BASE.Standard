﻿using System;

namespace App.Modules.Core.Infrastructure.ServiceAgents.Implementations.Scanii
{
    public class ScaniiException : Exception
    {
        public ScaniiException(string s) : base(s)
        {
        }
    }
}
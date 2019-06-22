﻿// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Infrastructure.Exceptions
{
    public class ToDoException : Exception
    {
        public ToDoException(string message) : base(message)
        {
        }
    }
}
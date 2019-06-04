using System;

namespace App.Modules.Core.Infrastructure.Exceptions
{
    public class ToDoException : Exception
    {
        public ToDoException(string message) : base(message) { }
    }
}

// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.Core.Infrastructure.Constants.Users
{
    public class Users
    {
        public class Anon
        {
            public static Guid Id = 0.ToGuid();
            public static string Name = "Anon";
        }

        public class SysDaemon
        {
            public static Guid Id = 1.ToGuid();
            public static string Name = "SysDaemon";
        }
    }
}
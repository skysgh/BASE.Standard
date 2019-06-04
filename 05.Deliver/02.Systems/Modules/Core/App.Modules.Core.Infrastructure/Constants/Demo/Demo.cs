﻿using System;

namespace App.Modules.Core.Infrastructure.Constants.Demo
{
    

    public static class Tenancies
    {
        public static class Default
        {
            public static Guid Id = 1.ToGuid();
            public static string Key = "Default";
            public static string HostName = "Default";
            public static string Name = "Default";
        }

        public static class A
        {
            public static Guid Id = 3.ToGuid();
            public static string Key = "Demo";
            public static string HostName = ".A.";
            public static string Name = "Demo Org, Inc.";
        }
        public static class B
        {
            public static Guid Id = 2.ToGuid();
            public static string Key = "DemoB";
            public static string HostName = ".B.";
            public static string Name = "Demo Org (B), Inc.";
        }
    }

    public static class Users {
        public static class U1 {
            public static Guid Id = 11.ToGuid();
            public static string Name = "Andy";
        }
        public static class U2
        {
            public static Guid Id = 12.ToGuid();
            public static string Name = "Bob";
        }
    }

}

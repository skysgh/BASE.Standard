using System;

namespace App.Modules.Core.Infrastructure.Constants.Users
{
    public class Users
    {
        public enum PrincipalTypes {
            Unspecified=0,
            Unknown=1,
            System=2,
            Default=3,
            ServiceClient = 4,
            User = 5

        }

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

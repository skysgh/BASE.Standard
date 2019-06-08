using System;

namespace App.Modules.Core.Infrastructure.Constants.Users
{
    public partial class Users
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

// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Infrastructure.Constants.IDA
{
    public static class TokenTitles
    {
        // kinda annoying they do this actually
        public const string IdpIdentifierId = "http://schemas.microsoft.com/identity/claims/identityprovider";

        public const string SubjectIdentifierId =
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";


        public const string ExpiryId = "exp";

        public const string IssuedAtId = "iat";
    }
}
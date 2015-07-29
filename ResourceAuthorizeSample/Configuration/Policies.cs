using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceAuthorizeSample.Configuration
{
    using ResourceAuthorizeSample.Authorization;

    public static class Policies
    {
        public static List<Tuple<string, string, string>> Get()
        {
            return new List<Tuple<string, string, string>>
                       {
                           new Tuple<string, string, string>(AppResources.BankAccount, AppResources.BankAccountActions.Read, "Manager"),
                           new Tuple<string, string, string>(AppResources.BankAccount, AppResources.BankAccountActions.Read, "Clerk"),
                           new Tuple<string, string, string>(AppResources.BankAccount, AppResources.BankAccountActions.Transfer, "Manager"),
                       };
        }
    }
}
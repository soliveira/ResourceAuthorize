using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceAuthorizeSample.Authorization
{
    public class AppResources
    {
        public const string BankAccount = "bankAccount";

        public static class BankAccountActions
        {
            public const string Read = "read";

            public const string Transfer = "transfer";
        }
    }
}
namespace ResourceAuthorizeSample.Configuration
{
    using System.Collections.Generic;

    using Thinktecture.IdentityServer.Core.Models;

    public static class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
        {
            new Scope
            {
                Name = "api1"
            },
            StandardScopes.ProfileAlwaysInclude,
            StandardScopes.RolesAlwaysInclude
        };
        }
    }
}
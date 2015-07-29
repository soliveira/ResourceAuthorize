namespace ResourceAuthorizeSample.Configuration
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices.WindowsRuntime;

    using Thinktecture.IdentityServer.Core.Models;

    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
        {
            new Client 
            {
                Enabled = true,
                ClientName = "MVC Client",
                ClientId = "mvc",
                Flow = Flows.Implicit,
                RedirectUris = new List<string>
                {
                    "http://localhost:59087/"
                }
            }
        };
        }

    }
}
using Microsoft.Owin;

using ResourceAuthorizeSample;

[assembly: OwinStartup(typeof(Startup))]

namespace ResourceAuthorizeSample
{
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OpenIdConnect;

    using Owin;

    using ResourceAuthorizeSample.Authorization;
    using ResourceAuthorizeSample.Configuration;

    using Thinktecture.IdentityServer.Core.Configuration;
    using Thinktecture.IdentityServer.Core.Logging;
    using Thinktecture.IdentityServer.Core.Models;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map(
                "/identity",
                idsrvApp => idsrvApp.UseIdentityServer(
                    new IdentityServerOptions
                        {
                            SiteName = "Embedded IdentityServer",
                            SigningCertificate = this.LoadCertificate(),
                            RequireSsl = false,
                            Factory = InMemoryFactory.Create(
                                users: Users.Get(),
                                clients: Clients.Get(),
                                scopes: Scopes.Get().Union(StandardScopes.All))
                        }));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "http://localhost:59087/identity",
                ClientId = "mvc",
                RedirectUri = "http://localhost:59087/",
                ResponseType = "id_token token",
                SignInAsAuthenticationType = "Cookies",
                Scope = "openid profile roles"
            });
            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());
            app.UseResourceAuthorization(new AppResourceAuthorizationManager(new AuthorizationPolicies(Policies.Get())));
        }

        private X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}

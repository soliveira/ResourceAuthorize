namespace ResourceAuthorizeSample.Authorization
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

    public class AppResourceAuthorizationManager : ResourceAuthorizationManager
    {
        private readonly AuthorizationPolicies currentPolicies;

        public AppResourceAuthorizationManager(AuthorizationPolicies currentPolicies)
        {
            this.currentPolicies = currentPolicies;
        }

        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            return this.Eval(
                this.currentPolicies.ContainsPolicy(
                    context.Resource.First().Value,
                    context.Action.First().Value,
                    context.Principal.Claims.Where(x => x.Type.Equals(ClaimTypes.Role)).Select(x => x.Value).ToList()));
        }
    }
}
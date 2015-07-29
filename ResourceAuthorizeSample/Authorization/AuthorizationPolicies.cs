using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceAuthorizeSample.Authorization
{
    public class AuthorizationPolicies
    {
        // Dictionary<resource,Dictionary<action,List<Role>>>
        private Dictionary<string, Dictionary<string, List<string>>> currentPolicies;

        /// <summary>
        /// Creates Authorization Policies
        /// </summary>
        /// <param name="policies">List of policies in Place List(resource, action, role) </param>
        public AuthorizationPolicies(IEnumerable<Tuple<string,string,string>> policies)
        {
            var resources = policies.GroupBy(k => k.Item1, e => new Tuple<string, string>(e.Item2, e.Item3));

            this.currentPolicies = resources.ToDictionary(x => x.Key, x => x.GroupBy(g => g.Item1, g => g.Item2).ToDictionary(d => d.Key, d => d.ToList()));
        }

        public bool ContainsPolicy(string resource, string action, List<string> userRoles)
        {
            if (userRoles == null || !userRoles.Any())
            {
                return false;
            }
            
            if (!this.currentPolicies.ContainsKey(resource))
            {
                return false;
            }

            var resourceActions = this.currentPolicies[resource];

            if (!resourceActions.ContainsKey(action))
            {
                return false;
            }

            var requiredRoles = resourceActions[action];

            return requiredRoles.Intersect(userRoles).Any();
        }
    }
}
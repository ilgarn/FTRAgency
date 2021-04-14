using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace KareAjans.BLL.Models
{
    public class CustomPrincipal : ICustomPrincipal
    {
        private IIdentity _identity;
        private string[] _roles;

        public CustomPrincipal(IIdentity identity, string[] roles)
        {
            _identity = identity;
            _roles = new string[roles.Length];
            roles.CopyTo(_roles, 0);
            Array.Sort(_roles);
        }
        public bool IsInRole(string role) { return Array.BinarySearch(_roles, role) >= 0 ? true : false; }
        public IIdentity Identity { get { return _identity; } }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Infrastructure.Identity.Interfaces
{
    public interface IUser
    {
        string Name { get; }

        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();
    }
}

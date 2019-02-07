using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComplaintDepartment.Infastructure
{
    public class BlockUsersRequirement : IAuthorizationRequirement
    {

        public BlockUsersRequirement(params string[] users)
        {
            BlockedUsers = users;
        }

        public string[] BlockedUsers { get; set; }
    }

    public class BlockUsersHandler : AuthorizationHandler<BlockUsersRequirement>
    {

        protected override Task HandleRequirementAsync(
                AuthorizationHandlerContext context,
                BlockUsersRequirement requirement)
        {

            if (context.User.Identity != null && context.User.Identity.Name != null
                && !requirement.BlockedUsers
                    .Any(user => user.Equals(context.User.Identity.Name,
                        StringComparison.OrdinalIgnoreCase)))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}

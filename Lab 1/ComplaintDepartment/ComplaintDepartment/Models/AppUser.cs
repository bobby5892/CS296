using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ComplaintDepartment.Models
{
    public class AppUser : IdentityUser
    {
        // I believe there is a requirement for additional user class elements.
        // Maybe a method or property for submitted complaints by a user?
    }
}

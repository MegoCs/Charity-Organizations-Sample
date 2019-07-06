using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityOrganizations_Portal.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CharityOrganizations_Portal.Models
{
    public class UsersContext : IdentityDbContext<PortalUser>
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

using System;
using CharityOrganizations_Portal.Areas.Identity.Data;
using CharityOrganizations_Portal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CharityOrganizations_Portal.Areas.Identity.IdentityHostingStartup))]
namespace CharityOrganizations_Portal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UsersContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<PortalUser>()
                    .AddEntityFrameworkStores<UsersContext>();
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CharityOrganizations_Portal.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the PortalUser class
    public class PortalUser : IdentityUser
    {
        [Required]
        public String FullName { get; set; }
        [Required]
        public string NationalId { get; set; }
        [Required]
        public string OrganizationName { get; set; }
    }
}
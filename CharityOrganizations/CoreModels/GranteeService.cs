using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharityOrganizations.CoreModels
{
    public partial class GranteeService
    {
        public int Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        public string ServiceComment { get; set; }
        [Required]
        public int GranteeId { get; set; }
        [Required]
        public int OrganizationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Grantee Grantee { get; set; }
        public virtual Organization Organization { get; set; }
    }
}

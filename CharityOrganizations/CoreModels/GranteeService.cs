using System;
using System.Collections.Generic;

namespace CharityOrganizations.CoreModels
{
    public partial class GranteeService
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceComment { get; set; }
        public int OrganizationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Organization Organization { get; set; }
    }
}

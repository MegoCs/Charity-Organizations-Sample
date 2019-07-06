using System;
using System.Collections.Generic;

namespace CharityOrganizations.CoreModels
{
    public partial class Organization
    {
        public Organization()
        {
            GranteeService = new HashSet<GranteeService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<GranteeService> GranteeService { get; set; }
    }
}

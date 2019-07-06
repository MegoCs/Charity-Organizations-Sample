using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharityOrganizations.CoreModels
{
    public partial class Organization
    {
        public Organization()
        {
            GranteeService = new HashSet<GranteeService>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual ICollection<GranteeService> GranteeService { get; set; }
    }
}

using System;
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


        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم الجمعية")]
        public string Name { get; set; }
        [Display(Name = "العنوان")]
        public string Address { get; set; }

        public virtual ICollection<GranteeService> GranteeService { get; set; }
    }
}

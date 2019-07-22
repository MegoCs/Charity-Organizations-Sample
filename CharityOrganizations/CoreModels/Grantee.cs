using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharityOrganizations.CoreModels
{
    public partial class Grantee
    {
        public Grantee()
        {
            GranteeService = new HashSet<GranteeService>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "الاسم")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "الرقم القومي")]
        public string NationalId { get; set; }
        [Display(Name = "العنوان")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "المدينة")]
        public int CityId { get; set; }
        [Required]
        [Display(Name = "افراد الاسرة")]
        public int FamilySize { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<GranteeService> GranteeService { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharityOrganizations.CoreModels
{
    public partial class GranteeService
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "نوع الخدمة")]
        public string ServiceName { get; set; }
        [Display(Name = "التفاصيل")]
        public string ServiceComment { get; set; }
        [Required]
        [Display(Name = "المنتفع")]
        public int GranteeId { get; set; }
        [Required]
        [Display(Name = "الجمعية")]
        public int OrganizationId { get; set; }
        [Display(Name = "وقت تسجيل الخدمة")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "مضيف الخدمة")]
        public string CreatedBy { get; set; }
        [Display(Name = "المنتفع")]
        public virtual Grantee Grantee { get; set; }
        [Display(Name = "الجمعية")]
        public virtual Organization Organization { get; set; }
    }
}

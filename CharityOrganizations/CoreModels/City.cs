using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharityOrganizations.CoreModels
{
    public partial class City
    {
        public City()
        {
            Grantee = new HashSet<Grantee>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم المحافظة")]
        public string Name { get; set; }

        public virtual ICollection<Grantee> Grantee { get; set; }
    }
}

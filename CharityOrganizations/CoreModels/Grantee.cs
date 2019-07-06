using System.ComponentModel.DataAnnotations;

namespace CharityOrganizations.CoreModels
{
    public partial class Grantee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NationalId { get; set; }
        public string Address { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int FamilySize { get; set; }
        public virtual City City { get; set; }
    }
}

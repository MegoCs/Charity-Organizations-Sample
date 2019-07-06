using System;
using System.Collections.Generic;

namespace CharityOrganizations.CoreModels
{
    public partial class Grantee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int FamilySize { get; set; }

        public virtual City City { get; set; }
    }
}

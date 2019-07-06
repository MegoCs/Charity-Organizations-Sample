using System;
using System.Collections.Generic;

namespace CharityOrganizations.CoreModels
{
    public partial class City
    {
        public City()
        {
            Grantee = new HashSet<Grantee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Grantee> Grantee { get; set; }
    }
}

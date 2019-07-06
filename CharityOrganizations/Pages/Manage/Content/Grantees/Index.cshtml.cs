using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CharityOrganizations.CoreModels;

namespace CharityOrganizations.Pages.Manage.Content.Grantees
{
    public class IndexModel : PageModel
    {
        private readonly CharityOrganizations.CoreModels.CharityOrganizationsContext _context;

        public IndexModel(CharityOrganizations.CoreModels.CharityOrganizationsContext context)
        {
            _context = context;
        }

        public IList<Grantee> Grantee { get;set; }

        public async Task OnGetAsync()
        {
            Grantee = await _context.Grantee
                .Include(g => g.City).ToListAsync();
        }
    }
}

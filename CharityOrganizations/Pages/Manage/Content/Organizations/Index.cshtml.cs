using CharityOrganizations.CoreModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharityOrganizations.Pages.Manage.Content.Organizations
{
    public class IndexModel : PageModel
    {
        private readonly CharityOrganizations.CoreModels.CharityOrganizationsContext _context;

        public IndexModel(CharityOrganizations.CoreModels.CharityOrganizationsContext context)
        {
            _context = context;
        }

        public IList<Organization> Organization { get; set; }

        public async Task OnGetAsync()
        {
            Organization = await _context.Organization.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CharityOrganizations.CoreModels;

namespace CharityOrganizations.Pages.Manage.Service
{
    public class DetailsModel : PageModel
    {
        private readonly CharityOrganizations.CoreModels.CharityOrganizationsContext _context;

        public DetailsModel(CharityOrganizations.CoreModels.CharityOrganizationsContext context)
        {
            _context = context;
        }

        public GranteeService GranteeService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GranteeService = await _context.GranteeService
                .Include(g => g.Grantee)
                .Include(g => g.Organization).FirstOrDefaultAsync(m => m.Id == id);

            if (GranteeService == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

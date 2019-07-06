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
    public class DetailsModel : PageModel
    {
        private readonly CharityOrganizations.CoreModels.CharityOrganizationsContext _context;

        public DetailsModel(CharityOrganizations.CoreModels.CharityOrganizationsContext context)
        {
            _context = context;
        }

        public Grantee Grantee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grantee = await _context.Grantee
                .Include(g => g.City).FirstOrDefaultAsync(m => m.Id == id);

            if (Grantee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

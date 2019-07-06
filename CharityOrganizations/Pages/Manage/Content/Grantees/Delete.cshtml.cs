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
    public class DeleteModel : PageModel
    {
        private readonly CharityOrganizations.CoreModels.CharityOrganizationsContext _context;

        public DeleteModel(CharityOrganizations.CoreModels.CharityOrganizationsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grantee = await _context.Grantee.FindAsync(id);

            if (Grantee != null)
            {
                _context.Grantee.Remove(Grantee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

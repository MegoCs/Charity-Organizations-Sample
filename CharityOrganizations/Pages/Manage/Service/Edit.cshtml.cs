using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CharityOrganizations.CoreModels;

namespace CharityOrganizations.Pages.Manage.Service
{
    public class EditModel : PageModel
    {
        private readonly CharityOrganizations.CoreModels.CharityOrganizationsContext _context;

        public EditModel(CharityOrganizations.CoreModels.CharityOrganizationsContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["GranteeId"] = new SelectList(_context.Grantee, "Id", "Name");
           ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GranteeService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GranteeServiceExists(GranteeService.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GranteeServiceExists(int id)
        {
            return _context.GranteeService.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CharityOrganizations.CoreModels;

namespace CharityOrganizations.Pages.Manage.Content.Grantees
{
    public class EditModel : PageModel
    {
        private readonly CharityOrganizations.CoreModels.CharityOrganizationsContext _context;

        public EditModel(CharityOrganizations.CoreModels.CharityOrganizationsContext context)
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
           ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Grantee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GranteeExists(Grantee.Id))
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

        private bool GranteeExists(int id)
        {
            return _context.Grantee.Any(e => e.Id == id);
        }
    }
}

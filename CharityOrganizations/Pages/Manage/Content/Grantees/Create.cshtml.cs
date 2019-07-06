using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CharityOrganizations.CoreModels;

namespace CharityOrganizations.Pages.Manage.Content.Grantees
{
    public class CreateModel : PageModel
    {
        private readonly CharityOrganizations.CoreModels.CharityOrganizationsContext _context;

        public CreateModel(CharityOrganizations.CoreModels.CharityOrganizationsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Grantee Grantee { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Grantee.Add(Grantee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CharityOrganizations.CoreModels;

namespace CharityOrganizations.Pages.Manage.Service
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
        ViewData["GranteeId"] = new SelectList(_context.Grantee, "Id", "Name");
        ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public GranteeService GranteeService { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GranteeService.Add(GranteeService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
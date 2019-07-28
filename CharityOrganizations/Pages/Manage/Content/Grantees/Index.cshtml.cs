using CharityOrganizations.CoreModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityOrganizations.Pages.Manage.Content.Grantees
{
    public class IndexModel : PageModel
    {
        private readonly CharityOrganizations.CoreModels.CharityOrganizationsContext _context;
        private readonly int _PageSize = 1;
        public IndexModel(CharityOrganizations.CoreModels.CharityOrganizationsContext context)
        {
            _context = context;
        }

        public PaginatedList<Grantee> Grantee { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GranteeName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GranteeNationalId { get; set; }


        public async Task OnGetAsync(int? pageIndex)
        {
            var qury = _context.Grantee.AsQueryable();
            if (!string.IsNullOrEmpty(GranteeName))
                qury = qury.Where(g => g.Name.ToLower().Contains(GranteeName.ToLower()));
            if (!string.IsNullOrEmpty(GranteeNationalId))
                qury = qury.Where(g => g.NationalId.Contains(GranteeNationalId));

            Grantee = await PaginatedList<Grantee>.CreateAsync(qury.Include(g=>g.City).AsNoTracking(), pageIndex ?? 1, _PageSize);
        }
    }
}

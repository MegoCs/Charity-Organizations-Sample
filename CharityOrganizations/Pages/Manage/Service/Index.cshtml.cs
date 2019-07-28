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
    public class IndexModel : PageModel
    {
        private readonly CharityOrganizations.CoreModels.CharityOrganizationsContext _context;
        private readonly int _PageSize = 10;
        public IndexModel(CharityOrganizations.CoreModels.CharityOrganizationsContext context)
        {
            _context = context;
        }

        public PaginatedList<GranteeService> GranteeService { get;set; }
        [BindProperty(SupportsGet = true)]
        public string ServiceName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GranteeName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GranteeNationalId { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            var queryable = _context.GranteeService.AsQueryable();
            if (!string.IsNullOrEmpty(ServiceName))
                queryable= queryable.Where(s=>s.ServiceName.ToLower().Contains(ServiceName.ToLower()));
            if(!string.IsNullOrEmpty(GranteeName))
                queryable = queryable.Where(s =>s.Grantee.Name.ToLower().Contains(GranteeName.ToLower()));
            if(!string.IsNullOrEmpty(GranteeNationalId))
                queryable = queryable.Where(s => s.Grantee.NationalId.Contains(GranteeNationalId));


            GranteeService = await PaginatedList<GranteeService>.CreateAsync(queryable
                .Include(g => g.Grantee)
                .Include(g => g.Organization).AsNoTracking(), pageIndex ?? 1, _PageSize);
        }
    }
}

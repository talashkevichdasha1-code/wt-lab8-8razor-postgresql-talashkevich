using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_talashkevich.Data;
using wt_lab8_8razor_postgresql_talashkevich.Models;

namespace wt_lab8_8razor_postgresql_talashkevich.Pages.Members;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Member> Members { get; private set; } = new();

    public List<Trainer> Trainers { get; private set; } = new();

    public List<MembershipPlan> MembershipPlans { get; private set; } = new();

    public int TotalMembers { get; private set; }

    public int ActiveMembers { get; private set; }

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public async Task OnGetAsync()
    {
        var query = _context.Members
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(m => m.Name.Contains(Search));
        }

        Members = await query
            .OrderBy(m => m.Id)
            .ToListAsync();

        Trainers = await _context.Trainers
            .AsNoTracking()
            .ToListAsync();

        MembershipPlans = await _context.MembershipPlans
            .AsNoTracking()
            .ToListAsync();

        TotalMembers = await _context.Members.CountAsync();

        ActiveMembers = await _context.Members
            .CountAsync(m => m.IsActive);
    }
}

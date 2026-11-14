
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_talashkevich.Data;
using wt_lab8_8razor_postgresql_talashkevich.Models;

namespace wt_lab8_8razor_postgresql_talashkevich.Pages.Members;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Member? Member { get; private set; }

    public Trainer? Trainer { get; private set; }

    public MembershipPlan? MembershipPlan { get; private set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Member = await _context.Members
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (Member == null)
        {
            return NotFound();
        }

        Trainer = await _context.Trainers
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == Member.TrainerId);

        MembershipPlan = await _context.MembershipPlans
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == Member.MembershipPlanId);

        return Page();
    }
}

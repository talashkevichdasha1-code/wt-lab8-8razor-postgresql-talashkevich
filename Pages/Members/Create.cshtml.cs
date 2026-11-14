
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_talashkevich.Data;
using wt_lab8_8razor_postgresql_talashkevich.Models;

namespace wt_lab8_8razor_postgresql_talashkevich.Pages.Members;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Member Member { get; set; } = new();

    public List<Trainer> Trainers { get; set; } = new();

    public List<MembershipPlan> MembershipPlans { get; set; } = new();

    public async Task OnGetAsync()
    {
        await LoadFormDataAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await LoadFormDataAsync();

        if (!await _context.Trainers.AnyAsync(t => t.Id == Member.TrainerId))
        {
            ModelState.AddModelError(
                "Member.TrainerId",
                "Выберите существующего тренера.");
        }

        if (!await _context.MembershipPlans.AnyAsync(
                p => p.Id == Member.MembershipPlanId))
        {
            ModelState.AddModelError(
                "Member.MembershipPlanId",
                "Выберите существующий абонемент.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        Member.IsActive = true;

        _context.Members.Add(Member);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private async Task LoadFormDataAsync()
    {
        Trainers = await _context.Trainers
            .AsNoTracking()
            .ToListAsync();

        MembershipPlans = await _context.MembershipPlans
            .AsNoTracking()
            .ToListAsync();
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_talashkevich.Data;
using wt_lab8_8razor_postgresql_talashkevich.Models;

namespace wt_lab8_8razor_postgresql_talashkevich.Pages.Members;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Member Member { get; set; } = new();

    public List<Trainer> Trainers { get; set; } = new();

    public List<MembershipPlan> MembershipPlans { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member == null)
        {
            return NotFound();
        }

        Member = member;

        await LoadFormDataAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id != Member.Id)
        {
            return BadRequest();
        }

        await LoadFormDataAsync();

        if (!await _context.Trainers.AnyAsync(t => t.Id == Member.TrainerId))
        {
            ModelState.AddModelError(
                "Member.TrainerId",
                "Выберите существующего тренера.");
        }

        if (!await _context.MembershipPlans.AnyAsync(p => p.Id == Member.MembershipPlanId))
        {
            ModelState.AddModelError(
                "Member.MembershipPlanId",
                "Выберите существующий абонемент.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var existingMember = await _context.Members.FindAsync(id);

        if (existingMember == null)
        {
            return NotFound();
        }

        existingMember.Name = Member.Name;
        existingMember.Age = Member.Age;
        existingMember.Description = Member.Description;
        existingMember.TrainerId = Member.TrainerId;
        existingMember.MembershipPlanId = Member.MembershipPlanId;
        existingMember.IsActive = Member.IsActive;

        await _context.SaveChangesAsync();

        return RedirectToPage("./Details", new { id = Member.Id });
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

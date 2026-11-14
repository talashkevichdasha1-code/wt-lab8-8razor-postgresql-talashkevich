
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_talashkevich.Data;
using wt_lab8_8razor_postgresql_talashkevich.Models;

namespace wt_lab8_8razor_postgresql_talashkevich.Pages.Members;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    public Member? Member { get; private set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Member = await _context.Members
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (Member == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member == null)
        {
            return NotFound();
        }

        _context.Members.Remove(member);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}


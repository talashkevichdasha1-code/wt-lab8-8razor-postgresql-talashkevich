
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using wt_lab8_8razor_postgresql_talashkevich.Data;
using wt_lab8_8razor_postgresql_talashkevich.Models;

namespace wt_lab8_8razor_postgresql_talashkevich.Pages;

public class LoginModel : PageModel
{
    private readonly AppDbContext _context;

    public LoginModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    [Required(ErrorMessage = "Введите логин.")]
    [StringLength(50, ErrorMessage = "Логин не должен превышать 50 символов.")]
    public string Login { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "Введите пароль.")]
    [StringLength(100, MinimumLength = 4,
        ErrorMessage = "Пароль должен содержать от 4 до 100 символов.")]
    public string Password { get; set; } = string.Empty;

    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(u =>
                u.Login == Login &&
                u.Password == Password);

        if (user == null)
        {
            ErrorMessage = "Неверный логин или пароль.";
            return Page();
        }

        HttpContext.Session.SetString("UserLogin", user.Login);

        return RedirectToPage("/Profile");
    }
}

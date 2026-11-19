
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wt_lab8_8razor_postgresql_talashkevich.Pages;

public class ProfileModel : PageModel
{
    public string UserLogin { get; set; } = string.Empty;

    public IActionResult OnGet()
    {
        var login = HttpContext.Session.GetString("UserLogin");

        if (string.IsNullOrEmpty(login))
        {
            return RedirectToPage("/Login");
        }

        UserLogin = login;

        return Page();
    }

    public IActionResult OnPost()
    {
        HttpContext.Session.Clear();

        return RedirectToPage("/Login");
    }
}

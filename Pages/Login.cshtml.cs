using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProiectAutoCore.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input. Please try again.";
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                ErrorMessage = "Invalid email or password.";
                _logger.LogWarning("Login failed: user not found for email {Email}", Email);
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(user, Password, isPersistent: true, lockoutOnFailure: false);

            var roles = await _userManager.GetRolesAsync(user);
            _logger.LogInformation($"User {Email} has roles: {string.Join(", ", roles)}");

            if (result.Succeeded)
            {
                _logger.LogInformation("User {Email} logged in successfully.", Email);
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return RedirectToPage("/Admin/Index");
                }
                return RedirectToPage("/Index");
            }

            if (result.IsLockedOut)
            {
                ErrorMessage = "Contul este blocat. Incearca mai tarziu";
                _logger.LogWarning("Login failed: contul este blocat pentru {Email}", Email);
            }
            else
            {
                ErrorMessage = "Invalid email sau parola.";
                _logger.LogWarning("Login failed: invalid password for email {Email}", Email);
            }

            return Page();
        }
    }
}

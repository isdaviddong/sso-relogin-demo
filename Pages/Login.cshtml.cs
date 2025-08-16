using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ssotest.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? MicrosoftClientId { get; set; }
        public string? MicrosoftTenantId { get; set; }
        public string? GoogleClientId { get; set; }
        public string? LineClientId { get; set; }
        public string? RedirectUri { get; set; }

        public void OnGet()
        {
            MicrosoftClientId = _configuration["SSO:Microsoft:ClientId"];
            MicrosoftTenantId = _configuration["SSO:Microsoft:TenantId"];
            GoogleClientId = _configuration["SSO:Google:ClientId"];
            LineClientId = _configuration["SSO:LINE:ClientId"];
            RedirectUri = _configuration["SSO:Microsoft:RedirectUri"]; // 所有 provider 使用同一個 redirect uri
        }
    }
}

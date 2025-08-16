using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ssotest.Pages
{
    public class CallbackModel : PageModel
    {
        public Dictionary<string, string> QueryParameters { get; set; } = new Dictionary<string, string>();
        public string? Provider { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            // 取得所有 query string 參數
            foreach (var param in Request.Query)
            {
                QueryParameters[param.Key] = param.Value.ToString();
            }

            // 檢查是否有錯誤
            if (Request.Query.ContainsKey("error"))
            {
                ErrorMessage = Request.Query["error_description"].FirstOrDefault() ?? Request.Query["error"].ToString();
            }

            // 嘗試從 session storage 取得 provider 資訊 (這會在前端處理)
        }
    }
}

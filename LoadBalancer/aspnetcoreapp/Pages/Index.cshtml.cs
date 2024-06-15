using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IndexModel(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string PortNumber { get; private set; }

    public void OnGet()
    {
        PortNumber = _httpContextAccessor?.HttpContext?.Items["ServerPort"] as string ?? "Port not found.";
    }
}

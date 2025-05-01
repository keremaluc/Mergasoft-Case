using Microsoft.AspNetCore.Mvc.RazorPages;
using To_Do.Model.DTOs;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public IConfiguration Configuration { get; }

    public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient();
        Configuration = configuration;
    }

    public List<ToDoItemDto> ToDoItems { get; set; } = new();

    public async Task OnGetAsync()
    {
        var baseUrl = Configuration["ApiBaseUrl"];
        var apiUrl = $"{baseUrl}/api/todo";

        var result = await _httpClient.GetFromJsonAsync<List<ToDoItemDto>>(apiUrl);
        if (result != null)
        {
            ToDoItems = result;
        }
    }
}

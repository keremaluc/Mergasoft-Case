using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using To_Do.Model.DTOs;

namespace To_Do.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        public List<ToDoItemDto> ToDoItems { get; set; } = new();

        public async Task OnGetAsync()
        {
            var baseUrl = _configuration["ApiBaseUrl"];
            var apiUrl = $"{baseUrl}/api/todo";

            var result = await _httpClient.GetFromJsonAsync<List<ToDoItemDto>>(apiUrl);
            if (result != null)
            {
                ToDoItems = result;
            }
        }
    }
}

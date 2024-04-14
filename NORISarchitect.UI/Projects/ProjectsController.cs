using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace NORISarchitect.UI.Projects
{
    public class ProjectsController : Controller
    {
        private readonly IHttpClientFactory clientFactory;

        public ProjectsController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        public HttpClient Client()
        {
            return clientFactory.CreateClient();
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProjectDto> response = new List<ProjectDto>();
            try
            {
                var responseMessage = await Client().GetAsync("https://localhost:7229/api/projects");
                responseMessage.EnsureSuccessStatusCode();
                response.AddRange(await responseMessage.Content.ReadFromJsonAsync<IEnumerable<ProjectDto>>());
            }
            catch (Exception)
            {

                throw;
            }

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await Client().GetFromJsonAsync<ProjectDto>($"https://localhost:7229/api/projects/{id}");
            if (response is null)
            {
                return View(null);
            }
            return View(response);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectDto createRequest)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7229/api/projects"),
                Content = new StringContent(JsonSerializer.Serialize(createRequest), Encoding.UTF8, "application/json"),
            };            
            var responseMessage = await Client().SendAsync(requestMessage);
            responseMessage.EnsureSuccessStatusCode();
            var response = await responseMessage.Content.ReadFromJsonAsync<ProjectDto>();
            if (responseMessage is null)
            {
                return View();
            }
            return RedirectToAction("Index", "Projects");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = await Client().GetFromJsonAsync<ProjectDto>($"https://localhost:7229/api/projects/{id}");
            if (response is null)
            {
                return View(null);
            }
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectDto updateRequest)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7229/api/projects/{updateRequest.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(updateRequest), Encoding.UTF8, "application/json"),
            };
            var responseMessage = await Client().SendAsync(requestMessage);
            responseMessage.EnsureSuccessStatusCode();
            var response = await responseMessage.Content.ReadFromJsonAsync<ProjectDto>();
            if (responseMessage is null)
            {
                return View();
            }
            return RedirectToAction("Index", "Projects");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ProjectDto deleteProject)
        {
            var responseMessage = await Client().DeleteAsync($"https://localhost:7229/api/projects/{deleteProject.Id}");
            responseMessage.EnsureSuccessStatusCode();
            var response = await responseMessage.Content.ReadFromJsonAsync<ProjectDto>();
            if (responseMessage is null)
            {
                return View();
            }
            return View("Index");
        }

    }
}

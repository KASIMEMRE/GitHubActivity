using GitHubActivity.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitHubActivity.Services
{
    public class GitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService()
        {
            _httpClient = new HttpClient();
            // GitHub API User-Agent başlığı olmadan istek kabul etmez.
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHub-Activity-App");
        }

        public async Task<List<GitHubEvent>> GetUserActivityAsync(string username)
        {
            string url = $"https://api.github.com/users/{username}/events";

            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new Exception("Kullanıcı bulunamadı.");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            // JSON'u modele çevirirken case-insensitive (büyük-küçük harf duyarsız) yaptım.
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<GitHubEvent>>(json, options) ?? new List<GitHubEvent>();
        }
    }
}
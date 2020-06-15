using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApplication.Resources;

namespace WebApplication.Services
{
    public class UsersService
    {
        private readonly string _baseUrl;
        private readonly ILogger<UsersService> _logger;
        private HttpClient _http;

        public UsersService(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient();
            _http.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = new List<User>();
            
            var request = new HttpRequestMessage(HttpMethod.Get, "users");
            var response = await _http.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                users = await JsonSerializer.DeserializeAsync<List<User>>(stream);
            }

            return users;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = new User();

            var request = new HttpRequestMessage(HttpMethod.Get, $"users/{userId}");
            var response = await _http.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                user = await JsonSerializer.DeserializeAsync<User>(stream);
            }

            return user;
        }

        public async Task<IEnumerable<Album>> GetAlbums(int userId)
        {
            var albums = new List<Album>();
            
            var request = new HttpRequestMessage(HttpMethod.Get, $"users/{userId}/albums");
            var response = await _http.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                albums = await JsonSerializer.DeserializeAsync<List<Album>>(stream);
            }

            return albums;
        }

        public async Task<Album> GetAlbum(int albumId)
        {
            var album = new Album();
            
            var request = new HttpRequestMessage(HttpMethod.Get, $"albums/{albumId}");
            var response = await _http.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                album = await JsonSerializer.DeserializeAsync<Album>(stream);
            }

            return album;
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int albumId)
        {
            var photos = new List<Photo>();

            var request = new HttpRequestMessage(HttpMethod.Get, $"albums/{albumId}/photos");
            var response = await _http.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var temp = await response.Content.ReadAsStringAsync();
                Console.WriteLine(temp);
                
                var stream = await response.Content.ReadAsStreamAsync();
                photos = await JsonSerializer.DeserializeAsync<List<Photo>>(stream);
            }

            return photos;
        }
    }
}
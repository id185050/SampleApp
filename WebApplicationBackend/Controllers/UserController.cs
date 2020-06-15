using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Resources;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController
    {
        private readonly string _baseUrl;
        private readonly ILogger<UsersController> _logger;
        private readonly HttpClient _http;

        public UsersController(ILogger<UsersController> logger)
        {
            _baseUrl = "https://jsonplaceholder.typicode.com";
            _logger = logger;
            _http = new HttpClient();
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                HttpResponseMessage response = await _http.GetAsync($"{_baseUrl}/users");
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<IEnumerable<User>>(body).ToList();

                return users;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return new List<User>();
            }
            
        }

        [HttpGet("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<User> GetUser(int userId)
        {
            try
            {
                HttpResponseMessage response = await _http.GetAsync($"{_baseUrl}/users/{userId}");
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(body);

                return user;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        [HttpGet("{userId:int}/albums")]
        public async Task<String> GetAlbums(int userId)
        {
            try
            {
                HttpResponseMessage response = await _http.GetAsync($"{_baseUrl}/users/{userId}/albums");
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return body;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        [HttpGet("{userId:int}/albums/{albumId:int}")]
        public async Task<String> GetAlbum(int userId, int albumId)
        {
            try
            {
                HttpResponseMessage response = await _http.GetAsync($"{_baseUrl}/albums/{albumId}");
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return body;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        [HttpGet("{userId:int}/albums/{albumId:int}/photos")]
        public async Task<String> GetPhotos(int userId, int albumId)
        {
            try
            {
                HttpResponseMessage response = await _http.GetAsync($"{_baseUrl}/albums/{albumId}/photos");
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return body;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}
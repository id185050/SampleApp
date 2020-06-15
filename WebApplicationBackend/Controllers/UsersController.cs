using System;
using System.Collections;
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
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UsersService _usersService;

        public UsersController(ILogger<UsersController> logger, UsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            Console.WriteLine("get users route");
            return await _usersService.GetUsers();
        }

        [HttpGet("{userId:int}")]
        public async Task<User> GetUser(int userId)
        {
            Console.WriteLine("get specific user");
            return await _usersService.GetUser(userId);
        }

        [HttpGet("{userId:int}/albums")]
        public async Task<IEnumerable<Album>> GetAlbums(int userId)
        {
            return await _usersService.GetAlbums(userId);
        }

        [HttpGet("{userId:int}/albums/{albumId:int}")]
        public async Task<Album> GetAlbum(int userId, int albumId)
        {
            return await _usersService.GetAlbum(albumId);
        }

        [HttpGet("{userId:int}/albums/{albumId:int}/photos")]
        public async Task<IEnumerable<Photo>> GetPhotos(int userId, int albumId)
        {
            return await _usersService.GetPhotos(albumId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PawFinderModel;
using PawFinderBL;

namespace PawFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PawFinderController : ControllerBase
    {
        //User dependency injection
        private IUserBL _userBL;
        private IMemoryCache _memoryCache;

        public PawFinderController(IUserBL p_userBL, IMemoryCache p_memoryCache)
        {
            _userBL = p_userBL;
            _memoryCache = p_memoryCache;
        }
        //------------------------------------------------------


        // // GET: api/PawFinder/
        // [HttpGet("GetAllUsers")]
        // public async Task<IActionResult> GetAllUsersAsync()
        // {
        //     try
        //     {
        //         List<User> listofUser = new List<User>();
        //         //TryGetValue (check if the cache still exists and if it does "out listofCustomer" puts that data inside our variable)
        //         if (!_memoryCache.TryGetValue("UserList", out listofUser))
        //         {
        //             listofUser = await _userBL.GetAllUsersAsync();
        //             _memoryCache.Set("UserList", listofUser, new TimeSpan(0, 0, 30));
        //         }
        //         Log.Information("Successfully returned a list of all users");
        //         return Ok(listofUser);
        //     }
        //     catch (SqlException)
        //     {
        //         //In this case, if it was unable to connect to the database, it'll give a 404 status code
        //         Log.Warning("Could not find a list of users.");
        //         return NotFound();
        //     }
            
        // }

        // // POST: api/PawFinder
        // [HttpPost("UploadPhoto")]
        // public async Task<IActionResult> UploadPhoto([FromForm] string username, string p_filename, byte file)
        // {
        //     try
        //     {
        //         var filename = GenerateFileName(p_filename, username);
        //         var fileUrl = "";
        //         BlobContainerClient container = new BlobContainerClient("ConnectionString", "ContainerName");
            
        //         BlobClient blob = container.GetBlobClient(filename);
        //         using (Stream stream = File.OpenReadStream())
        //         {
        //             blob.Upload(stream);
        //         }
        //         fileUrl = blob.Uri.AbsoluteUri;
                
        //     }
        //     catch (System.Exception)
        //     {
                
        //         throw;
        //     }



        // POST: api/User
        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser([FromBody] User p_user)
        {
            try
            {
                Log.Information("Successfully added a new user.");
                return Created("Successfully added", _userBL.RegisterUser(p_user));
            }
            catch (System.Exception ex)
            {
                Log.Warning("Could not add a user.");
                return Conflict(ex.Message);
            }
        }
    }
        // // DELETE: api/PawFinder/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
}


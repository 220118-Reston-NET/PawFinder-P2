using System;
using System.IO;
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


        // GET: api/PawFinder/
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                List<User> listofUser = new List<User>();
    
                if (!_memoryCache.TryGetValue("UserList", out listofUser))
                {
                    listofUser = await _userBL.GetAllUsersAsync();
                    _memoryCache.Set("UserList", listofUser, new TimeSpan(0, 0, 30));
                }
                Log.Information("Successfully returned a list of all users");
                return Ok(listofUser);
            }
            catch (SqlException)
            {
                Log.Warning("Could not find a list of users.");
                return NotFound();
            }
            
        }


        // GET: api/PawFinder/2
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUserAsync([FromQuery] int userID)
        {
            try
            {
                Log.Information("Successfully returned the user with userID");
                return Ok(await _userBL.GetUserAsync(userID));
            }
            catch (SqlException)
            {
                Log.Warning("Could not find user in the database.");
                return NotFound();
            } 
        }

        // GET: api/PawFinder/3
        [HttpGet("ViewMatchedUser")]
        public async Task<IActionResult> ViewMatchedUserAsync([FromQuery] int userID)
        {
            try
            {
                Log.Information("Successfully returned the matched user.");
                return Ok(await _userBL.ViewMatchedUserAsync(userID));
            }
            catch (SqlException)
            {
                Log.Warning("Could not find the matched user.");
                return NotFound();
            } 
        }

        // GET: api/PawFinder/4
        [HttpGet("GetConversation")]
        public async Task<IActionResult> GetConversationAsync([FromQuery] int UserID1, int UserID2)
        {
            try
            {
                Log.Information("Successfully returned conversation between users.");
                return Ok(await _userBL.GetConversationAsync(UserID1, UserID2));
            }
            catch (SqlException)
            {
                Log.Warning("Could not find an existing conversation between users.");
                return NotFound();
            } 
        }

        // GET: api/PawFinder/4
        [HttpGet("GetPotentialMatch")]
        public async Task<IActionResult> GetPotentialMatchAsync()
        {
            try
            {
                Log.Information("Successfully returned list of potential matches");
                return Ok(await _userBL.GetPotentialMatchAsync(CurrentUser.currentuser));
            }
            catch (System.Exception ex)
            {
                Log.Warning("Failed to return list of potential matches");
                return Conflict(ex.Message);
            } 
        }

        // POST: api/PawFinder
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] User p_user)
        {
            try
            {
                List<User> user = await _userBL.SearchUserAsync(p_user.UserName);
                if (user.Count() >= 1)
                {
                    Log.Information("There is already an existing username in this app.");
                    throw new Exception("This username is already taken!");
                }
                Log.Information("Successfully added a new user.");
                return Created("Successfully added", await _userBL.RegisterUserAsync(p_user));
            }
            catch (System.Exception ex)
            {
                Log.Warning("Could not add a user.");
                return Conflict(ex.Message);
            }
        }

        // POST: api/PawFinder/2
        [HttpPost("AddMessage")]
        public async Task<IActionResult> AddMessageAsync([FromBody] Message message)
        {
            try
            {
                Log.Information("Successfully added a new message.");
                return Created("Successfully added a message", await _userBL.AddMessageAsync(message));
            }
            catch (System.Exception ex)
            {
                Log.Warning("Could not add a message.");
                return Conflict(ex.Message);
            }
        }

        // PUT: api/PawFinder
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User p_user)
        {
            try
            {
                List<User> user = await _userBL.SearchUserAsync(p_user.UserName);
                if (user.Count() == 0)
                {
                    Log.Information("Failed to find a user to update.");
                    throw new Exception("User Not Found");
                }
                else if (user.Count() > 1)
                {
                    Log.Information("The usernames in this app should all be unique.");
                    throw new Exception("This username is already taken!");
                }
                Log.Information("Successfully updated user information.");
                return Ok(await _userBL.UpdateUserAsync(p_user));
            }
            catch (System.Exception ex)
            {
                Log.Warning("Could not update user information.");
                return Conflict(ex.Message);
            }
        }

        [HttpPut("LogIn")]
        public async Task<IActionResult> LoginAsync(string UserNameInput, string PasswordInput)
        {
            List<User> ListOfAllUsers = await _userBL.GetAllUsersAsync();
            foreach(var User in ListOfAllUsers)
            {
                if(User.UserName == UserNameInput)
                {
                    if(User.UserPassword == PasswordInput)
                    {
                        Log.Information("Logged in as user: " + User.UserID);
                        CurrentUser.currentuser = User;
                        return Ok(User);
                    }
                    else
                    {
                        Log.Warning("Incorrect password");
                        return Conflict();
                    }
                }
            }
            Log.Warning("Incorrect username");
            return Conflict();
        }
        [HttpDelete("LogOut")]
        public async Task<IActionResult> LogOutAsync()
        {
            try
            {
                CurrentUser.currentuser = new User();
                Log.Information("Log out successful");
                return Ok(CurrentUser.currentuser );
            }
            catch
            {
                Log.Warning("Error logging out");
                return Conflict();
            }
        }





    }
}


using System.Threading.Tasks;
using AzureBlob.Api.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using PawFinderModel;
using PawFinderBL;

namespace AzureBlob.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        //Dependency Injection
        private readonly BlobServiceClient _blobServiceClient;
        private IUserBL _userBL;
        
        public ImageController(IUserBL p_userBL, BlobServiceClient blobServiceClient)
        {
            _userBL = p_userBL;
            _blobServiceClient = blobServiceClient;
        }
 
        // POST: api/Photo
        [HttpPost("UploadPhoto")]
        public async Task<IActionResult> Upload(string UserName, [FromForm] FileModel model)
        {
            try
            {
                if (model.PhotoFile != null)
                {
                    var blobContainer = _blobServiceClient.GetBlobContainerClient("pawfindercontainer");
                    var blobClient = blobContainer.GetBlobClient(model.PhotoFile?.FileName);

                    await blobClient.UploadAsync(model.PhotoFile?.OpenReadStream());

                    var fileURL = "";
                    fileURL = blobClient.Uri.AbsoluteUri;

                    List<User> user = await _userBL.SearchUserAsync(UserName);
                    if (user.Count() == 0)
                    {
                        Log.Information("Failed to find a user.");
                        throw new Exception("User could not be found.");
                    }

                    Photo _photo = new Photo();

                    foreach (var item in user)
                    {
                        _photo.userID = item.UserID;
                        _photo.fileName = fileURL;
                    }
                    return Created("Successfully added photo", await _userBL.AddPhotoAsync(_photo));
                }
                else
                {
                    throw new Exception("You must upload a file!");
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(422, ex.Message);
            }
            
        }
    }
}

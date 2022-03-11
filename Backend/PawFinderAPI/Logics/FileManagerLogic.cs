// using System.Threading.Tasks;
// using Azure.Storage.Blobs;
// using AzureBlob.Api.Models;
 
// namespace AzureBlob.Api.Logics
// {
//     public class FileManagerLogic: IFileManagerLogic
//     {
//         private readonly BlobServiceClient _blobServiceClient;
//         public FileManagerLogic(BlobServiceClient blobServiceClient)
//         {
//             _blobServiceClient = blobServiceClient;
//         }
 
//         public async Task Upload(FileModel model)
//         {
//             var blobContainer = _blobServiceClient.GetBlobContainerClient("p0testcontainer");
 
//             var blobClient = blobContainer.GetBlobClient(model.PhotoFile?.FileName);
 
//             await blobClient.UploadAsync(model.PhotoFile?.OpenReadStream());
//         }
//     }
// }
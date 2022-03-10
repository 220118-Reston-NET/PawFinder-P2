using PawFinderModel;

namespace PawFinderBL;

public interface IUserBL
{
  
    List<User> GetAllUsers();
    User GetUser(int UserID);
    User RegisterUser(User p_user);
    List<User> SearchUser(string p_name);
    List<User> ViewMatchedUser(int userID);
    List<Message> GetConversation(int UserID1, int UserID2);
    string GenerateFileName(string fileName, string userName);
    User UpdateUser(User user);
    Message AddMessage(Message message);
    Photo AddPhoto(Photo p_photo);
    List<Photo> GetPhotobyUserID(int p_userID);
    List<User> GetPotentialMatch(User p_user);

    //Async version functions
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserAsync(int UserID);
    Task<User> RegisterUserAsync(User p_user);
    Task<List<User>> SearchUserAsync(string p_name);
    Task<List<User>> ViewMatchedUserAsync(int userID);
    Task<List<Message>> GetConversationAsync(int UserID1, int UserID2);
    Task<User> UpdateUserAsync(User user);
    Task<Message> AddMessageAsync(Message message);
    Task<Photo> AddPhotoAsync(Photo p_user);
    Task<List<Photo>> GetPhotobyUserIDAsync(int p_userID);

    Task<List<User>> GetPotentialMatchAsync(User p_user);


    
}
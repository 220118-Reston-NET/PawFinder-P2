using PawFinderModel;

namespace PawFinderBL;

public interface IUserBL
{
  
    List<User> GetAllUsers();
    User RegisterUser(User p_user);
    List<User> SearchUser(string p_name);
    List<User> ViewMatchedUser(int userID);
    List<Message> GetConversation(int UserID1, int UserID2);
    User UpdateUser(User user);
    Message AddMessage(Message message);
    void AddPhoto(string p_fileName, int p_userID);
    List<Photo> GetPhotobyUserID(int p_userID);
    List<User> GetPotentialMatch(User p_user);

    //Async version functions
    Task<List<User>> GetAllUsersAsync();
    Task<User> RegisterUserAsync(User p_user);
    Task<List<User>> SearchUserAsync(string p_name);
    Task<List<User>> ViewMatchedUserAsync(int userID);
    Task<List<Message>> GetConversationAsync(int UserID1, int UserID2);
    Task<User> UpdateUserAsync(User user);
    Task<Message> AddMessageAsync(Message message);
    void AddPhotoAsync(string p_fileName, int p_userID);
    Task<List<Photo>> GetPhotobyUserIDAsync(int p_userID);

    Task<List<User>> GetPotentialMatchAsync(User p_user);


    
}
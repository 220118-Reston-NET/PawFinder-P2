using PawFinderModel;

namespace PawFinderDL;

public interface IRepository
{
    User RegisterUser(User p_user);
    List<User> GetAllUsers();
    List<User> ViewMatchedUser(int UserID);
    List<Message> GetConversation(int UserID1, int UserID2);

    User UpdateUser(User p_user);
    Message AddMessage(Message message);
    void AddPhoto(string p_fileName, int p_userID);
    List<Photo> GetPhotobyUserID(int p_userID);



    //Async version functions
    Task<User> RegisterUserAsync(User p_user);
    Task<List<User>> GetAllUsersAsync();
    Task<List<User>> ViewMatchedUserAsync(int UserID);
    Task<List<Message>> GetConversationAsync(int UserID1, int UserID2);

    Task<User> UpdateUserAsync(User p_user);
    Task<Message> AddMessageAsync(Message message);
    void AddPhotoAsync(string p_fileName, int p_userID);
    Task<List<Photo>> GetPhotobyUserIDAsync(int p_userID);
}
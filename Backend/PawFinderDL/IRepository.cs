using PawFinderModel;

namespace PawFinderDL;

public interface IRepository
{
    User RegisterUser(User p_user);
    List<User> GetAllUsers();
    User GetUser(int UserID);
    List<User> ViewMatchedUser(int UserID);
    List<Message> GetConversation(int UserID1, int UserID2);
    User UpdateUser(User p_user);
    Message AddMessage(Message message);



    //Async version functions
    Task<User> RegisterUserAsync(User p_user);
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserAsync(int UserID);
    Task<List<User>> ViewMatchedUserAsync(int UserID);
    Task<List<Message>> GetConversationAsync(int UserID1, int UserID2);
    Task<User> UpdateUserAsync(User p_user);
    Task<Message> AddMessageAsync(Message message);

}
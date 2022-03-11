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


    /// <summary>
    /// Adds a user to the database.
    /// </summary>
    /// <param name="p_user"></param>
    /// <returns> Returns a user that was added. </returns>
    Task<User> RegisterUserAsync(User p_user);

    /// <summary>
    /// Will give back all users in the form of a list.
    /// </summary>
    /// <returns> Returns all users in the database. </returns>
    Task<List<User>> GetAllUsersAsync();

    /// <summary>
    /// Will give back a user from userID.
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns> Returns an individual user. </returns>
    Task<User> GetUserAsync(int UserID);

    /// <summary>
    /// Will give back matched user from userID.
    /// </summary>
    /// <param name="userID"></param>
    /// <returns> Returns a matched user. </returns>
    Task<List<User>> ViewMatchedUserAsync(int UserID);

    /// <summary>
    /// Will give back a conversation between two users.
    /// </summary>
    /// <param name="UserID1"></param>
    /// <param name="UserID2"></param>
    /// <returns> Returns an a conversation. </returns>
    Task<List<Message>> GetConversationAsync(int UserID1, int UserID2);

    /// <summary>
    /// Updates a user to the database.
    /// </summary>
    /// <param name="user"></param>
    /// <returns> Returns updated user information. </returns>
    Task<User> UpdateUserAsync(User p_user);

    /// <summary>
    /// Adds a new message between sender and receiver.
    /// </summary>
    /// <param name="message"></param>
    /// <returns> Returns a new message that was added. </returns>
    Task<Message> AddMessageAsync(Message message);

    Task<Photo> AddPhotoAsync(Photo p_photo);
    Task<List<Photo>> GetPhotobyUserIDAsync(int p_userID);

}
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
    User UpdateUser(User user);
    Message AddMessage(Message message);
    List<User> GetPotentialMatch(User p_user);

    List<int> GetPassedUsersID(int UserID);


    //Async version functions

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
    /// Adds a user to the database.
    /// </summary>
    /// <param name="p_user"></param>
    /// <returns> Returns a user that was added. </returns>
    Task<User> RegisterUserAsync(User p_user);

    /// <summary>
    /// Will search for a user from a username.
    /// </summary>
    /// <param name="p_name"></param>
    /// <returns> Returns a user that was searched. </returns>
    Task<List<User>> SearchUserAsync(string p_name);

    /// <summary>
    /// Will give back matched user from userID.
    /// </summary>
    /// <param name="userID"></param>
    /// <returns> Returns a matched user. </returns>
    Task<List<User>> ViewMatchedUserAsync(int userID);

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
    Task<User> UpdateUserAsync(User user);

    /// <summary>
    /// Adds a new message between sender and receiver.
    /// </summary>
    /// <param name="message"></param>
    /// <returns> Returns a new message that was added. </returns>
    Task<Message> AddMessageAsync(Message message);

    /// <summary>
    /// Will give back a potential match based on user.
    /// </summary>
    /// <param name="p_user"></param>
    /// <returns> Returns a potential match. </returns>
    Task<List<User>> GetPotentialMatchAsync(User p_user);

    Task<Photo> AddPhotoAsync(Photo p_photo);
    Task<List<Photo>> GetPhotobyUserIDAsync(int p_userID);
    Task<List<int>> GetPassedUsersIDAsync(int UserID);

}
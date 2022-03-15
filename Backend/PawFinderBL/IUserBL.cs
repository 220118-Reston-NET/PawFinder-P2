using PawFinderModel;

namespace PawFinderBL;

public interface IUserBL
{
    List<User> GetAllUsers();
    User GetUser(int UserID);
    User GetUserByUsername(string p_userName);
    User RegisterUser(User p_user);
    List<User> SearchUser(string p_name);
    List<User> ViewMatchedUser(int userID);
    List<Message> GetConversation(int UserID1, int UserID2);
    Message AddMessage(Message message);
    List<User> GetPotentialMatch(User p_user);

    List<int> GetPassedUsersID(int UserID);

    int AddPassedUserID(int passerID, int passeeID);

    User AddLikedUser(int LikerID, int LikedID);

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

    Task<User> GetUserByUsernameAsync(string userName);

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
    Task<User> UpdateUserBioSizeAsync(int p_userID, string p_userBio, string p_userSize);

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

    /// <summary>
    /// Adds a photo for a user profile.
    /// </summary>
    /// <param name="p_photo"></param>
    /// <returns> Returns a new photo. </returns>
    Task<Photo> AddPhotoAsync(Photo p_photo);

    /// <summary>
    /// Will give back a photo by userID.
    /// </summary>
    /// <param name="p_userID"></param>
    /// <returns> Returns a list of photos. </returns>
    Task<List<Photo>> GetPhotobyUserIDAsync(int p_userID);

    /// <summary>
    /// Will give back all passed users by userID.
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns> Returns a a list of passed users. </returns>
    Task<List<int>> GetPassedUsersIDAsync(int UserID);

    /// <summary>
    /// Adds a passed user by passerID and passeeID.
    /// </summary>
    /// <param name="passerID"></param>
    /// <param name="passeeID"></param>
    /// <returns> Returns a new passed user. </returns>
    Task<int> AddPassedUserIDAsync(int passerID, int passeeID);

    /// <summary>
    /// Adds a new liked user by likerID and likedID.
    /// </summary>
    /// <param name="LikerID"></param>
    /// <param name="LikedID"></param>
    /// <returns> Returns a new liked user. </returns>
    Task<User> AddLikedUserAsync(int LikerID, int LikedID);

    /// <summary>
    /// Will give back a list of all liked users by userID.
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns> Returns a list of liked users. </returns>
    Task<List<Like>> GetLikedUserAsync(int UserID);

    /// <summary>
    /// Will search for a list of passes users by passerID and passeeID.
    /// </summary>
    /// <param name="passerID"></param>
    /// <param name="passeeID"></param>
    /// <returns> Returns a list of searched passed users.</returns>
    Task<List<User>> SearchPassedUserAsync(int passerID, int passeeID);

    /// <summary>
    /// Will search for a list of liked users by passerID and passeeID.
    /// </summary>
    /// <param name="LikerID"></param>
    /// <param name="LikedID"></param>
    /// <returns> Returns a list of searched liked users. </returns>
    Task<List<Like>> SearchLikedUserAsync(int LikerID, int LikedID);



}
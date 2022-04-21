using PawFinderModel;

namespace PawFinderDL;

public interface IRepository
{
    User RegisterUser(User p_user);
    List<User> GetAllUsers();
    User GetUser(int UserID);
    User GetUserByUsername(string userName);
    List<User> ViewMatchedUser(int UserID);
    List<Message> GetConversation(int UserID1, int UserID2);
    Message AddMessage(Message message);
    List<int> GetPassedUsersID(int UserID);
    int AddPassedUserID(int passerID, int passeeID);
    User AddLikedUser(int LikerID, int LikedID);
    List<Like> GetLikedUser(int UserID);
    Match AddMatch(int p_UserID1, int p_UserID2);
    int GetLike(int UserID);
    int GetDislike(int UserID);


    //Async version functions


    /// <summary>
    /// Adds a user to the database.
    /// </summary>
    /// <param name="p_user"></param>
    /// <returns> Returns a user that was added. </returns>
    /// 
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

    Task<User> GetUserByUsernameAsync(string userName);

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
    // Task<User> UpdateUserAsync(User p_user);

    Task<User> UpdateUserBioSizeAsync(int p_userID, string p_userBio, string p_userSize);
    Task<User> UpdateUserBioAsync(int p_userID, string p_userBio);

    Task<User> UpdateUserSizeAsync(int p_userID, string p_userSize);


    /// <summary>
    /// Adds a new message between sender and receiver.
    /// </summary>
    /// <param name="message"></param>
    /// <returns> Returns a new message that was added. </returns>
    Task<Message> AddMessageAsync(Message message);

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

    Task<Match> AddMatchAsync(int p_UserID1, int p_UserID2);
}

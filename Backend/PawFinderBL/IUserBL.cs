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
    
}
using PawFinderModel;

namespace PawFinderDL;

public interface IRepository
{
    User RegisterUser(User p_user);
    List<User> GetAllUsers();
    int CreateUserID();
    int CreateConversationID();
    List<User> ViewMatchedUser(int UserID);
    List<Message> GetConversation(int UserID1, int UserID2);

}
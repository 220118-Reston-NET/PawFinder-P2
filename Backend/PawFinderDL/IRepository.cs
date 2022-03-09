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

}
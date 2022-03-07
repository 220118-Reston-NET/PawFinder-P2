using PawFinderModel;

namespace PawFinderDL;

public interface IRepository
{
    User RegisterUser(User p_user);
    List<User> GetAllUsers();
    int CreateUserID();
    int CreateConversationID();

}
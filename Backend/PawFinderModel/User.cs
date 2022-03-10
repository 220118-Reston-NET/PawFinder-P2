namespace PawFinderModel;

public class User
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public DateTime UserDOB { get; set; }
    public string UserBio { get; set; }
    public string UserBreed { get; set; }
    public string UserSize { get; set; }
    public string photoURL { get; set; }
    public User()
    {
        UserName = "";
        UserPassword = "";
        UserDOB = DateTime.UtcNow;
        UserBio = "";
        UserBreed = "";
        UserSize = "";
        photoURL = "";
    }

}
using System.ComponentModel.DataAnnotations;
namespace PawFinderModel
{
public class User
{
    [Key]
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public DateTime UserDOB { get; set; }
    public string UserBio { get; set; }
    public string UserBreed { get; set; }
    public string UserSize { get; set; }
    public string pictureURL { get; set; }

    private List<Photo> _photos;
    public List<Photo> Photo
    {
        get { return _photos; }
        set 
        {
            _photos = value;
        }
    }
    public User()
    {
        UserName = "";
        UserPassword = "";
        UserDOB = DateTime.UtcNow;
        UserBio = "";
        UserBreed = "";
        UserSize = "";
         _photos = new List<Photo>()
        {
            new Photo()
        };
    }

}

}
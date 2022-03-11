using PawFinderModel;
using PawFinderDL;

namespace PawFinderBL;

public class UserBL : IUserBL
{
    private IRepository _repo;
    public UserBL(IRepository p_repo)
    {
        _repo = p_repo;
    }

    public List<User> GetAllUsers()
    {
        return _repo.GetAllUsers();
    }

    public User GetUser(int UserID)
    {
        return _repo.GetUser(UserID);
    }

    public User RegisterUser(User p_user)
    {
        List<User> listOfAllUsers = _repo.GetAllUsers();
        foreach(var U in listOfAllUsers)
        {
            if(p_user.UserName == U.UserName)
            {
                throw new Exception("UserName already exist.");
            }
        }

        if (p_user.UserName is null)
        {
            throw new Exception("User Name is empty");
        }
        else if (p_user.UserBreed is null)
        {
            throw new Exception("User Breed is empty");
        }
        else if (p_user.UserPassword is null)
        {
            throw new Exception("User Password is empty");
        }
        else if (p_user.UserSize is null)
        {
            throw new Exception("User Size is empty");
        }
        else 
        {
            return _repo.RegisterUser(p_user);
        }
    }

    public List<User> SearchUser(string p_name)
    {
        List<User> ListOfUsers = _repo.GetAllUsers();

             return ListOfUsers
                         .Where(user => user.UserName.Contains(p_name))
                         .ToList();
        
    }

    public List<User> ViewMatchedUser(int userID)
    {
        return _repo.ViewMatchedUser(userID);
    }

    public List<Message> GetConversation(int UserID1, int UserID2)
    {
        return _repo.GetConversation(UserID1, UserID2);
    }


    // public string GenerateFileName(string fileName, string userName)
    // {
    //     try
    //     {
    //         string strFileName = string.Empty;
    //         string[] strName = fileName.Split('.');
    //         strFileName = userName + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd") + "/"
    //             + DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." +
    //             strName[strName.Length - 1];
    //         return strFileName;
    //     }
    //     catch (Exception)
    //     {
    //         return fileName;
    //     }
    // }

    public User UpdateUser(User user)
    {
        return _repo.UpdateUser(user);
    }

    public Message AddMessage(Message message)
    {
        return _repo.AddMessage(message);
    }

    public List<User> GetPotentialMatch(User p_user)
    {
        List<User> listOfAllUsers = _repo.GetAllUsers();
        DateTime zeroTime = new DateTime(1, 1, 1);
        List<User> Result = new List<User>();

        foreach(var U in listOfAllUsers)
        {
            if(p_user.UserDOB > U.UserDOB)
            {
                TimeSpan ageSpan = (p_user.UserDOB - U.UserDOB);
                int AgeDifferencesInYears = (zeroTime + ageSpan).Year - 1;
                if(AgeDifferencesInYears> 5)
                {
                    continue;
                }
                else if(AgeDifferencesInYears <= 5)
                {
                    Result.Add(U);
                }
            }
            else if (U.UserDOB < p_user.UserDOB)
            {
                TimeSpan ageSpan = (U.UserDOB-p_user.UserDOB);
                int AgeDifferencesInYears = (zeroTime + ageSpan).Year - 1;
                if(AgeDifferencesInYears> 5)
                {
                    continue;
                }
                else if(AgeDifferencesInYears <= 5)
                {
                    Result.Add(U);
                }
                
            }
            else if (U.UserDOB == p_user.UserDOB)
            {
                Result.Add(U);
            }
        }


        return listOfAllUsers;
    }

    // Async Functions=======================================================================================
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _repo.GetAllUsersAsync();
    }

    public async Task<User> GetUserAsync(int UserID)
    {
        return await _repo.GetUserAsync(UserID);
    }

    public async Task<User> RegisterUserAsync(User p_user)
    {
        List<User> listOfAllUsers = await _repo.GetAllUsersAsync();
        foreach(var U in listOfAllUsers)
        {
            if(p_user.UserName == U.UserName)
            {
                throw new Exception("UserName already exist.");
            }
        }
        if (p_user.UserName is null)
        {
            throw new Exception("User Name is empty");
        }
        else if (p_user.UserBreed is null)
        {
            throw new Exception("User Breed is empty");
        }
        else if (p_user.UserPassword is null)
        {
            throw new Exception("User Password is empty");
        }
        else if (p_user.UserSize is null)
        {
            throw new Exception("User Size is empty");
        }
        else 
        {
            return await _repo.RegisterUserAsync(p_user);
        }
    }

    public async Task<List<User>> SearchUserAsync(string p_name)
    {
        List<User> ListOfUsers = await _repo.GetAllUsersAsync();

             return ListOfUsers
                         .Where(user => user.UserName.Contains(p_name))
                         .ToList();
    }

    public async Task<List<User>> ViewMatchedUserAsync(int userID)
    {
        return await _repo.ViewMatchedUserAsync(userID);
    }

    public async Task<List<Message>> GetConversationAsync(int UserID1, int UserID2)
    {
        return await _repo.GetConversationAsync(UserID1, UserID2);
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        return await _repo.UpdateUserAsync(user);
    }

    public async Task<Message> AddMessageAsync(Message message)
    {
        return await _repo.AddMessageAsync(message);
    }

    public async Task<List<User>> GetPotentialMatchAsync(User p_user)
    {
        List<User> listOfAllUsers = await _repo.GetAllUsersAsync();
        DateTime zeroTime = new DateTime(1, 1, 1);
        List<User> Result = new List<User>();

        foreach(var U in listOfAllUsers)
        {
            if(p_user.UserDOB > U.UserDOB)
            {
                TimeSpan ageSpan = (p_user.UserDOB - U.UserDOB);
                int AgeDifferencesInYears = (zeroTime + ageSpan).Year - 1;
                if(AgeDifferencesInYears> 5)
                {
                    continue;
                }
                else if(AgeDifferencesInYears <= 5)
                {
                    Result.Add(U);
                }
            }
            else if (U.UserDOB < p_user.UserDOB)
            {
                TimeSpan ageSpan = (U.UserDOB-p_user.UserDOB);
                int AgeDifferencesInYears = (zeroTime + ageSpan).Year - 1;
                if(AgeDifferencesInYears> 5)
                {
                    continue;
                }
                else if(AgeDifferencesInYears <= 5)
                {
                    Result.Add(U);
                }
                
            }
            else if (U.UserDOB == p_user.UserDOB)
            {
                Result.Add(U);
            }
        }

        return listOfAllUsers;
    }

    public async Task<Photo> AddPhotoAsync(Photo p_photo)
    {
       return await _repo.AddPhotoAsync(p_photo);
    }

    public async Task<List<Photo>> GetPhotobyUserIDAsync(int p_userID)
    {
        return await _repo.GetPhotobyUserIDAsync(p_userID);
    }

}

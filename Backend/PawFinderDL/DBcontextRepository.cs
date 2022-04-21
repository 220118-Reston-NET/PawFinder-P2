using PawFinderModel;

namespace PawFinderDL;
public class DBcontextRepository : IRepository
{
    private readonly PawFinderDBcontext _context;

    public DBcontextRepository(PawFinderDBcontext context)
    {
        _context = context;
    }

    public User AddLikedUser(int LikerID, int LikedID)
    {
        User result = GetUser(LikedID);
        Like new_like = new Like();
        new_like.LikerID = LikerID;
        new_like.LikedID = LikedID;

        _context.Like.Add(new_like);
        _context.SaveChanges();

        return result;
    }

    async public Task<User> AddLikedUserAsync(int LikerID, int LikedID)
    {
        User result = GetUser(LikedID);
        Like new_like = new Like();
        new_like.LikerID = LikerID;
        new_like.LikedID = LikedID;

        await _context.Like.AddAsync(new_like);
        await _context.SaveChangesAsync();

        return result;
    }

    public Match AddMatch(int p_UserID1, int p_UserID2)
    {
        Match new_match = new Match();
        new_match.MatcherOneID = p_UserID1;
        new_match.MatcherTwoID = p_UserID2;

        _context.Match.Add(new_match);
        _context.SaveChanges();

        return new_match;
    }

    async public Task<Match> AddMatchAsync(int p_UserID1, int p_UserID2)
    {
        Match new_match = new Match();
        new_match.MatcherOneID = p_UserID1;
        new_match.MatcherTwoID = p_UserID2;

        await _context.Match.AddAsync(new_match);
        await _context.SaveChangesAsync();
        
        return new_match;
    }

    public Message AddMessage(Message message)
    {
        _context.Message.Add(message);
        _context.SaveChanges();

        return message;
    }

    async public Task<Message> AddMessageAsync(Message message)
    {
        await _context.Message.AddAsync(message);
        await _context.SaveChangesAsync();

        return message;
    }

    public int AddPassedUserID(int passerID, int passeeID)
    {
        Pass new_pass = new Pass();
        new_pass.PasseeID = passeeID;
        new_pass.PasserID = passerID;

        _context.Pass.Add(new_pass);
        _context.SaveChanges();

        return passeeID;

    }

    async public Task<int> AddPassedUserIDAsync(int passerID, int passeeID)
    {
        Pass new_pass = new Pass();
        new_pass.PasseeID = passeeID;
        new_pass.PasserID = passerID;

        await _context.Pass.AddAsync(new_pass);
        await _context.SaveChangesAsync();

        return passeeID;
    }

    async public Task<Photo> AddPhotoAsync(Photo p_photo)
    {
        throw new NotImplementedException();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
    }

    public List<User> GetAllUsers()
    {
        return _context.User.ToList<User>();
    }

    async public Task<List<User>> GetAllUsersAsync()
    {
        return _context.User.ToList<User>();
    }

    public List<Message> GetConversation(int UserID1, int UserID2)
    {
        return _context.Message.ToList<Message>();
    }

    async public Task<List<Message>> GetConversationAsync(int UserID1, int UserID2)
    {
        return _context.Message.ToList<Message>();
    }

    public int GetDislike(int UserID)
    {
        return _context.Pass.Where(like => like.PasseeID == UserID).ToList().Count();
    }

    public int GetLike(int UserID)
    {
        return _context.Like.Where(like => like.LikedID == UserID).ToList().Count();
    }

    public List<Like> GetLikedUser(int UserID)
    {
        return _context.Like.Where(like => like.LikerID == UserID).ToList();
    }

    async public Task<List<Like>> GetLikedUserAsync(int UserID)
    {
        return _context.Like.Where(like => like.LikerID == UserID).ToList();
    }

    public List<int> GetPassedUsersID(int UserID)
    {
        return _context.Pass.Where(pass => pass.PasserID == UserID).Select(pass => pass.PasserID).ToList();
    }

    async public Task<List<int>> GetPassedUsersIDAsync(int UserID)
    {
        return _context.Pass.Where(pass => pass.PasserID == UserID).Select(pass => pass.PasserID).ToList();
    }

    async public Task<List<Photo>> GetPhotobyUserIDAsync(int p_userID)
    {
        throw new NotImplementedException();
    }

    public User GetUser(int UserID)
    {
        return _context.User.Where(user => user.UserID == UserID).ToList()[0];
    }

    async public Task<User> GetUserAsync(int UserID)
    {
        return _context.User.Where(user => user.UserID == UserID).ToList()[0];
    }

    public User GetUserByUsername(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByUsernameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public User RegisterUser(User p_user)
    {
        _context.User.Add(p_user);
        _context.SaveChanges();

        return p_user;
    }

    async public Task<User> RegisterUserAsync(User p_user)
    {
        await _context.User.AddAsync(p_user);
        await _context.SaveChangesAsync();

        return p_user;
    }

    public User UpdateUser(User p_user)
    {
        _context.User.Update(p_user);
        _context.SaveChanges();
        return p_user;
    }

    async public Task<User> UpdateUserAsync(User p_user)
    {
        _context.User.Update(p_user);
        await _context.SaveChangesAsync();
        return p_user;
    }

    public Task<User> UpdateUserBioAsync(int p_userID, string p_userBio)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserBioSizeAsync(int p_userID, string p_userBio, string p_userSize)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserSizeAsync(int p_userID, string p_userSize)
    {
        throw new NotImplementedException();
    }

    public List<User> ViewMatchedUser(int UserID)
    {
        List<User> L1 = _context.Match.Where(match => match.MatcherOneID == UserID).Select(match =>match.MatcherOne).ToList();
        List<User> L2 = _context.Match.Where(match => match.MatcherTwoID == UserID).Select(match =>match.MatcherTwo).ToList();
        List<User> L3 = L1.Concat(L2).ToList();
        return L3;
    }

    async public Task<List<User>> ViewMatchedUserAsync(int UserID)
    {
        List<User> L1 = _context.Match.Where(match => match.MatcherOneID == UserID).Select(match =>match.MatcherOne).ToList();
        List<User> L2 = _context.Match.Where(match => match.MatcherTwoID == UserID).Select(match =>match.MatcherTwo).ToList();
        List<User> L3 = L1.Concat(L2).ToList();
        return L3;
    }
}
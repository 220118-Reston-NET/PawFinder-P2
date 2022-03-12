using System.Data.SqlClient;
using PawFinderModel;

namespace PawFinderDL;
public class SQLRepository : IRepository
{
    private readonly string _connectionString;
    public SQLRepository(string p_connectionString)
    {
        _connectionString = p_connectionString;
    }

    public User RegisterUser(User p_user)
    {
        string sqlQuery = @"INSERT INTO Users
                            VALUES(@userName, @userPassword, @userDOB, @userBio, @userBreed, @userSize)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userName", p_user.UserName);
            command.Parameters.AddWithValue("@userPassword", p_user.UserPassword);
            command.Parameters.AddWithValue("@userDOB", p_user.UserDOB);
            command.Parameters.AddWithValue("@userBio", p_user.UserBio);
            command.Parameters.AddWithValue("@userBreed", p_user.UserBreed);
            command.Parameters.AddWithValue("@userSize", p_user.UserSize);

            command.ExecuteNonQuery();

        }

        return p_user;
    }

    public List<User> GetAllUsers()
    {
        List<User> userList = new List<User>();

        string sqlQuery = @"SELECT * FROM Users";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        { 
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                userList.Add(new User(){
                    UserID = reader.GetInt32(0), 
                    UserName = reader.GetString(1),
                    UserPassword = reader.GetString(2),
                    UserDOB = reader.GetDateTime(3),
                    UserBio = reader.GetString(4),
                    UserBreed = reader.GetString(5),
                    UserSize = reader.GetString(6),
                });
            }
        }

        return userList;
    }

    public User GetUser(int UserID)
    {
        User Result = new User();
        string sqlQuery = @"SELECT * FROM USERS WHERE userID = @userID";
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userID", UserID);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Result = (new User(){
                    UserID = reader.GetInt32(0), 
                    UserName = reader.GetString(1),
                    UserPassword = reader.GetString(2),
                    UserDOB = reader.GetDateTime(3),
                    UserBio = reader.GetString(4),
                    UserBreed = reader.GetString(5),
                    UserSize = reader.GetString(6),
                });
            }
            return Result;

        }
    }

    public List<User> ViewMatchedUser(int UserID)
    {
        List<int> listOfMatchedUserID = new List<int>();
        List<User> listOfMatchedUser = new List<User>();

        string sqlQuery = @"SELECT * FROM MATCHEDUSERS WHERE userID1 = @userID or userID2 = @userID";
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userID", UserID);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if(reader.GetInt32(0) == UserID)
                {
                    listOfMatchedUserID.Add(reader.GetInt32(1));
                }
                else if(reader.GetInt32(1) == UserID)
                {
                    listOfMatchedUserID.Add(reader.GetInt32(0));
                }
            }
            
            foreach(var ID in listOfMatchedUserID)
            {
                listOfMatchedUser.Add(GetUser(ID));
            }

            return listOfMatchedUser;
        }
    }

    public List<int> GetPassedUsersID(int UserID)
    {
        List<int> listOfPassedUsersID = new List<int>();
        
        string sqlQuery = @"SELECT * FROM PassedUsers where passerID = @userID";
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userID", UserID);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                listOfPassedUsersID.Add(reader.GetInt32(1));
            }

            return listOfPassedUsersID;
        }

    }

    public List<Message> GetConversation(int UserID1, int UserID2)
    {
        List<Message> Result = new List<Message>();
        string sqlQuery = @"SELECT * FROM CHATMESSAGE WHERE senderUserID = @userID1 or receiverID = @userID1 or senderUserID = @userID2 or receiverID  = @userID2";
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userID1", UserID1);
            command.Parameters.AddWithValue("@userID2", UserID2);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Result.Add(new Message(){
                    messageID = reader.GetInt32(0),
                    SenderID = reader.GetInt32(1),
                    ReceiverID = reader.GetInt32(2),
                    messageText = reader.GetString(3),
                    messageTimeStamp = reader.GetDateTime(4)
                });
            }

        return Result;
        }
    }

    public User UpdateUser(User p_user)
    {
        User Result = new User();
        string sqlQuery = @"Update Users 
                        set userName = @userName, userPassword = @userPassword, userDOB = @userDOB, userBio = @userBio, userBreed = @userBreed, userSize = @userSize 
                        where userID = @userID";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userName", p_user.UserName);
            command.Parameters.AddWithValue("@userPassword", p_user.UserPassword);
            command.Parameters.AddWithValue("@userDOB", p_user.UserDOB);
            command.Parameters.AddWithValue("@userBio", p_user.UserBio);
            command.Parameters.AddWithValue("@userBreed", p_user.UserBreed);
            command.Parameters.AddWithValue("@userSize", p_user.UserSize);

            command.Parameters.AddWithValue("@userID", p_user.UserID);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Result = (new User(){
                    UserID = reader.GetInt32(0), 
                    UserName = reader.GetString(1),
                    UserPassword = reader.GetString(2),
                    UserDOB = reader.GetDateTime(3),
                    UserBio = reader.GetString(4),
                    UserBreed = reader.GetString(5),
                    UserSize = reader.GetString(6),
                });
            }
            return Result;
        }
    }

    public Message AddMessage(Message message)
    {
        string sqlQuery = @"INSERT INTO ChatMessage
                            VALUES(@senderID,@receiverID, @message, @messageTimeStamp)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@senderID", message.SenderID);
            command.Parameters.AddWithValue("@receiverID", message.ReceiverID);
            command.Parameters.AddWithValue("@message", message.messageText);
            command.Parameters.AddWithValue("@messageTimeStamp", DateTime.Now);

            command.ExecuteNonQuery();

        }

        return message;
    }

    //Async versions of functions=================================================================
    public async Task<User> RegisterUserAsync(User p_user)
    {
        string sqlQuery = @"INSERT INTO Users
                            VALUES(@userName, @userPassword, @userDOB, @userBio, @userBreed, @userSize)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userName", p_user.UserName);
            command.Parameters.AddWithValue("@userPassword", p_user.UserPassword);
            command.Parameters.AddWithValue("@userDOB", p_user.UserDOB);
            command.Parameters.AddWithValue("@userBio", p_user.UserBio);
            command.Parameters.AddWithValue("@userBreed", p_user.UserBreed);
            command.Parameters.AddWithValue("@userSize", p_user.UserSize);

            await command.ExecuteNonQueryAsync();

        }
        return p_user;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        List<User> userList = new List<User>();

        string sqlQuery = @"SELECT * FROM Users";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        { 
            await conn.OpenAsync();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                userList.Add(new User(){
                    UserID = reader.GetInt32(0), 
                    UserName = reader.GetString(1),
                    UserPassword = reader.GetString(2),
                    UserDOB = reader.GetDateTime(3),
                    UserBio = reader.GetString(4),
                    UserBreed = reader.GetString(5),
                    UserSize = reader.GetString(6),
                    Photo = await GetPhotobyUserIDAsync(reader.GetInt32(0))
                });
            }
        }

        return userList;
    }

    public async Task<User> GetUserAsync(int UserID)
    {
        User Result = new User();
        string sqlQuery = @"SELECT * FROM USERS WHERE userID = @userID";
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userID", UserID);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                Result = (new User(){
                    UserID = reader.GetInt32(0), 
                    UserName = reader.GetString(1),
                    UserPassword = reader.GetString(2),
                    UserDOB = reader.GetDateTime(3),
                    UserBio = reader.GetString(4),
                    UserBreed = reader.GetString(5),
                    UserSize = reader.GetString(6),
                    Photo = await GetPhotobyUserIDAsync(reader.GetInt32(0))
                });
            }
            return Result;

        }
    }

    public async Task<List<User>> ViewMatchedUserAsync(int UserID)
    {
        List<int> listOfMatchedUserID = new List<int>();
        List<User> listOfMatchedUser = new List<User>();

        string sqlQuery = @"SELECT * FROM MATCHEDUSERS WHERE userID1 = @userID or userID2 = @userID";
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userID", UserID);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                if(reader.GetInt32(0) == UserID)
                {
                    listOfMatchedUserID.Add(reader.GetInt32(1));
                }
                else if(reader.GetInt32(1) == UserID)
                {
                    listOfMatchedUserID.Add(reader.GetInt32(0));
                }
            }
            
            foreach(var ID in listOfMatchedUserID)
            {
                listOfMatchedUser.Add(GetUser(ID));
            }

            return listOfMatchedUser;
        }
    }

    public async Task<List<Message>> GetConversationAsync(int UserID1, int UserID2)
    {
        List<Message> Result = new List<Message>();
        string sqlQuery = @"SELECT * FROM CHATMESSAGE WHERE senderUserID = @userID1 or receiverID = @userID1 or senderUserID = @userID2 or receiverID  = @userID2";
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userID1", UserID1);
            command.Parameters.AddWithValue("@userID2", UserID2);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                Result.Add(new Message(){
                    messageID = reader.GetInt32(0),
                    SenderID = reader.GetInt32(1),
                    ReceiverID = reader.GetInt32(2),
                    messageText = reader.GetString(3),
                    messageTimeStamp = reader.GetDateTime(4)
                });
            }

        return Result;
        }
    }

    public async Task<User> UpdateUserAsync(User p_user)
    {
        User Result = new User();
        string sqlQuery = @"Update Users 
                        set userName = @userName, userPassword = @userPassword, userDOB = @userDOB, userBio = @userBio, userBreed = @userBreed, userSize = @userSize 
                        where userID = @userID";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userName", p_user.UserName);
            command.Parameters.AddWithValue("@userPassword", p_user.UserPassword);
            command.Parameters.AddWithValue("@userDOB", p_user.UserDOB);
            command.Parameters.AddWithValue("@userBio", p_user.UserBio);
            command.Parameters.AddWithValue("@userBreed", p_user.UserBreed);
            command.Parameters.AddWithValue("@userSize", p_user.UserSize);

            command.Parameters.AddWithValue("@userID", p_user.UserID);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                Result = (new User(){
                    UserID = reader.GetInt32(0), 
                    UserName = reader.GetString(1),
                    UserPassword = reader.GetString(2),
                    UserDOB = reader.GetDateTime(3),
                    UserBio = reader.GetString(4),
                    UserBreed = reader.GetString(5),
                    UserSize = reader.GetString(6),
                });
            }
            return Result;
        }
    }

    public async Task<Message> AddMessageAsync(Message message)
    {
        string sqlQuery = @"INSERT INTO ChatMessage
                            VALUES(@senderID,@receiverID,@message, @messageTimeStamp)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@senderID", message.SenderID);
            command.Parameters.AddWithValue("@receiverID", message.ReceiverID);
            command.Parameters.AddWithValue("@message", message.messageText);
            command.Parameters.AddWithValue("@messageTimeStamp", DateTime.Now);

            await command.ExecuteNonQueryAsync();

        }

        return message;
    }

    public async Task<Photo> AddPhotoAsync(Photo p_photo)
    {
        string sqlQuery = @"INSERT INTO Photos
                            VALUES(@fileName, @userID)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@fileName", p_photo.fileName);
            command.Parameters.AddWithValue("@userID", p_photo.userID);

            await command.ExecuteNonQueryAsync();
        }
        return p_photo;
    }

    public async Task<List<Photo>> GetPhotobyUserIDAsync(int p_userID)
    {
        List<Photo> listofPhoto = new List<Photo>();

        string sqlQuery = @"SELECT p.photoID, p.fileName, p.userID from Photos p
                            WHERE p.userID = @userID";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userID", p_userID);

            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                listofPhoto.Add(new Photo()
                {
                    photoID = reader.GetInt32(0),
                    fileName = reader.GetString(1),
                    userID = reader.GetInt32(2),
                });
            }
        }
        return listofPhoto;
    }

    public async Task<List<int>> GetPassedUsersIDAsync(int UserID)
    {
        List<int> listOfPassedUsersID = new List<int>();
        
        string sqlQuery = @"SELECT * FROM PassedUsers where passerID = @userID";
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@userID", UserID);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                listOfPassedUsersID.Add(reader.GetInt32(1));
                Console.WriteLine(reader.GetInt32(1));
            }

            return listOfPassedUsersID;
        }
    }
}

    


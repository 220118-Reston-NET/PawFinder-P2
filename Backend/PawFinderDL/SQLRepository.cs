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
                    UserSize = reader.GetString(6)
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
                    UserSize = reader.GetString(6)
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
                if(reader.GetInt32(1) == UserID)
                {
                    listOfMatchedUserID.Add(reader.GetInt32(2));
                }
                else if(reader.GetInt32(2) == UserID)
                {
                    listOfMatchedUserID.Add(reader.GetInt32(1));
                }
            }
            
            foreach(var ID in listOfMatchedUserID)
            {
                listOfMatchedUser.Add(GetUser(ID));
            }

            return listOfMatchedUser;
        }
    }

    public List<Message> GetConversation(int UserID1, int UserID2)
    {
        List<Message> Result = new List<Message>();
        string sqlQuery = @"SELECT * FROM CHATMESSAGE WHERE userID1 = @userID1 or userID2 = @userID1 or userID1 = @userID2 or userID2 = @userID2";
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
        string sqlQuery = @"Update User set userName = @userName, userPassword = @userPassword, userDOB = @userDOB, userBio = @userBio, userBreed = @userBreed, userSize = @userSize where userID = @userID";

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
                    UserSize = reader.GetString(6)
                });
            }
            return Result;
        }
    }

    public Message AddMessage(Message message)
    {
        string sqlQuery = @"INSERT INTO ChatMessage
                            VALUES(@senderID,@receiverID,@messageText, @messageTimeStamp)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@senderID", message.SenderID);
            command.Parameters.AddWithValue("@receiverID", message.ReceiverID);
            command.Parameters.AddWithValue("@messagetext", message.messageText);
            command.Parameters.AddWithValue("@messagetext", DateTime.Now);

            command.ExecuteNonQuery();

        }

        return message;
    }
}

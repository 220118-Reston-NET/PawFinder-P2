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
                            VALUES(@userID, @userName, @userPassword, @userDOB, @userBio, @userBreed, @userSize)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@userID", p_user.UserID);
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
                    UserPassword = reader.GetInt32(2),
                    UserDOB = reader.GetDateTime(3),
                    UserBio = reader.GetString(4),
                    UserBreed = reader.GetString(5),
                    UserSize = reader.GetString(6)
                });
            }
        }

        return userList;
    }

    public int CreateUserID()
    {
        int userID = 1000;

        string sqlQuery = @"SELECT count(*) FROM Users";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                userID += reader.GetInt32(0)*10;
            }
        }

        return userID;
    }

    public int CreateConversationID()
    {
        int conversationID = 20000;

        string sqlQuery = @"SELECT count(*) FROM ChatMessage";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                conversationID += reader.GetInt32(0)*10+10;
            }
        }

        return conversationID;
    }

    public int CreatePictureID()
    {
        int pictureID = 300000;

        string sqlQuery = @"SELECT count(*) FROM Pictures";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                pictureID += reader.GetInt32(0)*10+10;
            }
        }

        return pictureID;
    }

}

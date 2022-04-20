using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PawFinderModel
{
    [Keyless]
    public class Like
    {
        public int LikerID { get; set; }
        public User Liker{ get; set; }
        public int LikedID { get; set; }
        public User Liked{ get; set; }
        
    }
}
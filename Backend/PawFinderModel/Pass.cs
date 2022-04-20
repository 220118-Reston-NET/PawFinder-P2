using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PawFinderModel
{
    [Keyless]
    public class Pass
    {
        public int PasserID { get; set; }
        public User Passer{ get; set;}
        public int PasseeID { get; set; }
        public User Passee{ get; set; }
    }
}
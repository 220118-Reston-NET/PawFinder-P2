using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PawFinderModel

{

    [Keyless]
    public class Match
    {
        public int MatcherOneID { get; set; }
        public User MatcherOne{ get; set; }
        public int MatcherTwoID { get; set; }
        public User MatcherTwo{ get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Models
{
    [Table("Favorites")]
    public class FavoriteModel
    {
        
        public int UserId {  get; set; }
        public int HomeId { get; set; }
        public bool IsDeleted { get; set; }
        public UserModel User { get; set; }
        public HomeModel Home { get; set; }
    }
}
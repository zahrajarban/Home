using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Models
{
    [Table("Favorites")]
    public class FavoriteDto
    {
        public int UserId { get; set; }
        public int HomeId { get; set; }
    }
}

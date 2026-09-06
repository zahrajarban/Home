namespace Home.Models
{
    public class FavoriteModel
    {
        public int UserId {  get; set; }
        public int HomeId { get; set; }
        public UserModel User { get; set; }
        public HomeModel Home { get; set; }
    }
}
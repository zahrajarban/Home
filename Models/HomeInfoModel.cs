namespace Home.Models
{
    public class HomeInfoModel
    {
        public int HomeId { get; set; }
        public string Description { get; set; }
        public int Rooms { get; set; }
        public int Floor { get; set; }
        public bool Parking { get; set; }
        public HomeModel Home { get; set; }
    }
}

namespace WebApplication.Resources
{
    public class Photo
    {
        public int id { get; set; }
        public int albumId { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }
}
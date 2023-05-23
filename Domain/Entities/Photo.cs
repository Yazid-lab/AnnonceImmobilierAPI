namespace Domain.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; } = string.Empty;
        public Ad? Ad { get; set; }
        public int AdId { get; set; }

        public Photo()
        {
            
        }
        public Photo(int id, string url, string description, int adId)
        {
            Id = id;
            Url = url;
            Description = description;
            AdId = adId;
        }
    }

}
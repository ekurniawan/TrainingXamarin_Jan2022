namespace BackendWebAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Pic { get; set; }
        public decimal Price { get; set; }
    }
}

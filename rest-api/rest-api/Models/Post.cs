using System.ComponentModel.DataAnnotations;

namespace rest_api.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; } = -1;
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

    }
}

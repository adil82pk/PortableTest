namespace RepositoryLayer.Context
{
    using System.ComponentModel.DataAnnotations;

    public class PinArticle
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string WebUrl { get; set; }
        public string WebTitle { get; set; }
    }
}


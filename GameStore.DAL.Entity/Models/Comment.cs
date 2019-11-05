namespace GameStore.DAL.Entity.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? GameId { get; set; }
        public virtual GameStore.DAL.Entity.Models.Game.Game Game { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual string PublisherName { get; set; }
    }
}

using System;

namespace GameStore.DAL.Entity.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int? GameId { get; set; }
        public GameStore.DAL.Entity.Models.Game.Game Game { get; set; }
        public Comment Parent { get; set; }
        public string Publisher { get; set; }
        public DateTime Created { get; set; }
    }
}

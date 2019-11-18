using System;

namespace GameStore.BLL.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public GameDto Game { get; set; }
        public CommentDto Parent { get; set; }
        public string Publisher { get; set; }
        public DateTime Created { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public GameDto Game { get; set; }
        public CommentDto Parent { get; set; }
        public string Publisher { get; set; }
    }
}

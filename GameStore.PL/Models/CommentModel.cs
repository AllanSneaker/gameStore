
namespace GameStore.PL.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Game { get; set; }
        public string Parent { get; set; }
        public string Publisher { get; set; }
    }
}

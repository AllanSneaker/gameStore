using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.PL.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Game { get; set; }
        public string Parent { get; set; }
        public string Publisher { get; set; }
    }
}

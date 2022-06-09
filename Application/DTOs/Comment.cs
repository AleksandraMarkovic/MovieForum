using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int MovieId { get; set; }
        //public int UserId { get; set; }
    }
}

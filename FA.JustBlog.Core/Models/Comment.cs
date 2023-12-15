using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string CommentHeader { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentTime { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        public virtual Post? Post { get; set; }
    }
}

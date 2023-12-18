using System.ComponentModel.DataAnnotations.Schema;

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

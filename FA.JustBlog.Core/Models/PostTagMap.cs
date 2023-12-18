using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core
{
	public class PostTagMap : BaseEntity
    {
        [ForeignKey("Post")]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}

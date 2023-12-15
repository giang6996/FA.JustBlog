using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

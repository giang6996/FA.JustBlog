using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class Post : BaseEntity
    {
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string? Title { get; set; }

        [MaxLength(1000, ErrorMessage = "The {0} must less than {1} characters")]
        public string? ShortDescription { get; set; }

        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 4)]
        public string? ImageUrl { get; set; }

        public string? PostContent { get; set; }

        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string? UrlSlug { get; set; }

        public bool Published { get; set; }

        public DateTime PublishedDate { get; set; }

        public int ViewCount { get; set; }

        public int RateCount { get; set; }

        public int TotalRate { get; set; }

        public decimal Rate => RateCount == 0 ? 0 : TotalRate / RateCount;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<PostTagMap> PostTags { get; set; }

    }
}

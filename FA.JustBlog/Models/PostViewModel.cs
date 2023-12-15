using FA.JustBlog.Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Models
{
    public class PostViewModel

    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [MaxLength(1000, ErrorMessage = "The {0} must less than {1} characters")]
        public string? ShortDescription { get; set; }

        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 4)]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string? PostContent { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
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

        //public virtual Category Category { get; set; }

        public virtual ICollection<PostTagMap>? PostTags { get; set; }
    }
}

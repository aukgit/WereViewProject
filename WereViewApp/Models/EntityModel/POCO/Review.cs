//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeReviewApp.Models.EntityModel {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Review {
        public Review() {
            this.ReviewLikeDislikes = new HashSet<ReviewLikeDislike>();
        }
        public long ReviewID { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Description = "(ASCII 30) Title of your review. What you think in short.")]
        public string Title { get; set; }
        [Required]
        [StringLength(300)]
        [MinLength(50, ErrorMessage = "It should be minimum 50 characters with valid points.")]
        [Display(Description = "(ASCII 300) Pros about this app.")]
        public string Pros { get; set; }
        [StringLength(300)]
        [Required]
        [MinLength(50, ErrorMessage = "It should be minimum 50 characters with valid points.")]
        [Display(Description = "(ASCII 300) Cons about this app.")]
        public string Cons { get; set; }
        [Required]
        [Display(Name = "Recommend other users.")]
        public bool IsSuggest { get; set; }
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        [Required]
        public long AppID { get; set; }
        [Required]
        public long UserID { get; set; }
        [StringLength(590)]
        [Required]

        [Display(Name = "Thoughts", Description = "(ASCII 590) Thoughts/Summary about this app.")]
        [MinLength(60, ErrorMessage = "It should be minimum 60 characters with valid points.")]
        public string Comments { get; set; }
        [DisplayName("Liked")]
        public int LikedCount { get; set; }
        [DisplayName("Disliked")]
        public int DisLikeCount { get; set; }
        [Required]
        public byte Rating { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual App App { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ReviewLikeDislike> ReviewLikeDislikes { get; set; }
    }
}

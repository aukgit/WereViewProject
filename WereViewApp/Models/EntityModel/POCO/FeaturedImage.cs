//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeReviewApp.Models.EntityModel
{
    using System;
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    
    public partial class FeaturedImage
    {
        public long FeaturedImageID { get; set; }

        [Display(Name="App", Description="Please select app that you like make featured. Will be available in the front page gallery.")]
        public long AppID { get; set; }
        [Display(Name = "Is Featured (means available in single app pages).", Description = "Please select app that you like make featured.")]
        public bool IsFeatured { get; set; }
        public long UserID { get; set; }
    
        public virtual App App { get; set; }
        public virtual User User { get; set; }
    }
}

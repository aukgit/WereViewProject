//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeReviewApp.Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TempUpload
    {
        public System.Guid TempUploadID { get; set; }
        public long UserID { get; set; }
        public long? AppID { get; set; }
        public System.Guid GalleryID { get; set; }
        public Guid? RelatingUploadGuidForDelete { get; set; }
    }
}

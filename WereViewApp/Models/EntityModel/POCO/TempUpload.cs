//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace WereViewApp.Models.EntityModel.POCO
{
    public partial class TempUpload
    {
        public System.Guid TempUploadID { get; set; }
        public long UserID { get; set; }
        public long? AppID { get; set; }
        public System.Guid GalleryID { get; set; }
        public Guid? RelatingUploadGuidForDelete { get; set; }
    }
}

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
    
    public partial class NotificationType
    {
        public NotificationType()
        {
            this.Notifications = new HashSet<Notification>();
        }
    
        public byte NotificationTypeID { get; set; }
        public string TypeName { get; set; }
        public bool IsGood { get; set; }
        public string DefaultMessage { get; set; }
    
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}

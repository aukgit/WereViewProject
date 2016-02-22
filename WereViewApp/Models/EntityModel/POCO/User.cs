namespace WereViewApp.Models.EntityModel {
    using System;
    using System.Collections.Generic;
    using WereViewApp.Models.DesignPattern.Interfaces;

    public partial class User:IDevUser {
        public User() {
            this.Apps = new HashSet<App>();
            this.CellPhones = new HashSet<CellPhone>();
            this.FeaturedImages = new HashSet<FeaturedImage>();
            this.LatestSeenNotifications = new HashSet<LatestSeenNotification>();
            this.Messages = new HashSet<Message>();
            this.Messages1 = new HashSet<Message>();
            this.MessageSeens = new HashSet<MessageSeen>();
            this.MessageSeens1 = new HashSet<MessageSeen>();
            this.Reports = new HashSet<Report>();
            this.Reviews = new HashSet<Review>();
            this.ReviewLikeDislikes = new HashSet<ReviewLikeDislike>();
            this.UserPoints = new HashSet<UserPoint>();
        }

        public long UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }

        public long TotalEarnedPoints { get; set; }
        public virtual ICollection<App> Apps { get; set; }
        public virtual ICollection<CellPhone> CellPhones { get; set; }
        public virtual ICollection<FeaturedImage> FeaturedImages { get; set; }
        public virtual ICollection<LatestSeenNotification> LatestSeenNotifications { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Message> Messages1 { get; set; }
        public virtual ICollection<MessageSeen> MessageSeens { get; set; }
        public virtual ICollection<MessageSeen> MessageSeens1 { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ReviewLikeDislike> ReviewLikeDislikes { get; set; }
        public virtual ICollection<UserPoint> UserPoints { get; set; }
    }
}

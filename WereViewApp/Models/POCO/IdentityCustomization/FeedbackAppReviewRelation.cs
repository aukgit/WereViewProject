﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WereViewApp.Models.POCO.IdentityCustomization {
    public class FeedbackAppReviewRelation {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public long FeedbackAppReviewRelationID { get; set; }
        public long FeedbackID { get; set; }
        /// <summary>
        /// Returns -1 if not valid
        /// </summary>
        public long AppID { get; set; }
        /// <summary>
        /// Returns -1 if not valid
        /// </summary>
        public long ReviewID { get; set; }
        /// <summary>
        /// True :Represents if contains app id
        /// False : Represents ReviewId valid
        /// </summary>
        public bool HasAppId { get; set; }

    }
}
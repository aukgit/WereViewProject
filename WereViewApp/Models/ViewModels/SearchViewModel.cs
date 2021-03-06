﻿using System.Collections.Generic;
using WeReviewApp.Models.EntityModel;

namespace WeReviewApp.Models.ViewModels {
    public class SearchViewModel {
        public string DisplayStringToUser { get; set; }
        public string SearchQuery { get; set; }
        public List<App> FoundApps { get; set; }
        public bool IsPosted { get; set; }

        public bool IsAppExist {
            get { return FoundApps != null && FoundApps.Count > 0; }
        }
    }
}
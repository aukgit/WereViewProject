﻿using System.Web.Mvc;
using WeReviewApp.Models.ViewModels;
using WeReviewApp.Modules.Session;
using WeReviewApp.WereViewAppCommon;
using WeReviewApp.WereViewAppCommon.Structs;

namespace WeReviewApp.Controllers {
    public class SearchController : Controller {
        // GET: Search
        public ActionResult Index() {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(CacheProfile = "Long", VaryByParam = "SearchQuery")]
        public ActionResult Index(string SearchQuery) {
            var max = 60;

            var search = new SearchViewModel();
            var algorithms = new Algorithms();
            //ViewBag.isPostBack = true;
            if (!string.IsNullOrWhiteSpace(SearchQuery)) {
                if (!AppVar.Setting.IsInTestingEnvironment) {
                    if (SessionNames.IsValidationExceed("SearchingFormCount", max)) {
                        var errorRoute = new ErrorsController();
                        return errorRoute.Error(429, null,
                            "You have exceed your search cases. Perhaps you should try tomorrow.");
                    }
                }
                search.SearchQuery = SearchQuery;
                var urlGet = algorithms.GenerateHyphenUrlString(SearchQuery);
                var displayList = urlGet.Split('-');
                var displayStr = string.Join(" ", displayList);
                var results = algorithms.GetSearchResults(SearchQuery, null, null, null,
                                         CommonVars.SearchResultsMaxResultReturn);
                search.DisplayStringToUser = displayStr;
                search.FoundApps = results;
                return View(search);
            }
            search.DisplayStringToUser = "";
            search.FoundApps = null;
            return View(search);
        }
    }
}
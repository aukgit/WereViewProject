﻿#region using block

using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WereViewApp.Models.EntityModel.Structs;
using WereViewApp.Models.ViewModels;
using WereViewApp.Modules.DevUser;
using WereViewApp.WereViewAppCommon;
using WereViewApp.WereViewAppCommon.Structs;

#endregion

namespace WereViewApp.Controllers {
    public class AppsController : AdvanceController {
        #region Declarations

        private readonly Algorithms _algorithms = new Algorithms();

        #endregion

        #region Constructors

        public AppsController()
            : base(true) {
        }

        #endregion

        [OutputCache(CacheProfile = "Day")]
        public ActionResult Latest() {
            ViewBag.Title = "Latest Apps";

            var latest = _algorithms.GetLatestApps(db, 60);
            return View("ListOfApps", latest);
        }

        [OutputCache(CacheProfile = "Day")]
        public ActionResult TopRated() {
            ViewBag.Title = "Top Rated Apps";
            var latest = _algorithms.GetTopRatedApps(db, 60);
            return View("ListOfApps", latest);
        }

        [OutputCache(CacheProfile = "Day", VaryByParam = "id")]
        public ActionResult Category(string id) {
            var cat = WereViewStatics.AppCategoriesCache.FirstOrDefault(n => n.CategoryName == id);
            if (cat != null) {
                ViewBag.Title = "Category : " + id;
                const int max = 60;
                var categoryApps = db.Apps.Where(n => n.CategoryID == cat.CategoryID)
                    .OrderByDescending(n => n.TotalViewed)
                    .ThenByDescending(n => n.AppID)
                    .Include(n => n.Platform)
                    .Take(max)
                    .ToList();

                if (categoryApps != null) {
                    _algorithms.GetEmbedImagesWithApp(categoryApps, db, max, GalleryCategoryIDs.HomePageIcon);
                }
                return View("ListOfApps", categoryApps);
            }
            return HttpNotFound();
        }

        [Authorize]
        public ActionResult Reviewed() {
            ViewBag.Title = "App Reviewed By You";
            var userid = UserManager.GetLoggedUserId();
            var reviews = db.Reviews.Include(r => r.App).Include(r => r.User).Where(n => n.UserID == userid);
            return View(reviews.ToList());
        }

        [OutputCache(CacheProfile = "Day")]
        public ActionResult IOs() {
            ViewBag.Title = "Apple/Apple Apps";

            return PlatformResult(PlatformIDs.Apple);
        }

        [OutputCache(CacheProfile = "Day")]
        public ActionResult Windows() {
            ViewBag.Title = "Windows Apps";
            return PlatformResult(PlatformIDs.Windows);
        }

        [OutputCache(CacheProfile = "Day")]
        public ActionResult Android() {
            ViewBag.Title = "Android Apps";

            return PlatformResult(PlatformIDs.Android);
        }

        public ActionResult PlatformResult(byte platformId) {
            var max = 60;
            var platformApps = db.Apps.Where(n => n.PlatformID == platformId)
                .OrderByDescending(n => n.TotalViewed)
                .OrderByDescending(n => n.AppID)
                .Include(n => n.Platform)
                .Take(max)
                .ToList();

            if (platformApps != null) {
                _algorithms.GetEmbedImagesWithApp(platformApps, db, max, GalleryCategoryIDs.HomePageIcon);
            }
            return View("ListOfApps", platformApps);
        }

    }
}
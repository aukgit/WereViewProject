﻿#region using block

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WereViewApp.Models.Context;
using WereViewApp.Models.POCO.IdentityCustomization;
using WereViewApp.Modules.Role;
using System.Linq;
using WereViewApp.Modules.DevUser;
using System.Data.Entity;
using System.Threading.Tasks;
using WereViewApp.Models.EntityModel;
using WereViewApp.Models.POCO.Structs;
using WereViewApp.Modules.Message;
using WereViewApp.Modules.Session;

#endregion

namespace WereViewApp.Controllers {

    [Authorize]
    public class ReportController : AdvanceController {
        #region Constants and variables

        const string DeletedError = "Sorry for the inconvenience, last record is not removed. Please be in touch with admin.";
        const string DeletedSaved = "Removed successfully.";
        const string EditedSaved = "Modified successfully.";
        const string EditedError = "Sorry for the inconvenience, transaction is failed to save into the database. Please be in touch with admin.";
        const string CreatedError = "Sorry for the inconvenience, couldn't create the last transaction record.";
        const string CreatedSaved = "Transaction is successfully added to the database.";
        const string ControllerName = "Report";
        ///Constant value for where the controller is actually visible.
        const string ControllerVisibleUrl = "/Report/";
        const string CurrentControllerRemoveOutputCacheUrl = "/Partials/GetReportID";
        const string DynamicLoadPartialController = "/Partials/";
        bool DropDownDynamic = true;


        #endregion

        #region Application db

        private ApplicationDbContext db2 = new ApplicationDbContext();

        #endregion

        public ReportController()
            : base(true) {
            ViewBag.visibleUrl = ControllerVisibleUrl;
            ViewBag.dropDownDynamic = DropDownDynamic;
            ViewBag.dynamicLoadPartialController = DynamicLoadPartialController;
        }


        //public ActionResult Done() {
        //    return View();
        //}
        //public ActionResult Later() {
        //    return View();
        //}

        public ActionResult AlreadyReported() {
            return View();
        }
        private bool IsAppAlreadyReported(long appId, out App app) {
            string sessionAlreadyReported = "Report/AppIsAlreadyReported-" + appId;
            string sessionApp = "Report/ReportingApp-" + appId;

            if (Session[sessionAlreadyReported] == null) {
                app = db.Apps.Find(appId);
                var username = UserManager.GetCurrentUserName();
                var alreadyReported = db2.Feedbacks.Any(n => n.Username == username &&
                                                       !n.IsViewed &&
                                                       n.FeedbackAppReviewRelations
                                                        .Any(rel => rel.HasAppId && rel.AppID == appId));
                Session[sessionAlreadyReported] = alreadyReported;
                Session[sessionApp] = app;
            }
            app = (App)Session[sessionApp];
            return (bool)Session[sessionAlreadyReported];
        }

        private bool IsReviewAlreadyReported(long reviewId, out Review review, out App app) {
            string sessionAlreadyReported = "Report/ReviewIsAlreadyReported-" + reviewId;
            string sessionReview = "Report/ReportingReview-" + reviewId;
            string sessionReviewApp = "Report/ReportingReviewApp-" + reviewId;

            if (Session[sessionAlreadyReported] == null) {
                review = db.Reviews.Find(reviewId);
                app = db.Apps.Find(review.AppID);
                var username = UserManager.GetCurrentUserName();
                var alreadyReported = db2.Feedbacks
                                             .Any(n => n.Username == username &&
                                                       !n.IsViewed &&
                                                       n.FeedbackAppReviewRelations
                                                        .Any(rel => !rel.HasAppId && rel.ReviewID == reviewId));
                Session[sessionAlreadyReported] = alreadyReported;
                Session[sessionReview] = review;
                Session[sessionReviewApp] = app;
            }
            review = (Review)Session[sessionReview];
            app = (App)Session[sessionReviewApp];
            return (bool)Session[sessionAlreadyReported];
        }
        /// <summary>
        /// Remove the session cache for either review or app.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isApp">If false remove review cahce.</param>
        private void RemoveSessionCache(long id, bool isApp) {
            if (isApp) {
                string sessionName = "Report/AppIsAlreadyReported-" + id;
                Session[sessionName] = null;
            } else {
                string sessionName = "Report/ReviewIsAlreadyReported-" + id;
                Session[sessionName] = null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">AppId</param>
        /// <returns></returns>
        public ActionResult App(long id) {
            if (SessionNames.IsValidationExceed("App-Report")) {
                return View("Later");
            }
            if (RoleManager.IsInRole(RoleNames.Rookie) == false) {
                return AppVar.GetAuthenticationError("Unauthorized", "");
            }
            // if the app is already reported.
            App app;
            var isAlreadyReported = IsAppAlreadyReported(id, out app);
            if (app != null) {
                if (isAlreadyReported) {
                    ViewBag.isAppReport = true; // if the app is already reported
                    return View("AlreadyReported");
                } else {
                    ViewBag.id = id;
                    ViewBag.app = app;
                    return View();
                }
            }
            return View("_404");
        }

        private void SetCommonFields(Feedback feedback) {
            var user = UserManager.GetCurrentUser();
            feedback.Email = user.Email;
            feedback.Username = user.UserName;
            feedback.Name = user.DisplayName;
            feedback.PostedDate = DateTime.Now;
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> App(Feedback feedback, long appOrReviewId, bool hasAppId) {
            if (SessionNames.IsValidationExceed("App-Report")) {
                return View("Later");
            }
            if (RoleManager.IsInRole(RoleNames.Rookie) == false) {
                // at least has a role.
                // since lowest priority role, it will be added while registering a user.
                return AppVar.GetAuthenticationError("Unauthorized", "");
            }
            App app;
            var isAlreadyReported = IsAppAlreadyReported(appOrReviewId, out app);
            if (isAlreadyReported == false && app != null) {
                if (!ModelState.IsValid) {
                    // non valid message.
                    ViewBag.errorMessage = Const.JunkMessageResult;
                    ViewBag.id = appOrReviewId;
                    ViewBag.app = app;
                    return View();
                }
                // app is not reported before by this user.
                // now post the report.
                db2.Feedbacks.Add(feedback);
                // add the relationship.
                AttachNewRelationship(feedback, appOrReviewId, isApp: true);
                if (db2.SaveChanges() > -1) {
                    // successfully saved.
                    // send an email to the admin.
                    RemoveSessionCache(appOrReviewId, isApp: true);
                    AppVar.Mailer.NotifyAdmin("User reported an app.",
                        "Hi , <br>Please login and check at the admin panel , an app has been reported.");
                    return View("Done");
                }
            }
            ViewBag.isAppReport = true; // if the app is already reported
            return View("AlreadyReported");
        }

        /// <summary>
        /// Attach relationship , category and common fields
        /// </summary>
        /// <param name="feedback"></param>
        /// <param name="id"></param>
        /// <param name="isApp">True means app reporting or else reporting a review.</param>
        /// <returns></returns>
        private FeedbackAppReviewRelation AttachNewRelationship(Feedback feedback, long id, bool isApp) {
            var relation = new FeedbackAppReviewRelation() {
                HasAppId = isApp,
            };
            if (feedback != null) {
                if (isApp) {
                    relation.AppID = id;
                    relation.ReviewID = -1;
                    feedback.FeedbackCategoryID = FeedbackCategoryIDs.MobileAppReport;
                } else {
                    // report review
                    relation.AppID = -1;
                    relation.ReviewID = id;
                    feedback.FeedbackCategoryID = FeedbackCategoryIDs.ReviewReport;
                }
                SetCommonFields(feedback);
                if (feedback.FeedbackAppReviewRelations == null) {
                    feedback.FeedbackAppReviewRelations = new List<FeedbackAppReviewRelation>(2);
                }
                feedback.FeedbackAppReviewRelations.Add(relation);
            }
            return relation;
        }

        public ActionResult Review(long id) {
            if (SessionNames.IsValidationExceed("Review-Report")) {
                return View("Later");
            }
            if (RoleManager.IsInRole(RoleNames.Rookie) == false) {
                // at least has a role.
                // since lowest priority role, it will be added while registering a user.
                return AppVar.GetAuthenticationError("Unauthorized", "");
            }

            Review review;
            App app;
            var isReportedAlready = IsReviewAlreadyReported(id, out review, out app);
            if (isReportedAlready == false && review != null) {
                ViewBag.app = app;
                ViewBag.review = review;
                ViewBag.id = id;
                return View();
            } else if (isReportedAlready && review != null) {
                return View("AlreadyReported");
            }
            return View("_404");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Review(Feedback feedback, long appOrReviewId, bool hasAppId) {
            if (SessionNames.IsValidationExceed("Review-Report")) {
                return View("Later");
            }
            if (RoleManager.IsInRole(RoleNames.Rookie) == false) {
                // at least has a role.
                // since lowest priority role, it will be added while registering a user.
                return AppVar.GetAuthenticationError("Unauthorized", "");
            }
            Review review;
            App app;
            var isReportedAlready = IsReviewAlreadyReported(appOrReviewId, out review, out app);
            if (isReportedAlready == false && review != null) {
                // review is not reported before by this user.
                if (!ModelState.IsValid) {
                    // non valid message.
                    ViewBag.errorMessage = Const.JunkMessageResult;
                    ViewBag.id = appOrReviewId;
                    ViewBag.review = review;
                    ViewBag.app = app;
                    return View(feedback);
                }
                // now post the report.
                db2.Feedbacks.Add(feedback);
                // add the relationship and category.
                AttachNewRelationship(feedback, appOrReviewId, isApp: false);
                if (db2.SaveChanges() > -1) {
                    // successfully saved.
                    // async send an email to the admin.
                    RemoveSessionCache(appOrReviewId, isApp: false);
                    AppVar.Mailer.NotifyAdmin("A user has reported a review.",
                        "Hi , <br>Please login and check at the admin panel , a review has been reported.");
                    return View("Done");
                }
                return View();
            }
            return View("AlreadyReported");
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            db2.Dispose();
        }
    }
}
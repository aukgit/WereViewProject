﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeReviewApp.Controllers;
using WeReviewApp.Models.EntityModel;
using WeReviewApp.WereViewAppCommon;

namespace WeReviewApp.Areas.Admin.Controllers {
    public class AppCategoriesController : AdvanceController {
        #region Constructors

        public AppCategoriesController()
            : base(true) {
            ViewBag.controller = _controllerName;
        }

        #endregion

        #region View tapping

        /// <summary>
        ///     Always tap once before going into the view.
        /// </summary>
        /// <param name="ViewStates">Say the view state, where it is calling from.</param>
        /// <param name="Category">Gives the model if it is a editing state or creating posting state or when deleting.</param>
        /// <returns>If successfully saved returns true or else false.</returns>
        private bool ViewTapping(ViewStates view, Category category = null) {
            switch (view) {
                case ViewStates.Index:
                    break;
                case ViewStates.Create:
                    break;
                case ViewStates.CreatePost: // before saving it
                    WereViewStatics.RefreshCaches();
                    break;
                case ViewStates.Edit:
                    break;
                case ViewStates.Details:
                    break;
                case ViewStates.EditPost: // before saving it
                    WereViewStatics.RefreshCaches();

                    break;
                case ViewStates.Delete:
                    WereViewStatics.RefreshCaches();

                    break;
            }
            return true;
        }

        #endregion

        #region Save database common method

        /// <summary>
        ///     Better approach to save things into database(than db.SaveChanges()) for this controller.
        /// </summary>
        /// <param name="ViewStates">Say the view state, where it is calling from.</param>
        /// <param name="Category">Your model information to send in email to developer when failed to save.</param>
        /// <returns>If successfully saved returns true or else false.</returns>
        private bool SaveDatabase(ViewStates view, Category category = null) {
            // working those at HttpPost time.
            switch (view) {
                case ViewStates.Create:
                    break;
                case ViewStates.Edit:
                    break;
                case ViewStates.Delete:
                    break;
            }

            try {
                var changes = db.SaveChanges(category);
                if (changes > 0) {
                    return true;
                }
            } catch (Exception ex) {
                throw new Exception("Message : " + ex.Message + " Inner Message : " + ex.InnerException.Message);
            }
            return false;
        }

        #endregion

        #region Index

        public ActionResult Index() {
            var viewOf = ViewTapping(ViewStates.Index);
            return View(db.Categories.ToList());
        }

        #endregion

        #region Details

        public ActionResult Details(short id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Categories.Find(id);
            if (category == null) {
                return HttpNotFound();
            }
            var viewOf = ViewTapping(ViewStates.Details, category);
            return View(category);
        }

        #endregion

        #region Removing output cache

        public void RemoveOutputCache(string url) {
            HttpResponse.RemoveOutputCacheItem(url);
        }

        #endregion

        #region Enums

        internal enum ViewStates {
            Index,
            Create,
            CreatePost,
            Edit,
            EditPost,
            Details,
            Delete,
            DeletePost
        }

        #endregion

        #region Developer Comments - Alim Ul karim

        // Generated by Alim Ul Karim on behalf of Developers Organism.
        // Find us developers-organism.com
        // https://www.facebook.com/DevelopersOrganism
        // mailto:alim@developers-organism.com		

        #endregion

        #region Constants

        private const string _deletedError =
            "Sorry for the inconvenience, last record is not removed. Please be in touch with admin.";

        private const string _deletedSaved = "Removed successfully.";
        private const string _editedSaved = "Modified successfully.";

        private const string _editedError =
            "Sorry for the inconvenience, transaction is failed to save into the database. Please be in touch with admin.";

        private const string _createdError = "Sorry for the inconvenience, couldn't create the last transaction record.";
        private const string _createdSaved = "Transaction is successfully added to the database.";
        private const string _controllerName = "AppCategories";

        /// Constant value for where the controller is actually visible.
        private const string _controllerVisibleUrl = "";

        #endregion

        #region DropDowns Generate

        public void GetDropDowns(Category category = null) {}

        public void GetDropDowns(short id) {}

        #endregion

        #region Index Find - Commented

        /*
        public ActionResult Index(System.Int16 id) {
			bool viewOf = ViewTapping(ViewStates.Index);
            return View(db.Categories.Where(n=> n. == id).ToList());
        }
		*/

        #endregion

        #region Create or Add

        public ActionResult Create() {
            GetDropDowns();
            var viewOf = ViewTapping(ViewStates.Create);
            return View();
        }

        /*
        public ActionResult Create(System.Int16 id) {        
            GetDropDowns(id); // Generate hidden.
            bool viewOf = ViewTapping(ViewStates.Create);
            return View();
        }
        */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category) {
            var viewOf = ViewTapping(ViewStates.CreatePost, category);
            GetDropDowns(category);
            if (ModelState.IsValid) {
                db.Categories.Add(category);
                var state = SaveDatabase(ViewStates.Create, category);
                if (state) {
                    AppVar.SetSavedStatus(ViewBag, _createdSaved); // Saved Successfully.
                } else {
                    AppVar.SetErrorStatus(ViewBag, _createdError); // Failed to save
                }

                return View(category);
            }
            AppVar.SetErrorStatus(ViewBag, _createdError); // Failed to Save
            return View(category);
        }

        #endregion

        #region Edit or modify record

        public ActionResult Edit(short id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Categories.Find(id);
            if (category == null) {
                return HttpNotFound();
            }
            var viewOf = ViewTapping(ViewStates.Edit, category);
            GetDropDowns(category); // Generating drop downs
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category) {
            var viewOf = ViewTapping(ViewStates.EditPost, category);
            if (ModelState.IsValid) {
                db.Entry(category).State = EntityState.Modified;
                var state = SaveDatabase(ViewStates.Edit, category);
                if (state) {
                    AppVar.SetSavedStatus(ViewBag, _editedSaved); // Saved Successfully.
                } else {
                    AppVar.SetErrorStatus(ViewBag, _editedError); // Failed to Save
                }

                return RedirectToAction("Index");
            }

            GetDropDowns(category);
            AppVar.SetErrorStatus(ViewBag, _editedError); // Failed to save
            return View(category);
        }

        #endregion

        #region Delete or remove record

        public ActionResult Delete(short id) {
            var category = db.Categories.Find(id);
            var viewOf = ViewTapping(ViewStates.Delete, category);
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id) {
            var category = db.Categories.Find(id);
            var viewOf = ViewTapping(ViewStates.DeletePost, category);
            db.Categories.Remove(category);
            var state = SaveDatabase(ViewStates.Delete, category);
            if (!state) {
                AppVar.SetErrorStatus(ViewBag, _deletedError); // Failed to Save
                return View(category);
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}
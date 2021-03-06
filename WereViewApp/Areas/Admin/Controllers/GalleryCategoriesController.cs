﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WeReviewApp.Controllers;
using WeReviewApp.Models.EntityModel;

namespace WeReviewApp.Areas.Admin.Controllers {
    [OutputCache(NoStore = true, Location = OutputCacheLocation.None)]
    public class GalleryCategoriesController : AdvanceController {
        #region Constructors

        public GalleryCategoriesController() : base(true) {
            ViewBag.controller = _controllerName;
        }

        #endregion

        #region View tapping

        /// <summary>
        ///     Always tap once before going into the view.
        /// </summary>
        /// <param name="ViewStates">Say the view state, where it is calling from.</param>
        /// <param name="GalleryCategory">Gives the model if it is a editing state or creating posting state or when deleting.</param>
        /// <returns>If successfully saved returns true or else false.</returns>
        private bool ViewTapping(ViewStates view, GalleryCategory galleryCategory = null) {
            switch (view) {
                case ViewStates.Index:
                    break;
                case ViewStates.Create:
                    break;
                case ViewStates.CreatePost: // before saving it
                    break;
                case ViewStates.Edit:
                    break;
                case ViewStates.Details:
                    break;
                case ViewStates.EditPost: // before saving it
                    break;
                case ViewStates.Delete:
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
        /// <param name="GalleryCategory">Your model information to send in email to developer when failed to save.</param>
        /// <returns>If successfully saved returns true or else false.</returns>
        private bool SaveDatabase(ViewStates view, GalleryCategory galleryCategory = null) {
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
                var changes = db.SaveChanges(galleryCategory);
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
            return View(db.GalleryCategories.ToList());
        }

        #endregion

        #region Details

        public ActionResult Details(int id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var galleryCategory = db.GalleryCategories.Find(id);
            if (galleryCategory == null) {
                return HttpNotFound();
            }
            var viewOf = ViewTapping(ViewStates.Details, galleryCategory);
            return View(galleryCategory);
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
        private const string _controllerName = "GalleryCategories";

        /// Constant value for where the controller is actually visible.
        private const string _controllerVisibleUrl = "";

        #endregion

        #region DropDowns Generate

        public void GetDropDowns(GalleryCategory galleryCategory = null) {}

        public void GetDropDowns(int id) {}

        #endregion

        #region Index Find - Commented

        /*
        public ActionResult Index(System.Int32 id) {
			bool viewOf = ViewTapping(ViewStates.Index);
            return View(db.GalleryCategories.Where(n=> n. == id).ToList());
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
		public ActionResult Create(System.Int32 id) {        
			GetDropDowns(id); // Generate hidden.
			bool viewOf = ViewTapping(ViewStates.Create);
            return View();
        }
		*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GalleryCategory galleryCategory) {
            var viewOf = ViewTapping(ViewStates.CreatePost, galleryCategory);
            GetDropDowns(galleryCategory);
            if (ModelState.IsValid) {
                db.GalleryCategories.Add(galleryCategory);
                var state = SaveDatabase(ViewStates.Create, galleryCategory);
                if (state) {
                    AppVar.SetSavedStatus(ViewBag, _createdSaved); // Saved Successfully.
                } else {
                    AppVar.SetErrorStatus(ViewBag, _createdError); // Failed to save
                }

                return View(galleryCategory);
            }
            AppVar.SetErrorStatus(ViewBag, _createdError); // Failed to Save
            return View(galleryCategory);
        }

        #endregion

        #region Edit or modify record

        public ActionResult Edit(int id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var galleryCategory = db.GalleryCategories.Find(id);
            if (galleryCategory == null) {
                return HttpNotFound();
            }
            var viewOf = ViewTapping(ViewStates.Edit, galleryCategory);
            GetDropDowns(galleryCategory); // Generating drop downs
            return View(galleryCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GalleryCategory galleryCategory) {
            var viewOf = ViewTapping(ViewStates.EditPost, galleryCategory);
            if (ModelState.IsValid) {
                db.Entry(galleryCategory).State = EntityState.Modified;
                var state = SaveDatabase(ViewStates.Edit, galleryCategory);
                if (state) {
                    AppVar.SetSavedStatus(ViewBag, _editedSaved); // Saved Successfully.
                } else {
                    AppVar.SetErrorStatus(ViewBag, _editedError); // Failed to Save
                }

                return RedirectToAction("Index");
            }

            GetDropDowns(galleryCategory);
            AppVar.SetErrorStatus(ViewBag, _editedError); // Failed to save
            return View(galleryCategory);
        }

        #endregion

        #region Delete or remove record

        public ActionResult Delete(int id) {
            var galleryCategory = db.GalleryCategories.Find(id);
            var viewOf = ViewTapping(ViewStates.Delete, galleryCategory);
            return View(galleryCategory);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            var galleryCategory = db.GalleryCategories.Find(id);
            var viewOf = ViewTapping(ViewStates.DeletePost, galleryCategory);
            db.GalleryCategories.Remove(galleryCategory);
            var state = SaveDatabase(ViewStates.Delete, galleryCategory);
            if (!state) {
                AppVar.SetErrorStatus(ViewBag, _deletedError); // Failed to Save
                return View(galleryCategory);
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}
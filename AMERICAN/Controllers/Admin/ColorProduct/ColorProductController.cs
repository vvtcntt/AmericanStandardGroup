﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMERICAN.Models;
 
using PagedList;
using PagedList.Mvc;
namespace AMERICAN.Controllers.Admin.ColorProduct
{
    public class ColorProductController : Controller
    {
        private AMERICANContext db = new AMERICANContext();

        //private AMERICANContext db = new AMERICANContext();
        // GET: /ColorProduct/

        public ActionResult Index(int? page, string id)
        {
            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            var listUrl = db.tblColorProducts.ToList();

            const int pageSize = 20;
            var pageNumber = (page ?? 1);
            // Thiết lập phân trang
            var ship = new PagedListRenderOptions
            {
                DisplayLinkToFirstPage = PagedListDisplayMode.Always,
                DisplayLinkToLastPage = PagedListDisplayMode.Always,
                DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
                DisplayLinkToNextPage = PagedListDisplayMode.Always,
                DisplayLinkToIndividualPages = true,
                DisplayPageCountAndCurrentLocation = false,
                MaximumPageNumbersToDisplay = 5,
                DisplayEllipsesWhenNotShowingAllPageNumbers = true,
                EllipsesFormat = "&#8230;",
                LinkToFirstPageFormat = "Trang đầu",
                LinkToPreviousPageFormat = "«",
                LinkToIndividualPageFormat = "{0}",
                LinkToNextPageFormat = "»",
                LinkToLastPageFormat = "Trang cuối",
                PageCountAndCurrentLocationFormat = "Page {0} of {1}.",
                ItemSliceAndTotalFormat = "Showing items {0} through {1} of {2}.",
                FunctionToDisplayEachPageNumber = null,
                ClassToApplyToFirstListItemInPager = null,
                ClassToApplyToLastListItemInPager = null,
                ContainerDivClasses = new[] { "pagination-container" },
                UlElementClasses = new[] { "pagination" },
                LiElementClasses = Enumerable.Empty<string>()
            };
            ViewBag.ship = ship;
            return View(listUrl.ToPagedList(pageNumber, pageSize));
        }
     
        public ActionResult Create()
        {
            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            var pro = db.tblColorProducts.OrderByDescending(p => p.Ord).Take(1).ToList();
            if (pro.Count > 0)
                ViewBag.Ord = pro[0].Ord + 1;
            return View();
        }

        //
        // POST: /ColorProduct/Create

        [HttpPost]
         public ActionResult Create(tblColorProduct tblcolorproduct)
        {
            db.tblColorProducts.Add(tblcolorproduct);
            db.SaveChanges();
            #region[Updatehistory]
            Updatehistoty.UpdateHistory("Add tblcolorproduct", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
            #endregion
            return RedirectToAction("Index");
        }

        //
        // GET: /ColorProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            tblColorProduct tblcolorproduct = db.tblColorProducts.Find(id);
            if (tblcolorproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblcolorproduct);
        }

        //
        // POST: /ColorProduct/Edit/5

        [HttpPost]
         public ActionResult Edit(tblColorProduct tblcolorproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcolorproduct).State = EntityState.Modified;
                db.SaveChanges();
                #region[Updatehistory]
                Updatehistoty.UpdateHistory("Edit Url", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
                #endregion
                return RedirectToAction("Index");
            }
            return View(tblcolorproduct);
        }

        //
        // GET: /ColorProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblColorProduct tblcolorproduct = db.tblColorProducts.Find(id);
            if (tblcolorproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblcolorproduct);
        }

        //
        // POST: /ColorProduct/Delete/5
 
        public ActionResult DeleteConfirmed(int id)
        {
            tblColorProduct tblcolorproduct = db.tblColorProducts.Find(id);
            db.tblColorProducts.Remove(tblcolorproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult ColorProductEditOrd(int txtSort, string ts)
        {
            var Url = db.tblColorProducts.Find(txtSort);
            var result = string.Empty;
            Url.Ord = int.Parse(ts);
            //db.Entry(MenuGroupsProduct).State = System.Data.EntityState.Modified;
            result = "Update Ord.";
            db.SaveChanges();
            #region[Updatehistory]
            Updatehistoty.UpdateHistory("Update Ord ColorProduct", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
            #endregion
            return Json(new { result = result });
        }
        [HttpPost]
        public ActionResult ColorProductEditActive(string chk, string nchecked)
        {

            var Url = db.tblColorProducts.Find(int.Parse(chk));
            var result = string.Empty;
            if (nchecked == "true")
            {
                Url.Active = false;
            }
            else
            { Url.Active = true; }

            //db.Entry(MenuGroupsProduct).State = System.Data.EntityState.Modified; 
            db.SaveChanges();
            #region[Updatehistory]
            Updatehistoty.UpdateHistory("Update Active ColorProduct", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
            #endregion
            result = "Updated Active.";
            return Json(new { result = result });
        }
        public ActionResult Command(FormCollection collection)
        {

            if (collection["btnDeleteAll"] != null)
            {
                foreach (string key in Request.Form)
                {
                    var checkbox = "";
                    if (key.StartsWith("chkitem+"))
                    {
                        checkbox = Request.Form["" + key];
                        if (checkbox != "false")
                        {
                            Int32 id = Convert.ToInt32(key.Remove(0, 8));
                            tblColorProduct tblurl = db.tblColorProducts.Find(id);
                            db.tblColorProducts.Remove(tblurl);
                            db.SaveChanges();
                            #region[Updatehistory]
                            Updatehistoty.UpdateHistory("Delete ColorProduct", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
                            #endregion
                            return Redirect("Index");
                        }
                    }
                }
            }
            return RedirectToAction("Index");


        }
    }
}
using CRMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Web.Mvc;

namespace CRMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                var rowsAffected = CustomerDao.Customer_Insert(customer);
                if (rowsAffected > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lỗi rồi");
                }
            }
            return View();
        }

        public ActionResult Index()
        {
            var models = CustomerDao.GetAll();

            if (models == null)
            {
                models = new List<CustomerModel>();
            }

            return View(models);
        }

        public ActionResult Details(int id)
        {
            var model = CustomerDao.GetById(1);

            if (model == null)
            {
                model = new CustomerModel();
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = CustomerDao.GetById(1);

            if (model == null)
            {
                model = new CustomerModel();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerModel customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var rowsAffected = CustomerDao.Customer_Update(customer);
                    if (rowsAffected > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Lỗi rồi");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = CustomerDao.GetById(1);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerModel model)
        {
            var id = model.Id;

            try
            {
                var rowsAffected = CustomerDao.Customer_Delete(id);

                if (rowsAffected > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lỗi rồi");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using CRMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (!ModelState.IsValid)
            {
                //Validation Summary
                return View(customer);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(customer.DoB2))
                {
                    customer.DoB = DateTime.Parse(customer.DoB2);
                }

                if (customer.DoB.HasValue && (customer.DoB.Value.Year < 1900 || customer.DoB.Value.Year > 9999))
                {
                    ModelState.AddModelError(string.Empty, "Trường Ngày sinh không đúng định dạng");

                    return View(customer);
                }

                if (customer.DoB.HasValue && (customer.DoB.Value.Year != customer.YoB))
                {
                    ModelState.AddModelError(string.Empty, "Trường Ngày sinh và Năm sinh không khớp nhau");

                    return View(customer);
                }

                var rowsAffected = CustomerDao.Customer_Insert(customer);
                if (rowsAffected > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Có lỗi xảy ra trong quá trình xử lý.");

                    return View(customer);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerModel customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //Validation Summary
                    return View(customer);
                }
                else
                {
                    //Show DateTime field as String field and HTML Input Date
                    //After then Get DateTime field from String field
                    if (!string.IsNullOrWhiteSpace(customer.DoB2))
                    {
                        customer.DoB = DateTime.Parse(customer.DoB2);
                    }

                    //Validate DoB
                    if (customer.DoB.HasValue && (customer.DoB.Value.Year < 1900 || customer.DoB.Value.Year > 9999))
                    {
                        ModelState.AddModelError(string.Empty, "Trường Ngày sinh không đúng định dạng");

                        return View(customer);
                    }

                    //Validate DoB and YoB
                    if (customer.DoB.HasValue && (customer.DoB.Value.Year != customer.YoB))
                    {
                        ModelState.AddModelError(string.Empty, "Trường Ngày sinh và Năm sinh không khớp nhau");

                        return View(customer);
                    }

                    var rowsAffected = CustomerDao.Customer_Update(customer);
                    if (rowsAffected > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Có lỗi xảy ra trong quá trình xử lý.");

                        return View(customer);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra trong quá trình xử lý.");

                return View(customer);
            }
        }

        public ActionResult Index()
        {
            var models = CustomerDao.GetAll();

            if (models == null)
            {
                models = new List<CustomerModel>();
            }

            foreach (var model in models)
            {
                if (model.DoB.HasValue)
                {
                    model.DoB2 = model.DoB.Value.ToString("dd/MM/yyyy");
                }
            }

            return View(models);
        }

        public ActionResult Details(int id)
        {
            var model = CustomerDao.GetById(id);

            if (model == null)
            {
                model = new CustomerModel();

                ViewBag.NotFound = false;
            }
            else
            {
                ViewBag.NotFound = true;

                if (model.DoB.HasValue)
                {
                    model.DoB2 = model.DoB.Value.ToString("yyyy-MM-dd");
                }
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = CustomerDao.GetById(id);

            if (model == null)
            {
                model = new CustomerModel();

                model.DoB2 = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                if (model.DoB.HasValue)
                {
                    model.DoB2 = model.DoB.Value.ToString("yyyy-MM-dd");
                }

                if (model.Gender.HasValue)
                {
                    model.Gender2 = model.Gender.Value.ToString().ToLower();
                }
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = CustomerDao.GetById(id);

            if (model == null)
            {
                model = new CustomerModel();

                ViewBag.NotFound = false;
            }
            else
            {
                ViewBag.NotFound = true;

                if (model.DoB.HasValue)
                {
                    model.DoB2 = model.DoB.Value.ToString("yyyy-MM-dd");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerModel customer)
        {
            var id = customer.Id;

            try
            {
                if (!ModelState.IsValid)
                {
                    //Validation Summary
                    return View(customer);
                }
                else
                {
                    var rowsAffected = CustomerDao.Customer_Delete(id);

                    if (rowsAffected > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Có lỗi xảy ra trong quá trình xử lý.");

                        return View(customer);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra trong quá trình xử lý.");

                return View(customer);
            }
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
using CRMS.Models;
using System.Collections.Generic;
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
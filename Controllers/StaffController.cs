using Microsoft.AspNetCore.Mvc;
using hocviec.Models;
using System.Data;
using System.Drawing;
using System.Globalization;
namespace hocviec.Controllers;
public class StaffController : Controller
{
[HttpGet]
public ActionResult Index()
        {
            return View();
        }

[HttpGet]
public ActionResult Create()
        {
            return Content("Đang xây dựng");
        }

[HttpPost]
public ActionResult Create(int a)
        {
            return Content("Đang xây dựng");
        }

[HttpGet]
public ActionResult Edit()
        {
            return Content("Đang xây dựng");
        }

[HttpPost]
public ActionResult Update()
        {
            return Content("Đang xây dựng");
        }

[HttpGet]
public ActionResult Delete()
        {
            return Content("Đang xây dựng");
        }

[HttpGet]
public ActionResult Report()
        {
            return Content("Đang xây dựng");
        }
}

using Microsoft.AspNetCore.Mvc;
using hocviec.Models;
using System.Data;
using System.Drawing;
using System.Globalization;
namespace hocviec.Controllers;
public class StaffController : Controller
{

    public List<nhanvien> taonhanvien(List<nhanvien> a,string id, string ten, DateTime ngaysinh, string sdt, string diachi, string chucvu, int tulich)
    {
      nhanvien nhanvienB=new nhanvien(id,ten,ngaysinh,sdt,diachi,chucvu,tulich);
      bool check=a.Any(x=>x.id==id&&x.ten==ten&&x.ngaysinh==ngaysinh);
      if(!check)
      {
        a.Add(nhanvienB);
      }else Console.WriteLine("Da trung voi nhan vien co trong danh sach");
      return a;
    }   
[HttpGet]
public ActionResult Index()
        {
            return View();
        }

[HttpGet]
public ActionResult Create()
        {
            return View();
        }

[HttpPost]
public ActionResult Create(int a)
        {
            return View();
        }

[HttpGet]
public ActionResult Edit()
        {
            return View();
        }

[HttpPost]
public ActionResult Update()
        {
            return View();
        }

[HttpGet]
public ActionResult Delete()
        {
            return View();
        }

[HttpGet]
public ActionResult Report()
        {
            return Content("Đang xây dựng");
        }
}

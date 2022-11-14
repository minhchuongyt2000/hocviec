using Microsoft.AspNetCore.Mvc;
using hocviec.Models;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text.Json;
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
       List<nhanvien> a=new List<nhanvien>();
       DateTime aDateTime = Convert.ToDateTime("1/1/1990");
       nhanvien nhanvien1=new nhanvien("NV-0001", "Chuong",aDateTime, "0913767112", "NgheAn", "TruongPhong", 5);
       nhanvien nhanvien2=new nhanvien("NV-0002", "Cuong",aDateTime , "0983868005", "HaNoi", "NhanVien", 2);
       nhanvien nhanvien3=new nhanvien("NV-0003", "Chung",aDateTime , "0984560892", "HaiPhong", "NhanVien", 2);
       nhanvien nhanvien4=new nhanvien("NV-0004", "Trang",aDateTime , "017772888", "NgheAn", "NhanVien", 2);
       nhanvien nhanvien5=new nhanvien("NV-0005", "Truong",aDateTime , "038389000", "NgheAn", "NhanVien", 2);
       a.Add(nhanvien1);
       a.Add(nhanvien2);
       a.Add(nhanvien3);
       a.Add(nhanvien4);
       a.Add(nhanvien5);
    string json = JsonSerializer.Serialize(a);
       HttpContext.Session.SetString("list", json);
            return View(a);
        }

[HttpGet]
public ActionResult Create()
        {
            return View();
        }

[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create(nhanvien nhanVien)
        {
           var json= HttpContext.Session.GetString("list");
            System.Console.WriteLine(json);
          List<nhanvien> list=JsonSerializer.Deserialize<List<nhanvien>>(json);
      
           if(ModelState.IsValid){
                list.Add(nhanVien);
           }
            return View("Index");
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

using System;
using System.ComponentModel.DataAnnotations;
namespace hocviec.Models
{
    public class nhanvien
    {
        // [RegularExpression(@"^\(NV-)([0-9]{4})$")]
        public string id { get; set; }
        public string ten { get; set; }
        public DateTime ngaysinh { get; set; }
        // [RegularExpression(@"/^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$/")]
        public string sdt { get; set; }
        public string diachi { get; set; }
        public string chucvu { get; set; }
        public int tulich { get; set; }

        public nhanvien(){}

        public nhanvien(string id, string ten, DateTime ngaysinh, string sdt, string diachi, string chucvu, int tulich)
        {
            this.id=id;
            this.ten=ten;
            this.ngaysinh=ngaysinh;
            this.sdt=sdt;
            this.diachi=diachi;
            this.chucvu=chucvu;
            this.tulich=tulich;
        }
        public void innhanvien(){
            Console.WriteLine(id+" "+ten+" "+String.Format("{0:dd:MM:yyyy}",ngaysinh)+" "+sdt+" "+diachi+" "+chucvu+" "+tulich);
        }
    } 


}
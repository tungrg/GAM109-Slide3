using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide3
{
    internal class Program
    {
        
        public static void Main(string[] args) {
            CreateFileWithData();
        }
        public static void CreateFile()
        {
            string path = "C:\\Users\\nhonmuiden\\Desktop\\text.txt";
            FileStream F = new FileStream(path, FileMode.Create);
        }
        public static void CreateFileWithData()
        {
            //Duong dan cua file
            string path = "..\\..\\..\\data.txt";
            //Du lieu muon ghi vao file
            string data = "Tran Thanh Tung";
            //Chuyen du lieu ve kieu byte de tien write file
            byte[] buffer = Encoding.UTF8.GetBytes(data);

            //Su dung khoi buffer de ghi du lieu
            using(FileStream F = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                //Ham write de ghi du lieu
                F.Write(buffer);
            }
        }
    }
}

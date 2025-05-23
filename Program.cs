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
            //CreateFolder();
            CopyTest();
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
        public static void ReadFile()
        {
            string path = "..\\..\\..\\data.txt";
            using (FileStream fr = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                //tao 1 mang du lieu de luu noi dung cua file can doc
                byte[] data = new byte[fr.Length];
                // Doc noi dung file
                fr.Read(data, 0, data.Length);
                //Chuyen tu byte sang string de ghi ra man hinh
                string dataToString = Encoding.UTF8.GetString(data);
                Console.WriteLine(dataToString);
            }
        }
        public static void TextWriteFile()
        {
            string path = "..\\..\\..\\textWriter.txt";
            string data = "hello hello\n1234\n99999";
            using (TextWriter tw = new StreamWriter(path)) {
                tw.WriteLine(data);
            }
        }
        public static void TextReadFile()
        {
            string path = "..\\..\\..\\textWriter.txt";
            using (StreamReader sr = new StreamReader(path)) {
                string data = sr.ReadToEnd();
                Console.WriteLine(data);
            }
        }
        public static void BinaryWriteFile()
        {
            string path = "..\\..\\..\\binaryWriter.bin";
            //BinaryWriter su dung doi tuong stream de khoi tao
            // --> Su dung File ~ Stream
            using(BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                bw.Write(1.2f);
                bw.Write(true);
                bw.Write(false);
            }
        }
        //Ghi xuong nhu nao
        //Doc len nhu vay
        public static void BinaryReadFile()
        {
            string path = "..\\..\\..\\binaryWriter.bin";
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read)))
            {
                float a = br.ReadSingle();
                bool b = br.ReadBoolean();
                bool c = br.ReadBoolean();
                Console.WriteLine($"{a} {b} {c}");
            }
        }
        public static void CreateFolder()
        {
            string path = @"..\..\..\thu muc";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
        }
        public static void CopyAll(DirectoryInfo source, DirectoryInfo destination)
        {
            //Tao ten thuc muc cha
            Directory.CreateDirectory(destination.FullName);
            //Copy toan bo file trong thu muc hien dang dung vao thu muc dich
            foreach (var i in source.GetFiles())
            {
                i.CopyTo(Path.Combine(destination.FullName, i.Name),true);
            }
            //Sao chep thu muc con
            foreach(var j in source.GetDirectories())
            {
                var subFolder = destination.CreateSubdirectory(j.Name);
                CopyAll(j,subFolder);
            }
        }
        public static void CopyTest()
        {
            string path1 = @"..\..\..\thu muc";
            string path2 = @"..\..\..\obj";
            DirectoryInfo des = new DirectoryInfo(path1);
            DirectoryInfo source = new DirectoryInfo(path2);
            CopyAll(source, des);
        }
    }
}

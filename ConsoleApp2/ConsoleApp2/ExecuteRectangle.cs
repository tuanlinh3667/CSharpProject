using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class ExecuteRectangle
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App tinh dien tich");
            Console.WriteLine("----------------------");
            Console.WriteLine("App tinh dien tich");

            //khai bao doi tuong r cua lop Rectangle
            Rectangle r = new Rectangle();
            //goi den cac phuong thuc cuar doi tuong r
            r.AcceptDetailt();
            r.Display();
            Console.ReadLine();

            Console.ReadKey();
        }
    }
}


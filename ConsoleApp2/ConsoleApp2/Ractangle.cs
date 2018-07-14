using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Rectangle
    {
        //cac bien thanh vien
        double length;
        double width;

        //phuong thuc
        public void AcceptDetailt()
        {
            length = 20.5;
            width = 50.4;
        }

        //phuong thuc
        public double GetArea()
        {
            return length * width;
        }

        //phuong thuc 
        public void Display()
        {
            Console.WriteLine("Chieu dai: {0}", length);
            Console.WriteLine("Chieu rong: {0}", width);
            Console.WriteLine("Dien tich: {0}", GetArea());
        }
    }
}

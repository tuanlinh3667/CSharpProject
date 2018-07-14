using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Rectangle
    {
        private double length;
        private double width;


        //contructor
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public Rectangle()
        {
        }


        //get va set 
        public double getLength()
        {
            return length;
        }
        public void setLength(double length)
        {
            this.length = length;
        }
        public double getWidth()
        {
            return width;
        }
        public void setWidth(double width)
        {
            this.width = width;
        }


        public  void AcceptDetailt()
        {
            Console.WriteLine("Enter Your Length: ");
            length = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Your Width: ");
            width = Convert.ToDouble(Console.ReadLine());
        }

        public double GetArea()
        {
            return length * width;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Your length: ", length);
            Console.WriteLine("Your width: ", width);
            Console.WriteLine("Your area: ", GetArea());
        }
    }
}

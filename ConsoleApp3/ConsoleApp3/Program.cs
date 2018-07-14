using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Toán tử sizeof trong C#");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Kích cỡ kiểu int của máy tính: {0}", sizeof(int));
            Console.WriteLine("Kích cỡ kiểu float của máy tính: {0}", sizeof(float));
            Console.WriteLine("Kích cỡ kiểu double của máy tính: {0}", sizeof(double));
            Console.WriteLine("Kích cỡ kiểu char của máy tính: {0}", sizeof(char));

            Console.ReadLine();
            Console.ReadKey();
        }
    }
}

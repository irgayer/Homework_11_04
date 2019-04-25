using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_04
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Name} {Cost}тг");
        }
    }
}

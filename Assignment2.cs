using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Assignment2
    {
       
        static void Main(string[] args)
        {
           
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("even numbers are" );

                for( int i=0;i<numbers.Length;i++)
                 {
                    if(numbers[i]%2==0)
                {
                    Console.WriteLine(numbers[i]);
                }
                 }

            Console.WriteLine("Odd numbers are");

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }
    }
}

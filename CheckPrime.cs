using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class CheckPrime
    {
        static bool isPrimeNumber(int num)
        {
            int count = 0;
            for(int i=1;i<=num;i++)
            {
                if(num%i==0)
                {
                    count++;
                }
            }
            if (count == 2)
            {
                return true;
            }
            else return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter the number to check prime");
            int num = Convert.ToInt32(Console.ReadLine());
            bool res=isPrimeNumber(num); 
            if(res==true)
            {
                Console.WriteLine(num+" is prime number");
            }
            else
                Console.WriteLine(num+" is not a prime number");
        }
    }
}

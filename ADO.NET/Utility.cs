using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCollectionFrameworkApp
{
    class Utility
    {
        public static string promt(string quation)
        {
            Console.WriteLine(quation);
            string answer = Console.ReadLine();
            return answer;
        }
        public static int GetNumber(string quation)
        {
            Console.WriteLine(quation);
            int answer = int.Parse(Console.ReadLine());
            return answer;
        }
    }
}

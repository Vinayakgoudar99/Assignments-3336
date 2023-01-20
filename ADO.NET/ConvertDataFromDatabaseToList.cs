using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace SampleDataAccessApp.Assignments
{
    //4. Write a function to read a CSV file and return a List<T> data and display the data using foreach statement in the Main Program.

    class ConverDataFromCSVTOLISt
    {
        static string Filename = "SampleData.csv";
        private static List<Employees> FileRecord()
        {
            List<Employees> employees = new List<Employees>();
            var record = File.ReadAllLines(Filename);

            foreach (var lines in record)
            {
                var words = lines.Split(',');
                Employees employee = new Employees
                {
                    EmpId = int.Parse(words[0]),
                    EmpName = words[1],
                    EmpCity = words[2],
                    EmpSalary = int.Parse(words[3]),
                    DeptId = Convert.ToInt32( words[4])
                };
                employees.Add(employee);
            }
            return employees;
        }
        static void Main(string[] args)
        {
           var data= FileRecord();
            foreach (var employee in data)
            {
                Console.WriteLine("Employee Name: "+employee.EmpName);
            }
            
        }
    }
}

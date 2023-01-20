using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SampleDataAccessApp.Assignments
{
    //5. Write a function to convert the data from the database into a List<T> 
    //and display the data using foreach statement in the Console Main Program.
    class ConverDataFromDatabaseToList
    {
      static   string STRCONNECT = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
      static   string STRQUERY = "select * from Employee";
        static DataSet data = new DataSet();
        static SqlDataAdapter adapter = null;

        private static void fillReacords()
        {
            SqlConnection con = new SqlConnection(STRCONNECT);
            SqlCommand cmd = new SqlCommand(STRQUERY,con);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            data.Tables[0].TableName = "EmpList";
        }
        private static List<Employees> DataBaseDAtaToListdata()
        {
            fillReacords();
            List<Employees> employees = new List<Employees>();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                Employees employee = new Employees
                {
                    EmpId = (int)row[0],
                    EmpName=row[1].ToString(),
                    EmpCity=row[2].ToString(),
                    EmpSalary=(int)row[3],
                    DeptId=(int)row[4]
                    
                    
                };
                employees.Add(employee);
            }
            return employees;
        }
         static void Main(string[] args)
        {
            var result = DataBaseDAtaToListdata();
            foreach (var employee in result)
            {
                Console.WriteLine(employee.EmpId+"  "+employee.EmpName);
            }
        }
    }
}

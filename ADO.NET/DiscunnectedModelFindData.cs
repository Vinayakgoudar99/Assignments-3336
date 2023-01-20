using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SampleDataAccessApp.Assignments
{
    //6. Write a function that finds Employees with matching Name using disconnected model.
    class DiscunnectedModelFindData
    {
        static string STRCONNECT = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        static string Query = "select * from tb1Employee";
       static DataSet dataset = new DataSet();
        static SqlDataAdapter adapter = null;
        public static void fillRecord()
        {
            SqlConnection con = new SqlConnection(STRCONNECT);
            SqlCommand cmd = new SqlCommand(Query,con);
            adapter = new SqlDataAdapter(cmd);
            SqlCommandBuilder sqlCommand = new SqlCommandBuilder(adapter);
            adapter.Fill(dataset);
            dataset.Tables[0].TableName = "EmployeeList";
            if(dataset.Tables[0].PrimaryKey.Length==0)
            {
                dataset.Tables[0].PrimaryKey = new DataColumn[]
                        {
                            dataset.Tables[0].Columns[0]
                        };
            }

        }
        public static Employees FindEmployee(string empName)
        {
            fillRecord();
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                if(row[1].ToString() == empName)
                {
                    Employees employee = new Employees
                    {
                        EmpId = (int)row[0],
                        EmpName=row[1].ToString(),
                        EmpCity=row[2].ToString(),
                        EmpSalary=Convert.ToInt32(row[3]),
                        DeptId=(int)row[4]
                    };
                    return employee;
                }
                else
                {
                     Console.WriteLine("Employee not found");
                }
            }
            {

            }
            return null;
        }
        static void Main(string[] args)
        {
            var result=FindEmployee("Mallikarjun");
            Console.WriteLine(result.EmpId+" "+result.EmpName);
        }
    }
}

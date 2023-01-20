using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace SampleDataAccessApp.Assignments
{
    // 3. Write a function to join the data of Employee and Dept and display Employees 
    //  with DeptName from a database using Connected model and call the function in the Main program.


    class ConnectedModel
    {
        static string STRCONNECT = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public static void JoinTable()
        {
            string Query = "select empName,DeptName from tb1Employee,tblDept where tb1Employee.DeptId = tblDept.DeptId";
            SqlConnection con = new SqlConnection(STRCONNECT);
            SqlCommand cmd = new SqlCommand(Query, con);

            try
            {
                con.Open();
                var data = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(data);
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine($"Employee Name: {row["empName"]}  Department Name : {row["DeptName"]}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        static void Main(string[] args)
        {

            ConnectedModel.JoinTable();


        }
    
}
    
}

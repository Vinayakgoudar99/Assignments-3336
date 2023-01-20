using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SampleDataAccessApp.Assignments
{
    // 1.Write a function to delete a record in a database using Connected model and 
    //call the function in the Main program
    //2. Write a function to insert a record to a database using Connected model 
    //and call the function in the Main program
    public class Actores
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public int Age { get; set; }
    }
    class ConnectModalApp
    {
        static string STRCONNECT = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        static void InsertData(string name, int age)
        {
            string STRInsert = $"Insert into Actors (ActorName,ActorAge) values('{name}',{age})";
            SqlConnection Con = new SqlConnection(STRCONNECT);
            SqlCommand cmd = new SqlCommand(STRInsert, Con);
            try
            {
                Con.Open();
                var data = cmd.ExecuteNonQuery();
                if (data > 0)
                {
                    Console.WriteLine("Data added");
                }
                else
                {
                    Console.WriteLine("Data not added");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }
        public static DataTable GetActores()
        {
            List<Actores> actores = new List<Actores>();
            string STRQUERY = "select * from Actors";
            SqlConnection con = new SqlConnection(STRCONNECT);
            SqlCommand cmd = new SqlCommand(STRQUERY, con);
            try
            {
                con.Open();
                var table = cmd.ExecuteReader();
                DataTable dataTable = new DataTable("Records");
                dataTable.Load(table);
                return dataTable;
                //foreach (DataRow row in table)
                //{
                //    Actores actor = new Actores {
                //        ActorId = (int)row[0],
                //        ActorName = row[1].ToString(),
                //        Age =(int)row[2]
                //    };
                //    actores.Add(actor);
                //}
                //return actores;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return null;
        }
        public static void deleteActore(int id)
        {
            string STRQUERY = $"Delete Actors where ActorId={id}";
            SqlConnection con = new SqlConnection(STRCONNECT);
            SqlCommand cmd = new SqlCommand(STRQUERY, con);
            try
            {
                con.Open();
                var data = cmd.ExecuteNonQuery();
                if(data>0)
                {
                    Console.WriteLine("data deleted");
                }
                else
                {
                    Console.WriteLine("data deleted");
                }
            }
            catch(Exception ex)
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
            Console.WriteLine("Enter the ActoreName");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Actore Age");
            int age = Convert.ToInt32(Console.ReadLine());
            InsertData(name, age);

            var ActoData = GetActores();
            foreach (DataRow actor in ActoData.Rows)
            {
                Console.WriteLine($"{ "ActoreId:" + actor[0]}  {"ActoreName"+actor[1]}   {"Age:"+actor[2]}");
            }
            Console.WriteLine("Enter the ActoreId from the Above list to delete");
            int ActorId = int.Parse(Console.ReadLine());
            deleteActore(ActorId);
        }
    }

    
}

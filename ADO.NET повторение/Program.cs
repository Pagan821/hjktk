using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADO.NET_повторение
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SqlConnection conn = null;
            //SqlCommand cmd = null;
            //SqlDataReader rdr = null;

            //string connString = ConfigurationManager.ConnectionStrings["ProductMagazinConnectionString"].ConnectionString;
            //Console.WriteLine("Создана строка подключения");
            //string selectString = "select * from Products";
            //Console.WriteLine("Создана строка селекта");
            //conn = new SqlConnection(connString);
            //try
            //{
            //    conn.Open();
            //    Console.WriteLine("Подключение открыто");

            //    cmd = new SqlCommand(selectString, conn);
            //    rdr = cmd.ExecuteReader();
            //    Console.WriteLine("Создана команда ридера");

            //    while (rdr.Read())
            //    {
            //        Console.WriteLine($"{rdr[0]}\t|\t{rdr[1]}\t|\t{rdr[2]}\t|");
            //        Console.WriteLine($"\t{((DateTime)rdr[3]).ToLongDateString()}\t|\t{rdr[4]}\t|\t{rdr[5]}\t|\t{rdr[6]}");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"ОШИБКА: {ex}");
            //}
            //finally
            //{
            //    if (rdr != null)
            //        rdr.Close();
            //    Console.WriteLine("Ридер Закрыт");
            //    if (conn != null)
            //        conn.Close();
            //    Console.WriteLine("Подключение закрыто");
            //}




            SqlCommandBuilder cmd = null;
            SqlDataAdapter adapter = null;
            DataSet dataSet = null;
            string connString = ConfigurationManager.ConnectionStrings["ProductMagazinConnectionString"].ConnectionString;
            Console.WriteLine("Создана строка поключения");
            string selectString = "select * from Products";

            try
            {
                dataSet = new DataSet();
                adapter = new SqlDataAdapter(selectString, connString);
                cmd = new SqlCommandBuilder(adapter);
                adapter.Fill(dataSet, "Categories");

                //for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                //{
                //    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                //    {
                //        Console.Write($"{dataSet.Tables[0].Columns[j]} | ");
                //    }
                //    Console.WriteLine();
                //}

                foreach (DataTable dt in dataSet.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            Console.WriteLine($"{row[column].ToString()}\t|\t");
                        }
                        Console.WriteLine();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ОШИБКА: {ex.Message}");
            }


        }
    }
}

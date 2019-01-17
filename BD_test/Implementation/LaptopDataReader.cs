using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlTypes;
using Dapper;

namespace BD_test.Implementation
{
    public class LaptopDataReader : ILaptopProvider
    {
        public List<LaptopModel> GetLaptops()
        {
            string constring = ConfigurationManager.ConnectionStrings["BD_test"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            Console.WriteLine("OK");
            List<LaptopModel> Laptop_ = new List<LaptopModel>();
            try
            {
                string sql = @"SELECT maker, Laptop.model, speed, ram, hd, price, screen " +
                            "FROM Laptop " +
                            "INNER JOIN Product " +
                            "ON Laptop.model=Product.model";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Connection = con;
                //cmd.CommandText = sql;
                SqlDataReader myReader;
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    int makerId = myReader.GetOrdinal("maker");
                    int modelId = myReader.GetOrdinal("model");
                    int speedId = myReader.GetOrdinal("speed");
                    int ramId = myReader.GetOrdinal("ram");
                    int hdId = myReader.GetOrdinal("hd");
                    int priceId = myReader.GetOrdinal("price");
                    int screenId = myReader.GetOrdinal("screen");
                    LaptopModel LaptopObject = new LaptopModel()
                    {
                        ProductMaker = (string)myReader[makerId],
                        Model = (string)myReader[modelId],
                        CpuSpeed = (Int16)myReader[speedId],
                        RamSize = (Int16)myReader[ramId],
                        DiscSize = (Single)myReader[hdId],
                        Price = (decimal)myReader[priceId],
                        ScreenSize = (byte)myReader[screenId]
                    };

                    Laptop_.Add(LaptopObject);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return Laptop_;
        }

            
    }
}

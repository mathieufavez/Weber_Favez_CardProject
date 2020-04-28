using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PrintTypeDB : IPrintTypeDB
    {
        private string connectionString = null;
        public PrintTypeDB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DemoDB"].ConnectionString;
        }

        public List<PrintType> GetAllPrintType()
        {
            List<PrintType> results = new List<PrintType>();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM PrintType;";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<PrintType>();

                            PrintType printType = new PrintType();

                            printType.Id = (int)dr["IdPrintType"];
                            printType.Description= (string)dr["Description"];
                            printType.Color = (string)dr["Color"];
                            printType.RectoVerso = (string)dr["RectoVerso"];
                            printType.Price = (double)dr["Price"];
                            


                            results.Add(printType);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        public PrintType GetPrintTypeById(int id)
        {
            PrintType result = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM PrintType where IdPrintType = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new PrintType();

                            result.Id = (int)dr["IdPrintType"];
                            result.Description = (string)dr["Description"];
                            result.Color = (string)dr["Color"];
                            result.RectoVerso = (string)dr["RectoVerso"];
                            result.Price = (double)dr["Price"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

    }
}

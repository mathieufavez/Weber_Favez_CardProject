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
    public class PersonDB : IPersonDB
    {
        private string connectionString = null;
        public PersonDB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DemoDB"].ConnectionString;
        }

        public List<Person> GetAllPersons()
        {
            List<Person> results = new List<Person>();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Person;";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Person>();

                            Person person = new Person();

                            person.Id = (int)dr["IdPerson"];
                            person.FirstName = (string)dr["FirstName"];
                            person.LastName = (string)dr["LastName"];
                            person.Username = (string)dr["Username"];
                            person.Balance = (double)dr["Balance"];



                            results.Add(person);
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

        public Person GetPersonById(int id)
        {
            Person result = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Person where IdPerson = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new Person();

                            result.Id = (int)dr["IdPerson"];
                            result.FirstName = (string)dr["FirstName"];
                            result.LastName = (string)dr["LastName"];
                            result.Username = (string)dr["Username"];
                            if (dr["Balance"] != DBNull.Value)
                                result.Balance = (double)dr["Balance"];
                        
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

        public Person GetPersonByUsername(string username)
        {
            Person result = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Person where Username = @username";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new Person();

                            result.Id = (int)dr["IdPerson"];
                            result.FirstName = (string)dr["FirstName"];
                            result.LastName = (string)dr["LastName"];
                            result.Username = (string)dr["Username"];
                            if (dr["Balance"] != DBNull.Value)
                                result.Balance = (double)dr["Balance"];

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

        public int UpdatePersonBalance(Person person)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Person set Balance=@balance WHERE IdPerson=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", person.Id);
                    cmd.Parameters.AddWithValue("@balance", person.Balance);


                    cn.Open();

                    result = cmd.ExecuteNonQuery();
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

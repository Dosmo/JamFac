 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace JamFactory.Controller.Database
{
    public class _3DatabaseController
    {
        static string connectionString = "Server=ealdb1.eal.local;" + "Database=EJL20_DB;" + "User Id=ejl20_usr;" + "Password=Baz1nga20";

        public static void GetActivity()
        {
            List<Model.Activity> activitys = new List<Model.Activity>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand("3_GetActivity", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            activitys.Add(
                                new Model.Activity(
                                    reader["Name"].ToString(),
                                    reader["Description"].ToString(),
                                    reader["TimeCheck"].ToString()) { ID = reader.GetInt32(reader.GetOrdinal("ID")) }
                                    );

                        }
                    }
                    reader.Close();
                }
                catch (SqlException)
                {
                    /*Handle error*/
                }

            }
        }

        public static void CreateActivity(Model.Activity activity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("3_AddActivity", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Name", activity.Name));
                    command.Parameters.Add(new SqlParameter("@Description", activity.Description));
                    command.Parameters.Add(new SqlParameter("@TimeCheck", activity.TimeCheck));
                    command.Parameters.Add(new SqlParameter("@ProductID", activity.Product.ID));
                    command.Parameters.Add(new SqlParameter("@EmployeeID", activity.Employee.ID));
                    activity.ID = (Int32)command.ExecuteScalar();
                }
                catch (SqlException)
                {
                    /*Handle error*/
                }

            }
        }

        public static void CreateMeasurement(Model.Activity activity, Model.Measurement measurement)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("3_AddMeasurement", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Name", measurement.Name));
                    command.Parameters.Add(new SqlParameter("@ExpectedResult", measurement.ExpectedResult));
                    command.Parameters.Add(new SqlParameter("@ActivityID", activity.ID));

                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw new Exception("Error in creating a new Measurement" + e.Message);
                }

            }
        }
        public static List<Model.Employee> GetEmployeeFromPersonID(int personID)
        {
            List<Model.Employee> employees = new List<Model.Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("3_GetEmployeeFromPersonID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@PersonID", personID));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employees.Add(
                                new Model.Employee(
                                    reader.GetInt32(reader.GetOrdinal("ID")),
                                    reader["Password"].ToString(),
                                    DateTime.Parse(reader["Hired"].ToString()),
                                    reader["Name"].ToString()
                                    ));
                        }

                    }
                    reader.Close();
                }
                catch (SqlException)
                {
                    /*Handle error*/
                }
                return employees;
            }
        }

        public static List<Model.Product> GetProductFromID(int productID)
        {
            List<Model.Product> products = new List<Model.Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("3_GetProductFromID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", productID));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            products.Add(
                                new Model.Product(
                                    reader["Variant"].ToString(),
                                    reader.GetInt32(reader.GetOrdinal("Size")),
                                    reader.GetInt32(reader.GetOrdinal("FruitContent")),
                                    double.Parse(reader["Price"].ToString())
                                    )
                                    { ID = reader.GetInt32(reader.GetOrdinal("ID")) }
                                    );
                        }

                    }
                    reader.Close();
                }
                catch (SqlException)
                {
                    /*Handle error*/
                }
                return products;
            }
        }
    }
}
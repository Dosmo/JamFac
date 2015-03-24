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

        public static void GetControl()
        {
            List<Model.Control> activitys = new List<Model.Control>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand("3_GetControl", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            activitys.Add(
                                new Model.Control(
                                    reader["Name"].ToString(),
                                    reader["Description"].ToString(),
                                    reader["TimeCheck"].ToString()) { ID = reader.GetInt32(reader.GetOrdinal("ID")) }
                                    );

                        }
                    }
                    reader.Close();
                }
                catch (SqlException e)
                {
                    throw new Exception("Error in getting Control" + e.Message);
                }

            }
        }

        public static void AddControl(Model.Control control)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("3_AddControl", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Name", control.Name));
                    command.Parameters.Add(new SqlParameter("@Description", control.Description));
                    command.Parameters.Add(new SqlParameter("@TimeCheck", control.TimeCheck));
                    command.Parameters.Add(new SqlParameter("@ProductID", control.Product.ID));
                    command.Parameters.Add(new SqlParameter("@EmployeeID", control.Employee.ID));
                    control.ID = (Int32)command.ExecuteScalar();

                    SqlCommand command2 = new SqlCommand("3_AddActivityLine", connection);
                    command2.CommandType = CommandType.StoredProcedure;

                    foreach (Model.Activity a in control.Activitys) {
                        SqlParameter SqlTitle = new SqlParameter("@AL_Title", a.Title);
                        command2.Parameters.Add(SqlTitle);
                        SqlParameter SqlDescription = new SqlParameter("@AL_Description", a.Description);
                        command2.Parameters.Add(SqlDescription);
                        SqlParameter SqlDetails = new SqlParameter("@AL_Details", a.Details);
                        command2.Parameters.Add(SqlDetails);
                        SqlParameter SqlTime = new SqlParameter("@AL_Time", a.Time);
                        command2.Parameters.Add(SqlTime);
                        SqlParameter SqlExceptedResult = new SqlParameter("@AL_ExpectedResult", a.ExpectedResult);
                        command2.Parameters.Add(SqlExceptedResult);
                        SqlParameter SqlActualResult = new SqlParameter("@AL_ActualResult", a.ActualResult);
                        command2.Parameters.Add(SqlActualResult);

                        command2.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    throw new Exception("Error in adding Control" + e.Message);
                }

            }
        }

        public static void CreateMeasurement(Model.Control activity, Model.Activity measurement)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("3_AddMeasurement", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Name", measurement.Title));
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
                catch (SqlException e)
                {
                    throw new Exception("Error in getting Employee from Person id" + e.Message);
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
                catch (SqlException e)
                {
                    throw new Exception("Error in getting Products from ID" + e.Message);
                }
                return products;
            }
        }
    }
}
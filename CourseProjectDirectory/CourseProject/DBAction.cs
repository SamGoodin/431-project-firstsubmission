using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;

namespace CourseProject
{
    public class DBAction
    {



        public static SqlConnection con;
        public static String cs;

        static DBAction()
        {
            cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            con = new SqlConnection(cs);
        }








        public static ArrayList GetSeasons()
        {

            try
            {
                ArrayList res = new ArrayList();
                con.Open();
                string sql = "select SeasonName from season";

                SqlCommand cmd = new SqlCommand(sql, con);


                SqlDataReader reader = cmd.ExecuteReader();
                // int rowCount = 0;
                while (reader.Read())
                {
                    ArrayList row = new ArrayList();
                    for (int field = 0; field < reader.FieldCount; field++)
                    {
                        string oneValue = reader.GetValue(field).ToString();

                        row.Add(oneValue);
                    }
                    //add the row to the table
                    res.Add(row);
                    //rowCount++;
                }
                reader.Close();
                con.Close();

                return res;
            }
            catch (Exception err)
            {
                err.ToString();
                ArrayList r = new ArrayList();
                return r;
            }
            finally
            {
                con.Close();

            }
        }


        public static string AddSeasons(string season)
        {           
            try
            {
                //Check if Season already exists in table
                con.Open();
                string sqlCheckIfExists = "Select Count(*) from Season Where SeasonName = '" + season + "'";
                SqlCommand checkcmd = new SqlCommand(sqlCheckIfExists, con);
                int thisCount = (int)checkcmd.ExecuteScalar();
                          
                    // Does exist  return string stating it exists                    
                    // Does not exist return string stating it was successfully inserted
                    // or return error
                    if (thisCount != 0)
                    {
                        string exists = "Exists";
                        con.Close();
                        return exists;
                    }else
                    {
                        string isActive = "Yes";
                        string sql = "INSERT INTO Season (SeasonName, Active)VALUES('" + season + "','" + isActive + "')";
                        SqlCommand insertcmd = new SqlCommand(sql, con);
                        insertcmd.ExecuteNonQuery();
                        con.Close();
                        string submitted = "Submitted";
                        return submitted;
                    }
            }
            catch (Exception err)
            {
                return err.Message;
            }
            finally
            {
                con.Close();
            }
        }//End AddSeasons


        public static int AddUser(string prefix, string firstname, string lastname, string email, string password, string phone, string emailNotification)
        {
                        
            try
            {


                int approved = 1;
                string active = "Yes";
                string confirmed = "No";
                DateTime localDate = DateTime.Now;
                con.Open();
                string sql = "INSERT INTO Users(Prefix,FirstName,LastName,Email,Password,Phone,RegisterDate,Approved,ApprovalDate,LastLoginDate,Active,Confirmed,NotificationEmail) VALUES('" + prefix + "','" + firstname + "','" + lastname + "','" + email + "','" + password + "','" + phone + "','" + localDate + "',1,'" + approved + "','" + localDate + "','" + localDate + "','" + active + "','" + confirmed + "','" + emailNotification + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception err)
            {
                err.ToString();
                return 0;

            }
            finally
            {
                con.Close();

            }

        }// End AddUser




        public static bool VerifyEmail(string em)
        {
            try
            {

                // THIS WAS USED FOR TESTING AND ISNT THE ORIGINAL -SR
                con.Open();
                string sql = "select count(*) from customer where email = '" + em + "'";
                SqlCommand cmd = new SqlCommand(sql, con);

                int count = (int)cmd.ExecuteScalar();
                //string email = (string)cmd.ExecuteScalar();
                con.Close();

                if (count == 0)
                    return false;
                else return true;

            }
            catch (Exception err)
            {
                err.ToString();
                return false;
            }
            finally
            {
                con.Close();

            }
        }
                     

        public static Boolean VerifyCustomer(string em, string pwd)
        {
            try
            {
                con.Open();
                string sql = "select count(*) from customer where email = '" + em + "' and pwd='" + pwd + "'";
                SqlCommand cmd = new SqlCommand(sql, con);

                int count = (int)cmd.ExecuteScalar();

                con.Close();

                if (count == 1) //this is an insecured way
                    return true;
                else return false;
            }
            catch (Exception err)
            {
                err.ToString();
                return false;
            }
            finally
            {
                con.Close();

            }
        }
                              
        //if the parameter list is short
        public static Boolean SecureVerifyCustomer1(string em, string pwd)
        {
            try
            {
                con.Open();
                //string sql = "select count(*) from customer where email = '" + em + "' and pwd='" + pwd + "'";

                //Create PROCEDURE [dbo].[sp_verifyCustomer]
                //@em nvarchar(100),
                //@pwd nvarchar(50)
                //AS 
                //SELECT count(*)
                //FROM customer
                //WHERE email = @em and pwd = @pwd;
                string sql = "execute sp_verifyCustomer '" + em + "','" + pwd + "'";
                SqlCommand cmd = new SqlCommand(sql, con);

                int count = (int)cmd.ExecuteScalar();

                con.Close();

                if (count == 1) //specify the exact expected number, instead of count > 0
                    return true;
                else return false;
            }
            catch (Exception err)
            {
                err.ToString();
                return false;
            }
            finally
            {
                con.Close();

            }
        }


        //Supply paramters, provide an OUT variable(if data need to be passed out of the call, e.g. get an autoincremented value)
        //A more standard way.
        public static Boolean SecureVerifyCustomer2(string email, string pwd)
        {
            try
            {
                con.Open();
                //string sql = "select count(*) from customer where email = '" + em + "' and pwd='" + pwd + "'";

                /*
                create procedure sp_verifyCustomer2
                @em nvarchar(100),
                @pwd nvarchar(50),
                @count int OUTPUT
                As
                set @count = (select count(*) from customer where email = @em and pwd=@pwd);
                 */
                SqlCommand cmd = new SqlCommand("sp_verifyCustomer2", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@em", SqlDbType.NVarChar, 100));
                cmd.Parameters["@em"].Value = email;

                cmd.Parameters.Add(new SqlParameter("@pwd", SqlDbType.NVarChar, 50));
                cmd.Parameters["@pwd"].Value = pwd;

                cmd.Parameters.Add(new SqlParameter("@count", SqlDbType.Int, 4));
                cmd.Parameters["@count"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                //int c = (int)cmd.ExecuteScalar();
                int count = (int)cmd.Parameters["@count"].Value;
                con.Close();

                if (count == 1) //specify the exact expected number, instead of count > 0
                    return true;
                else return false;
            }
            catch (Exception err)
            {
                err.ToString();
                return false;
            }
            finally
            {
                con.Close();

            }
        }

        public static string GetPwd(string em)
        {
            try
            {
                string sql = "select pwd from customer where email = '" + em + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                string pwd = (string)cmd.ExecuteScalar();

                con.Close();

                return pwd;
            }
            catch (Exception err)
            {
                err.ToString();
                return "";
            }
            finally
            {
                con.Close();

            }
        }

        public static string GetOneValue(string sql)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                string value = (string)cmd.ExecuteScalar();

                con.Close();

                return value;
            }
            catch (Exception err)
            {
                err.ToString();
                return "";
            }
            finally
            {
                con.Close();

            }
        }

        public static int GetOneInt(string sql)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                int value = (int)cmd.ExecuteScalar();

                con.Close();

                return value;
            }
            catch (Exception err)
            {
                err.ToString();
                return -9999;
            }
            finally
            {
                con.Close();

            }
        }

        public static ArrayList GetOneRow(string sql)
        {
            try
            {
                ArrayList res = new ArrayList();
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);


                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);


                reader.Read();
                for (int field = 0; field < reader.FieldCount; field++)
                {
                    string oneValue = reader.GetValue(field).ToString();

                    res.Add(oneValue);
                }


                reader.Close();

                con.Close();

                return res;
            }
            catch (Exception err)
            {
                err.ToString();
                ArrayList r = new ArrayList();
                return r;
            }
            finally
            {
                con.Close();

            }

        }

        public static ArrayList GetRows(string sql)
        {

            try
            {
                ArrayList res = new ArrayList();
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);


                SqlDataReader reader = cmd.ExecuteReader();
                // int rowCount = 0;
                while (reader.Read())
                {
                    ArrayList row = new ArrayList();
                    for (int field = 0; field < reader.FieldCount; field++)
                    {
                        string oneValue = reader.GetValue(field).ToString();

                        row.Add(oneValue);
                    }
                    //add the row to the table
                    res.Add(row);
                    //rowCount++;
                }
                reader.Close();
                con.Close();

                return res;
            }
            catch (Exception err)
            {
                err.ToString();
                ArrayList r = new ArrayList();
                return r;
            }
            finally
            {
                con.Close();

            }
        }









    }// End class DBAction
}//End namespace CourseProject
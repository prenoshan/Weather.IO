using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralUsers
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //makes panel error not visible
            pnlError.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //sets path for connection string
            string root = Server.MapPath("~");
            string DbPath = Path.GetDirectoryName(Path.GetDirectoryName(root)) + @"\WeatherApp";

            AppDomain.CurrentDomain.SetData("DataDirectory", DbPath);

            //creates sql connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //query to select user role from datatbase
            string q_Login = "select user_role from userinfo where username = @username and password = @password";

            //command to execute query
            SqlCommand cmd = new SqlCommand(q_Login,conn);

            //adds values to the scalar variables
            cmd.Parameters.AddWithValue("@username",txtUsername.Text);
            cmd.Parameters.AddWithValue("@password",txtPassword.Text);

            //opens the connection
            conn.Open();

            //stores the user role in a variable
            var queryRes = cmd.ExecuteScalar();

            //show error if no user exists
            if(queryRes == null)
            {
                pnlError.Visible = true;

                txtUsername.Text = "";
                txtPassword.Text = "";

                conn.Close();
            }

            //if user exists
            else if (queryRes.Equals("GeneralUser"))
            {

                //create session to store username
                Session["User"] = txtUsername.Text;

                //creates session to store user id
                Session["UserID"] = getUserID();

                //close connection
                conn.Close();

                //redirect user to view forecasts
                Response.Redirect("viewForecast.aspx");

            }
        }

        private int getUserID()
        {

            //sets the path for the connection string
            string root = Server.MapPath("~");
            string DbPath = Path.GetDirectoryName(Path.GetDirectoryName(root)) + @"\WeatherApp";

            AppDomain.CurrentDomain.SetData("DataDirectory", DbPath);

            //creates the connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //opens the connection
            conn.Open();

            //query to store user id of user that logs in
            string q_UserID = "select user_id from userinfo where username = @username and password = @password";

            //command to execute query
            SqlCommand cmd = new SqlCommand(q_UserID,conn);

            //adds values to the scalar variables
            cmd.Parameters.AddWithValue("@username",txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            //stores user id when command executes
            var userID = cmd.ExecuteScalar();

            //closes the connection
            conn.Close();

            //returns user id
            return Convert.ToInt32(userID);

        }
    }
}
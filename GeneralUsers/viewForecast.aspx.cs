using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralUsers
{
    public partial class viewForecast : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if session is null (no user logged in) then redirect user to login page
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            //sets panel visibility to false
            pnlSuccess.Visible = false;

            //query to select favourite cities for user who logged in
            SqlDataSource1.SelectCommand = "select city from favouritecities where user_id = @userID";
            SqlDataSource1.SelectParameters.Add("userID", Session["UserID"].ToString());


        }

        protected void btnView_Click(object sender, EventArgs e)
        {

            //sets the path for the connection string
            string root = Server.MapPath("~");
            string DbPath = Path.GetDirectoryName(Path.GetDirectoryName(root)) + @"\WeatherApp";

            AppDomain.CurrentDomain.SetData("DataDirectory", DbPath);

            //creates the connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //query that selects the latest forecast for the favourite city the user specifies
            string q_LatestForecast = "select top 1 city as \"City\",date as \"Latest Date\",min_temp as \"Minimum Temperature\",max_temp as \"Maximum Temperature\",Precipitation,Humidity,[Wind Speed] from forecasts where city = @city order by date desc";

            //command to execute the query
            SqlCommand cmd = new SqlCommand(q_LatestForecast, conn);

            //adds value to the scalar variable
            cmd.Parameters.AddWithValue("@city", ddl_FavCities.SelectedValue);

            //opens the connection
            conn.Open();

            //executes the query
            cmd.ExecuteScalar();

            //data adapter to fill datatable
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            //creates datatable
            DataTable dt = new DataTable();

            //fills datatable with latest forecast
            dataAdapter.Fill(dt);

            //sets datasource for gridview
            gvForecast.DataSource = dt;

            //binds gridview
            gvForecast.DataBind();

            //make gridview visible
            gvForecast.Visible = true;

            //close the connection
            conn.Close();

            //make panel visible once latest forecast is displayed
            pnlSuccess.Visible = true;
        }
    }
}
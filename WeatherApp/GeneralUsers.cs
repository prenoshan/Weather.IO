using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class GeneralUsers : Form
    {
        //global variables

        //variables to store max and min forecast details to be highlighted

        int minTempSorted = 0;
        int maxTempSorted = 0;
        int MaxPrecipSorted = 0;
        int MaxHumidSorted = 0;
        int MaxWSpeedSorted = 0;

        //array lists to store the max and min forecast details to be highlighted
        ArrayList minTemps = new ArrayList();

        ArrayList maxTemps = new ArrayList();

        ArrayList maxPrecips = new ArrayList();

        ArrayList maxHumids = new ArrayList();

        ArrayList maxWspeeds = new ArrayList();

        public GeneralUsers()
        {
            InitializeComponent();
        }

        private void GeneralUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            //closes the application
            Application.Exit();
        }

        private void GeneralUsers_Load(object sender, EventArgs e)
        {

            //sets path to the connection string
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            //adjust location of navigation panel
            panel1.Location = new Point(12, 12);

            //set default size of form
            this.Size = new Size(855, 620);

            //method to check if user has favourite cities
            checkFavs();

            //hides and shows relevant panels
            panelForecast.Hide();
            panelVF1.Hide();

        }

        private void checkFavs()
        {
            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //check if user already has favourites
            conn.Open();

            //query to select the number of favourite cities for the user
            string q_CheckFavs = "select count(*) from favouritecities where user_id = @userid";

            //command to execute the query
            SqlCommand cmd = new SqlCommand(q_CheckFavs, conn);

            //adds value to the scalar variable
            cmd.Parameters.AddWithValue("@userid", Login.userId);

            //stores the number of favourites
            var countRows = cmd.ExecuteScalar();

            //if no favourites exist then display panel to show all cities available so user can choose favourites
            if (Convert.ToInt32(countRows) <= 0)
            {
                conn.Close();

                populateCities();

                pnlSummary.Hide();
                pnlSumOne.Hide();

                panelGuserHome.Show();
                panelGuH1.Show();


            }

            //if user has favourites then display summary of their favourites
            if (Convert.ToInt32(countRows) > 0)
            {
                conn.Close();

                populateSummaryFavs();

                panelGuserHome.Hide();
                panelGuH1.Hide();

                pnlSummary.Show();
                pnlSumOne.Show();

            }

            
        }

        private void buttonGuserView_Click(object sender, EventArgs e)
        {
            //controls for the view forecast panel

            this.Size = new Size(1053, 703);

            panel1.Location = new Point(12, 100);

            //hides relevant panels
            panelGuserHome.Hide();
            panelGuH1.Hide();

            //clears cities listbox
            lboxCities.Items.Clear();

            //method to check if user has favourite cities
            populateFavs();

            //shows relevant panels
            panelForecast.Show();
            panelVF1.Show();
        }

        private void populateFavs()
        {
            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //opens connection
            conn.Open();

            //query to select user's favourite cities
            string q_GetFavs = "select city from favouritecities where user_id = @userid";

            //command to execute the query
            SqlCommand cmd = new SqlCommand(q_GetFavs,conn);

            //adds value to the scalar variable
            cmd.Parameters.AddWithValue("@userid",Login.userId);

            //counts number of favourite cities that the user has
            var countRows = cmd.ExecuteScalar();

            //if no favourites saved then prompt user to save some
            if(countRows == null)
            {
                forecastDisplay.Text = "No favourties saved\nPlease go back to the home panel and save some favourites";

                conn.Close();
            }

            //if there are favourites then fill the cities listbox so user can generate forecasts
            else if(countRows != null)
            {
                //data adapter to fill datatable
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                //creates datatable
                DataTable dt = new DataTable();

                //fills datatable
                dataAdapter.Fill(dt);

                //loops through all rows in the datatable and adds cities to the listbox
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lboxCities.Items.Add(dt.Rows[i][0].ToString());
                }

                forecastDisplay.Text = "";

                conn.Close();
            }
        }

        private void buttonGuserHome_Click(object sender, EventArgs e)
        {
            //adjust location of navigation panel

            panel1.Location = new Point(12, 12);

            //set default size of form

            this.Size = new Size(855, 620);

            lbFavsSummary.Items.Clear();
            lboxCitiesUpdate.Items.Clear();

            checkFavs();

            //hide and show relevant panels

            panelForecast.Hide();
            panelVF1.Hide();

        }

        public void populateCities()
        {
            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //query to retrieve cities
            string q_Cities = "select distinct city from forecasts";

            //sql command to execute query
            SqlCommand cmd = new SqlCommand(q_Cities, conn);

            //opens the connection
            conn.Open();

            //sql data adapter to fill datatable
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            //creates a data table
            DataTable dt = new DataTable();

            //fills datatable with cities
            dataAdapter.Fill(dt);

            //populates listbox from datatable

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lboxCitiesUpdate.Items.Add(dt.Rows[i]["CITY"].ToString());
            }

            //closes the connection
            conn.Close();


        }

        private void populateSummaryFavs()
        {

            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //opens the connection
            conn.Open();

            //query to get user's favourite cities
            string q_GetFavs = "select city from favouritecities where user_id = @userid";

            //command to execute the query
            SqlCommand cmd = new SqlCommand(q_GetFavs,conn);

            //adds value to the scalar variable
            cmd.Parameters.AddWithValue("@userid",Login.userId);

            //executes the query
            cmd.ExecuteScalar();

            //data adapter to fill the datatable
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            //creates the datatable
            DataTable dt = new DataTable();

            //fills the datatable
            dataAdapter.Fill(dt);

            //populates listbox from datatable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lbFavsSummary.Items.Add(dt.Rows[i][0].ToString());
            }

            conn.Close();

        }

        private void btnSaveFavs_Click(object sender, EventArgs e)
        {

            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //if no city is selected to save as favourite then prompt user to choose city
            if (lboxCitiesUpdate.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one favourite city", "Error");
            }

            else
            {
                //opens the connection
                conn.Open();

                //loops through all selected cities and saves user's favourite cities in database
                foreach (var item in lboxCitiesUpdate.SelectedItems)
                {
                    //query to save favourite cities
                    string q_InsertFavs = "insert into FavouriteCities(user_id,city) values(@userid,@city)";

                    //command to execute the query
                    SqlCommand cmd = new SqlCommand(q_InsertFavs, conn);

                    //adds values to the scalar variables
                    cmd.Parameters.AddWithValue("@userid", Login.userId);
                    cmd.Parameters.AddWithValue("@city", item);

                    //executes the query
                    cmd.ExecuteScalar();

                }

                //closes the connection
                conn.Close();

                //when everything is valid display success message
                MessageBox.Show("Favourites saved successfully\n\nTo view your favourites summary please click the home panel to refresh\n\nYou can view forecasts for your favourite cities by clicking the button \"View Forecasts\" on the left", "Success");
            }

        }

        private void viewForecast_Click(object sender, EventArgs e)
        {
            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //if no city is selected then prompt to enter a city
            if (lboxCities.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a city", "Error");
            }

            //clears arrays that hold minimum and maximum values so correct minimums and maximums can be calculated for every new forecast that is being displayed
            minTemps.Clear();
            maxTemps.Clear();
            maxPrecips.Clear();
            maxHumids.Clear();
            maxWspeeds.Clear();

            //clears the forecast display textbox
            forecastDisplay.Clear();

            //defines city variable
            string cityName = "";

            //goes through all selected cities in the listbox
            foreach (var item in lboxCities.SelectedItems)
            {

                //converts list item to string and stores it in city variable
                cityName = Convert.ToString(item);

                //query to select the number of forecasts for a city
                string q_CityCount = "select count(*) from forecasts where city = @city and date between @startDate and @endDate";

                //command to execute the query
                SqlCommand cmdOne = new SqlCommand(q_CityCount, conn);

                //adds values to the scalar variables
                cmdOne.Parameters.AddWithValue("@city", cityName);
                cmdOne.Parameters.AddWithValue("@startDate", startDatePicker.Value.ToShortDateString());
                cmdOne.Parameters.AddWithValue("@endDate", endDatePicker.Value.ToShortDateString());

                //opens the connection
                conn.Open();

                //stores the number the number of forecasts for the city
                var cityCount = cmdOne.ExecuteScalar();

                //closes the connection
                conn.Close();

                //loops through the number of forecasts for the selected city
                for (int i = 0; i < Convert.ToInt32(cityCount); i++)
                {
                    //query to view forecast for single city
                    string query = "select * from forecasts where city = @city and date between @startDate and @endDate";

                    //command to execute the query
                    SqlCommand cmd = new SqlCommand(query, conn);

                    //adds values to the scalar variables
                    cmd.Parameters.AddWithValue("@city", cityName);
                    cmd.Parameters.AddWithValue("@startDate", startDatePicker.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@endDate", endDatePicker.Value.ToShortDateString());

                    //opens the connection
                    conn.Open();

                    //data adapter to fill datatable
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                    //closes the connection
                    conn.Close();

                    //creates the datatable
                    DataTable dt = new DataTable();

                    //fills the datatable to store forecast information
                    dataAdapter.Fill(dt);

                    //stores the values for the forecast data from the datatable
                    var city = dt.Rows[i]["CITY"].ToString();
                    var date = dt.Rows[i]["DATE"].ToString();
                    var minTemp = dt.Rows[i]["MIN_TEMP"].ToString();
                    var maxTemp = dt.Rows[i]["MAX_TEMP"].ToString();
                    var precip = dt.Rows[i]["PRECIPITATION"].ToString();
                    var humid = dt.Rows[i]["HUMIDITY"].ToString();
                    var wSpeed = dt.Rows[i]["WIND SPEED"].ToString();

                    //calls method to determine minimums and maximums
                    determineMinMax();

                    //writes to the forecast display textbox
                    forecastDisplay.Text += "City: " + city + "\n";
                    forecastDisplay.Text += "Date: " + date + "\n";

                    //selection structure to highlight minimums and maximums based on the data from the datatable and the determined minimums and maximums
                    if (minTempSorted == Convert.ToInt32(minTemp))
                    {
                        forecastDisplay.Text += "Minimum Temperature: " + minTemp + "° celcius" + " ****Minimum temperature within the date range****" + "\n";
                    }

                    else
                    {
                        forecastDisplay.Text += "Minimum Temperature: " + minTemp + "° celcius" + "\n";
                    }

                    if (maxTempSorted == Convert.ToInt32(maxTemp))
                    {
                        forecastDisplay.Text += "Maximum Temperature: " + maxTemp + "° celcius" + " ****Maximum temperature within the date range****" + "\n";
                    }

                    else
                    {
                        forecastDisplay.Text += "Maximum Temperature: " + maxTemp + "° celcius" + "\n";
                    }

                    if (MaxPrecipSorted == Convert.ToInt32(precip))
                    {
                        forecastDisplay.Text += "Precipitation: " + precip + "%" + " ****Maximum Precipitation within the date range****" + "\n";
                    }

                    else
                    {
                        forecastDisplay.Text += "Precipitation: " + precip + "%" + "\n";
                    }

                    if (MaxHumidSorted == Convert.ToInt32(humid))
                    {
                        forecastDisplay.Text += "Humidity: " + humid + "%" + " ****Maximum Humidity within the date range****" + "\n";
                    }

                    else
                    {
                        forecastDisplay.Text += "Humidity: " + humid + "%" + "\n";
                    }

                    if (MaxWSpeedSorted == Convert.ToInt32(wSpeed))
                    {
                        forecastDisplay.Text += "Wind Speed: " + wSpeed + "km/h" + " ****Maximum Wind Speed within the date range****" + "\n";
                    }

                    else
                    {
                        forecastDisplay.Text += "Wind Speed: " + wSpeed + "km/h" + "\n";
                    }

                    forecastDisplay.Text += "\n";

                    //clears the datatable so new forecast can be stored in it
                    dt.Columns.Clear();
                    dt.Rows.Clear();
                }
            }

            //if no forecast is available within the date range then prompt user
            if (forecastDisplay.Text.Equals("") && lboxCities.SelectedItems.Count > 0)
            {
                forecastDisplay.Text = "No forecast available within specifed date range,\nPlease try another date range";
            }

        }

        private void determineMinMax()
        {
            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //defines city variable
            string cityName = "";

            //loops through the number of forecasts for the selected city
            foreach (var item in lboxCities.SelectedItems)
            {
                //converts list item to string and stores it in city variable
                cityName = Convert.ToString(item);

                //query to select the number of forecasts for a city
                string q_CityCount = "select count(*) from forecasts where city = @city and date between @startDate and @endDate";

                //command to execute the query
                SqlCommand cmdOne = new SqlCommand(q_CityCount, conn);

                //adds values to the scalar variables
                cmdOne.Parameters.AddWithValue("@city", cityName);
                cmdOne.Parameters.AddWithValue("@startDate", startDatePicker.Value.ToShortDateString());
                cmdOne.Parameters.AddWithValue("@endDate", endDatePicker.Value.ToShortDateString());

                //opens the connection
                conn.Open();

                //stores the number the number of forecasts for the city
                var cityCount = cmdOne.ExecuteScalar();

                //closes the connection
                conn.Close();

                //loops through the number of forecasts for the selected city
                for (int i = 0; i < Convert.ToInt32(cityCount); i++)
                {
                    //query to view forecast for single city
                    string query = "select * from forecasts where city = @city and date between @startDate and @endDate";

                    //command to execute the query
                    SqlCommand cmd = new SqlCommand(query, conn);

                    //adds values to the scalar variables
                    cmd.Parameters.AddWithValue("@city", cityName);
                    cmd.Parameters.AddWithValue("@startDate", startDatePicker.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@endDate", endDatePicker.Value.ToShortDateString());

                    //opens the connection
                    conn.Open();

                    //data adapter to fill datatable
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                    //closes the connection
                    conn.Close();

                    //creates the datatable
                    DataTable dt = new DataTable();

                    //fills the datatable
                    dataAdapter.Fill(dt);

                    //stores the values for the forecast data from the datatable
                    var minTemp = dt.Rows[i]["MIN_TEMP"].ToString();
                    var maxTemp = dt.Rows[i]["MAX_TEMP"].ToString();
                    var precip = dt.Rows[i]["PRECIPITATION"].ToString();
                    var humid = dt.Rows[i]["HUMIDITY"].ToString();
                    var wSpeed = dt.Rows[i]["WIND SPEED"].ToString();

                    //adds each forecast data to their respective arrays
                    minTemps.Add(minTemp);
                    maxTemps.Add(maxTemp);
                    maxPrecips.Add(precip);
                    maxHumids.Add(humid);
                    maxWspeeds.Add(wSpeed);

                    //sort the arrays
                    minTemps.Sort();
                    maxTemps.Sort();
                    maxPrecips.Sort();
                    maxHumids.Sort();
                    maxWspeeds.Sort();

                    //stores the minimum and maximums for each forecast item
                    minTempSorted = Convert.ToInt32(minTemps[0]);
                    maxTempSorted = Convert.ToInt32(maxTemps[maxTemps.Count - 1]);
                    MaxPrecipSorted = Convert.ToInt32(maxPrecips[maxPrecips.Count - 1]);
                    MaxHumidSorted = Convert.ToInt32(maxHumids[maxHumids.Count - 1]);
                    MaxWSpeedSorted = Convert.ToInt32(maxWspeeds[maxWspeeds.Count - 1]);

                    //clears the datatable so new forecast can be stored in it
                    dt.Columns.Clear();
                    dt.Rows.Clear();
                }

            }

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //hide current form
            this.Hide();

            //instantiate login form
            Login login = new Login();

            //show login form
            login.Show();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //prompts user if they want to change their favourites
            DialogResult dialogResult =  MessageBox.Show("Warning all current favourites will be deleted, Continue?","Warning",MessageBoxButtons.OKCancel);

            //if dialog result is ok then allow user to select new cities
            if(dialogResult == DialogResult.OK)
            {
                //opens connection
                conn.Open();

                //query to delete user's favourites
                string q_DelteFavs = "delete from favouritecities where user_id = @userid";

                //command to execute the query
                SqlCommand cmd = new SqlCommand(q_DelteFavs,conn);

                //add value to the scalar variables
                cmd.Parameters.AddWithValue("@userid",Login.userId);

                //executes the query
                cmd.ExecuteScalar();

                //close the connection
                conn.Close();

                //hides summary panels
                pnlSummary.Hide();
                pnlSumOne.Hide();

                //shows home panel so user can select new favourites
                panelGuserHome.Show();
                panelGuH1.Show();

                //repopulates cities
                populateCities();
            }

        }

        private void btnStartWebsite_Click(object sender, EventArgs e)
        {
            //starts website for general users
            Process.Start("http://localhost:51524/Default.aspx");
        }
    }
}

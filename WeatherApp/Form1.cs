using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class WeatherApp : Form
    {
        public WeatherApp()
        {

            InitializeComponent();

        }

        //global variables

        //variable to store the city
        string forecastItem;

        //variable to store the forecast ID
        int forecastId;

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

        private void Form1_Load(object sender, EventArgs e)
        {

            //code to set the path for the connection string
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            //set default size of form
            this.Size = new Size(855, 620);

            //sets location of main panel
            panel1.Location = new Point(12, 12);

            //hide and show relevant panels
            panelCaptureData.Hide();
            panelCD1.Hide();
            panelCD2.Hide();
            panelForecast.Hide();
            panelVF1.Hide();
            panelEdit.Hide();

            panelHome.Show();

            //set maximum value for numericUpDown
            minTempInput.Maximum = int.MaxValue;
            maxTempInput.Maximum = int.MaxValue;
            precipInput.Maximum = int.MaxValue;
            humidInput.Maximum = int.MaxValue;
            wSpeedInput.Maximum = int.MaxValue;

        }

        private void populateEditlbox()
        {

            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //opens the connection
            conn.Open();

            //query to get city and forecast number from database
            string q_Forecasts = "select CONCAT(city,' ',forecast_id) as \"Forecast\" from Forecasts";

            //command to execute the query
            SqlCommand cmd = new SqlCommand(q_Forecasts, conn);

            //data adapter to fill datatable
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            //creates the datatable
            DataTable dt = new DataTable();

            //fills the datatable
            dataAdapter.Fill(dt);

            //iterates through datatable and populates list box with each city and forecast number
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                lboxEdit.Items.Add("Forecast " + dt.Rows[i]["Forecast"].ToString());

            }

            //closes the connection
            conn.Close();

        }

        private void btnloadData_Click(object sender, EventArgs e)
        {
            //clears the controls if populated so a new forecast can be edited
            clearEditControls();

            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //if no forecast is selected then prompt a user to choose one
            if (lboxEdit.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please choose a forecast to edit", "Error");
            }

            else
            {
                //open the connection
                conn.Open();

                //gets the city from the list box
                forecastItem = lboxEdit.SelectedItem.ToString();

                //gets the forecast number only from the list box
                forecastId = Convert.ToInt32(Regex.Match(forecastItem, @"\d+").Value);

                //query to select forecast data for forecast id 
                string q_SelectForecast = "select * from forecasts where forecast_id = @forecastId";

                //command to execute the query
                SqlCommand cmd = new SqlCommand(q_SelectForecast, conn);

                //sets the scalar variable to the forecast id
                cmd.Parameters.AddWithValue("@forecastId", forecastId);

                //data adapter to fill datatable
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                //creates the datatable
                DataTable dt = new DataTable();

                //fills the datatable
                dataAdapter.Fill(dt);

                //populates the controls with the forecast data from the datatable
                txtEditCity.Text = dt.Rows[0]["CITY"].ToString();
                dtpEdit.Value = DateTime.Parse(dt.Rows[0]["DATE"].ToString());
                nudMinTempEdit.Value = Convert.ToInt32(dt.Rows[0]["MIN_TEMP"]);
                nudMaxTempEdit.Value = Convert.ToInt32(dt.Rows[0]["MAX_TEMP"]);
                nudPrecipEdit.Value = Convert.ToInt32(dt.Rows[0]["PRECIPITATION"]);
                nudHumidityEdit.Value = Convert.ToInt32(dt.Rows[0]["HUMIDITY"]);
                nudWspeedEdit.Value = Convert.ToInt32(dt.Rows[0]["WIND SPEED"]);

                //closes the connection
                conn.Close();

            }

        }

        private void btnUpdateEdit_Click(object sender, EventArgs e)
        {
            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //validation to make sure all fields are filled before forecast can be updated
            if (txtEditCity.Text == "" || nudMinTempEdit.Text == "" || nudMaxTempEdit.Text == "" || nudPrecipEdit.Text == "" || nudHumidityEdit.Text == "" || nudWspeedEdit.Text == "")
            {
                MessageBox.Show("All fields are required to capture a forecast\nPlease try again", "Error");

            }

            else
            {
                //if no forecast is selected then prompt to choose one
                if (forecastId == 0)
                {
                    MessageBox.Show("Please choose a forecast to edit", "Error");

                    //clears controls
                    clearEditControls();
                    lboxEdit.ClearSelected();
                }

                //if all fields valid
                else
                {
                    //opens connection
                    conn.Open();

                    //query to update a forecast
                    string q_Update = "update forecasts set city = @city, date = @date, min_temp = @minTemp, max_temp = @maxTemp, precipitation = @precip, humidity = @humid, [wind speed] = @windSpeed where forecast_id = @forecastId";

                    //command to execute the query
                    SqlCommand cmd = new SqlCommand(q_Update, conn);

                    //adds values to the scalar variables so a forecast can be updated
                    cmd.Parameters.AddWithValue("@forecastId", forecastId);
                    cmd.Parameters.AddWithValue("@city", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtEditCity.Text));
                    cmd.Parameters.AddWithValue("@date", dtpEdit.Value.Date);
                    cmd.Parameters.AddWithValue("@minTemp", Convert.ToInt32(nudMinTempEdit.Value));
                    cmd.Parameters.AddWithValue("@maxTemp", Convert.ToInt32(nudMaxTempEdit.Value));
                    cmd.Parameters.AddWithValue("@precip", Convert.ToInt32(nudPrecipEdit.Value));
                    cmd.Parameters.AddWithValue("@humid", Convert.ToInt32(nudHumidityEdit.Value));
                    cmd.Parameters.AddWithValue("@windSpeed", Convert.ToInt32(nudWspeedEdit.Value));

                    //executes the query
                    cmd.ExecuteScalar();

                    //closes the connection
                    conn.Close();

                    //resets controls and forecast id so new forecast can be added
                    forecastId = 0;
                    clearEditControls();
                    lboxEdit.ClearSelected();
                    lboxEdit.Items.Clear();
                    populateEditlbox();

                    //if no errors then display update successful
                    MessageBox.Show("Update successful", "Success");
                }
            }


        }

        private void captureDataClick(object sender, EventArgs e)
        {

            //creates the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //validation to make sure all fields are filled before forecast can be created
            if (tbCity.Text == "" || minTempInput.Text == "" || maxTempInput.Text == "" || precipInput.Text == "" || humidInput.Text == "" || wSpeedInput.Text == "")
            {
                MessageBox.Show("All fields are required to capture a forecast\nPlease try again", "Error");
            }


            else
            {
                //opens connection
                conn.Open();

                //query to check if forecast already exists for city and date range to avoid inserting duplicate values
                string q_UpdateValidate = "select count(*) from Forecasts where city = @city and date = @date";

                //command to execute the query
                SqlCommand cmdUpdateValidate = new SqlCommand(q_UpdateValidate, conn);

                //adds values to the scalar variables
                cmdUpdateValidate.Parameters.AddWithValue("@city", tbCity.Text);
                cmdUpdateValidate.Parameters.AddWithValue("@date", datePicker.Value.Date);

                //gets the rows where a forecast exists
                var countRows = cmdUpdateValidate.ExecuteScalar();

                //closes the connection
                conn.Close();

                //if forecast exists then prompt user
                if (Convert.ToInt32(countRows) > 0)
                {
                    MessageBox.Show("Records already exist for the city with the date range you've specified", "Error");

                }

                //if all is valid
                else
                {
                    //open the connection
                    conn.Open();

                    //query to insert a forecast
                    string q_Insert = "insert into forecasts(city,date,min_temp,max_temp,precipitation,humidity,[wind speed]) values (@city,@date,@minTemp,@maxTemp,@precip,@humid,@wSpeed)";

                    //command to execute the query
                    SqlCommand cmd = new SqlCommand(q_Insert, conn);

                    //adds values to the scalar variables
                    cmd.Parameters.AddWithValue("@city", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tbCity.Text));
                    cmd.Parameters.AddWithValue("@date", datePicker.Value.Date);
                    cmd.Parameters.AddWithValue("@minTemp", Convert.ToInt32(minTempInput.Value));
                    cmd.Parameters.AddWithValue("@maxTemp", Convert.ToInt32(maxTempInput.Value));
                    cmd.Parameters.AddWithValue("@precip", Convert.ToInt32(precipInput.Value));
                    cmd.Parameters.AddWithValue("@humid", Convert.ToInt32(humidInput.Value));
                    cmd.Parameters.AddWithValue("@wSpeed", Convert.ToInt32(wSpeedInput.Value));

                    //executes the query
                    cmd.ExecuteScalar();

                    //closes the connection
                    conn.Close();

                    //displays successful insert when everything inserts fine
                    MessageBox.Show("Forecast Captured Successfully", "Success");

                }


            }
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

            //populates listbox from datatable with cities
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lboxCities.Items.Add(dt.Rows[i]["CITY"].ToString());
            }

            //closes the connection
            conn.Close();


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

        private void btnHomeClick(object sender, EventArgs e)
        {

            //controls for the home panel
            this.Size = new Size(855, 620);

            panel1.Location = new Point(12, 12);

            panelCaptureData.Hide();
            panelCD1.Hide();
            panelCD2.Hide();
            panelForecast.Hide();
            panelVF1.Hide();
            panelEdit.Hide();

            panelHome.Show();


        }

        private void btnCaptureClick(object sender, EventArgs e)
        {

            //controls for the capture data panel
            this.Size = new Size(855, 620);

            panel1.Location = new Point(12, 12);

            panelForecast.Hide();
            panelHome.Hide();
            panelVF1.Hide();
            panelEdit.Hide();


            panelCaptureData.Show();
            panelCD1.Show();
            panelCD2.Show();

            clearAll();
        }

        private void btnForecastClick(object sender, EventArgs e)
        {
            //controls for the view forecast panel
            this.Size = new Size(1053, 703);

            panel1.Location = new Point(12, 100);

            panelHome.Hide();
            panelCaptureData.Hide();
            panelCD1.Hide();
            panelCD2.Hide();
            panelEdit.Hide();

            panelForecast.Show();
            panelVF1.Show();

            //clears and populates countries listbox when panel is shown
            lboxCities.Items.Clear();
            populateCities();

            forecastDisplay.Text = "";
            startDatePicker.Value = DateTime.Now;
            endDatePicker.Value = DateTime.Now;


        }

        private void clearAll()
        {

            //resets all values 
            tbCity.Text = "";
            datePicker.Value = DateTime.Now;
            minTempInput.Value = 0;
            maxTempInput.Value = 0;
            precipInput.Value = 0;
            humidInput.Value = 0;
            wSpeedInput.Value = 0;

        }

        private void btnClearCapture_Click_1(object sender, EventArgs e)
        {
            //calls clear method

            clearAll();
        }

        private void buttonEdit_click(object sender, EventArgs e)
        {
            //controls for the edit forecast panel

            this.Size = new Size(1096, 713);

            panel1.Location = new Point(12, 100);

            panelHome.Hide();
            panelCaptureData.Hide();
            panelCD1.Hide();
            panelCD2.Hide();

            panelEdit.Show();
            panelEditForm.Show();
            panelEF1.Show();

            lboxEdit.Items.Clear();

            populateEditlbox();

        }

        private void WeatherApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            //closes application 
            Application.Exit();
        }

        private void btnClearEdit_Click(object sender, EventArgs e)
        {
            //clears edit panel controls
            forecastId = 0;
            clearEditControls();
        }

        private void clearEditControls()
        {
            //clears edit controls
            txtEditCity.Text = "";
            dtpEdit.Value = DateTime.Now;
            nudMinTempEdit.Value = 0;
            nudMaxTempEdit.Value = 0;
            nudPrecipEdit.Value = 0;
            nudHumidityEdit.Value = 0;
            nudWspeedEdit.Value = 0;
        }

        private void lboxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //calls clear method when new forecast is selected
            clearEditControls();
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
    }
}

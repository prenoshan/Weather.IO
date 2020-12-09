using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        public static int userId;

        private void Login_Load(object sender, EventArgs e)
        {

            //sets the path for the connection string
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            //sets the default size of the form

            this.Size = new Size(530, 314);

            //hides and shows relevant panels

            panelLoginPage.Show();
            panelLP1.Show();

            panelUserLogin.Hide();
            panelUL1.Hide();
            panelReg.Hide();
            panelR1.Hide();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //hides and shows relevant panels

            panelLoginPage.Hide();
            panelLP1.Hide();
            panelReg.Hide();
            panelR1.Hide();

            //sets the size of the form
            this.Size = new Size(560, 420);

            panelUserLogin.Show();
            panelUL1.Show();


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //hides and shows relevant panels
            panelLoginPage.Hide();
            panelLP1.Hide();

            //sets the size of the form
            this.Size = new Size(734, 527);

            panelReg.Show();
            panelR1.Show();

        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {

            //creates the sql connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //stores the admin code for admins
            string adminCode = "@dm7n";

            //opens the connection
            conn.Open();

            //query to check if username already exists
            string q_ValidateUsername = "select count(username) from userinfo where username = @username";

            //command to execute query
            SqlCommand cmdValidateUsername = new SqlCommand(q_ValidateUsername, conn);

            //stores values for the scalar variables
            cmdValidateUsername.Parameters.AddWithValue("@username", tbUsernameRegister.Text);

            //counts rows where username exists
            var countRows = cmdValidateUsername.ExecuteScalar();

            //if username exists then display prompt to try another username
            if (Convert.ToInt32(countRows) > 0)
            {
                MessageBox.Show("Username already exists, Please try another username", "Error");

                tbUsernameRegister.Text = "";
                tbPasswordRegister.Text = "";
                tbAdminCodeRegister.Text = "";
            }

            //if controls are empty then prompt user to fill username and password
            else
            {
                if(string.IsNullOrEmpty(tbUsernameRegister.Text) || string.IsNullOrEmpty(tbPasswordRegister.Text))
                {
                    MessageBox.Show("Username and Password is required for account creation","Error");

                }

                //if all is valid
                else
                {
                    //query to create a new user
                    string q_RegUser = "insert into userinfo(username,password,user_Role) values(@username,@password,@userRole);";

                    //command to execute query
                    SqlCommand cmd = new SqlCommand(q_RegUser, conn);

                    //adds value to the scalar variables
                    cmd.Parameters.AddWithValue("@username", tbUsernameRegister.Text);
                    cmd.Parameters.AddWithValue("@password", tbPasswordRegister.Text);

                    //if user is admin then create user as admin
                    if (tbAdminCodeRegister.Text.Equals(adminCode))
                    {
                        cmd.Parameters.AddWithValue("@userRole", "Admin");
                    }

                    //else create user as general user
                    else
                    {
                        cmd.Parameters.AddWithValue("@userRole", "GeneralUser");
                    }

                    //execute query
                    cmd.ExecuteScalar();

                    //display user created successfully when user is created
                    MessageBox.Show("User Created successfully", "Success");

                    //reset controls
                    tbUsernameRegister.Text = "";
                    tbPasswordRegister.Text = "";
                    tbAdminCodeRegister.Text = "";
                }

                
            }

            conn.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //sets the size of the form
            this.Size = new Size(530, 314);

            //hides and shows relevant panels

            panelLoginPage.Show();
            panelLP1.Show();

            panelReg.Hide();
            panelR1.Hide();
        }

        private void btnLoginUser_Click(object sender, EventArgs e)
        {

            //creates the sql connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            try
            { 
                //opens the connection
                conn.Open();

                //query to select userRole from database
                string q_UserLogin = "select user_Role from userinfo where username = @username and password = @password";
                
                //command to execute the query
                SqlCommand cmd = new SqlCommand(q_UserLogin, conn);

                //adds values to the scalar variables
                cmd.Parameters.AddWithValue("@username", tbLoginUsername.Text);
                cmd.Parameters.AddWithValue("@password", tbLoginPassword.Text);

                //store user role when query is executed
                string userRole = cmd.ExecuteScalar().ToString();

                //if user is admin then show admin panel
                if (userRole.Equals("Admin"))
                {
                    this.Hide();

                    conn.Close();

                    WeatherApp weatherApp = new WeatherApp();
                    weatherApp.Show();

                }

                //else if user is general user display general user panel
                else if (userRole.Equals("GeneralUser"))
                {
                    this.Hide();

                    conn.Close();

                    userId = getUserID();

                    GeneralUsers generalUsers = new GeneralUsers();
                    generalUsers.Show();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid Credentials, Please try again","Error");

                tbLoginUsername.Text = "";
                tbLoginPassword.Text = "";

                conn.Close();
            }

        }

        private int getUserID()
        {
            //creates the sql connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherIOdb"].ConnectionString);

            //opens the connection
            conn.Open();

            //query to store user id of user
            string q_UserID = "select user_id from userinfo where username = @username and password = @password";

            //command to execute the query
            SqlCommand cmd = new SqlCommand(q_UserID, conn);

            //adds values to the scalar variables
            cmd.Parameters.AddWithValue("@username", tbLoginUsername.Text);
            cmd.Parameters.AddWithValue("@password", tbLoginPassword.Text);

            //stores the user id when query is executed
            var userID = cmd.ExecuteScalar();

            //closes the connection
            conn.Close();

            //returns the user id
            return Convert.ToInt32(userID);

        }

        private void btnLoginBack_Click(object sender, EventArgs e)
        {
            //sets size of form

            this.Size = new Size(530, 314);

            //hides and shows relevant panels
            panelLoginPage.Show();
            panelLP1.Show();

            panelUserLogin.Hide();
            panelUL1.Hide();
            panelReg.Hide();
            panelR1.Hide();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            //closes application 
            Application.Exit();
        }
    }
}

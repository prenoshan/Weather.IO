namespace WeatherApp
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panelLP1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.panelLoginPage = new System.Windows.Forms.Panel();
            this.panelReg = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRegisterUser = new System.Windows.Forms.Button();
            this.tbAdminCodeRegister = new System.Windows.Forms.TextBox();
            this.tbPasswordRegister = new System.Windows.Forms.TextBox();
            this.tbUsernameRegister = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelR1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelUserLogin = new System.Windows.Forms.Panel();
            this.btnLoginBack = new System.Windows.Forms.Button();
            this.btnLoginUser = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLoginPassword = new System.Windows.Forms.TextBox();
            this.tbLoginUsername = new System.Windows.Forms.TextBox();
            this.panelUL1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelLP1.SuspendLayout();
            this.panelLoginPage.SuspendLayout();
            this.panelReg.SuspendLayout();
            this.panelR1.SuspendLayout();
            this.panelUserLogin.SuspendLayout();
            this.panelUL1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLP1
            // 
            this.panelLP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLP1.Controls.Add(this.label2);
            this.panelLP1.Controls.Add(this.label1);
            this.panelLP1.Location = new System.Drawing.Point(3, 3);
            this.panelLP1.Name = "panelLP1";
            this.panelLP1.Size = new System.Drawing.Size(486, 119);
            this.panelLP1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(72, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "New users please register";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(116, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please login below";
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.PowderBlue;
            this.btnLogin.Location = new System.Drawing.Point(49, 157);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(138, 55);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.Khaki;
            this.btnRegister.Location = new System.Drawing.Point(293, 157);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(138, 55);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // panelLoginPage
            // 
            this.panelLoginPage.Controls.Add(this.panelLP1);
            this.panelLoginPage.Controls.Add(this.btnRegister);
            this.panelLoginPage.Controls.Add(this.btnLogin);
            this.panelLoginPage.Location = new System.Drawing.Point(12, 12);
            this.panelLoginPage.Name = "panelLoginPage";
            this.panelLoginPage.Size = new System.Drawing.Size(539, 343);
            this.panelLoginPage.TabIndex = 3;
            // 
            // panelReg
            // 
            this.panelReg.Controls.Add(this.btnBack);
            this.panelReg.Controls.Add(this.btnRegisterUser);
            this.panelReg.Controls.Add(this.tbAdminCodeRegister);
            this.panelReg.Controls.Add(this.tbPasswordRegister);
            this.panelReg.Controls.Add(this.tbUsernameRegister);
            this.panelReg.Controls.Add(this.label5);
            this.panelReg.Controls.Add(this.label4);
            this.panelReg.Controls.Add(this.label3);
            this.panelReg.Controls.Add(this.panelR1);
            this.panelReg.Location = new System.Drawing.Point(12, 12);
            this.panelReg.Name = "panelReg";
            this.panelReg.Size = new System.Drawing.Size(687, 457);
            this.panelReg.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.LightGreen;
            this.btnBack.Location = new System.Drawing.Point(171, 352);
            this.btnBack.Name = "btnBack";
            this.btnBack.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBack.Size = new System.Drawing.Size(138, 55);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Go back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterUser.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.btnRegisterUser.Location = new System.Drawing.Point(373, 352);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRegisterUser.Size = new System.Drawing.Size(138, 55);
            this.btnRegisterUser.TabIndex = 9;
            this.btnRegisterUser.Text = "Register";
            this.btnRegisterUser.UseVisualStyleBackColor = true;
            this.btnRegisterUser.Click += new System.EventHandler(this.btnRegisterUser_Click);
            // 
            // tbAdminCodeRegister
            // 
            this.tbAdminCodeRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAdminCodeRegister.Location = new System.Drawing.Point(329, 272);
            this.tbAdminCodeRegister.Name = "tbAdminCodeRegister";
            this.tbAdminCodeRegister.Size = new System.Drawing.Size(182, 22);
            this.tbAdminCodeRegister.TabIndex = 6;
            this.tbAdminCodeRegister.UseSystemPasswordChar = true;
            // 
            // tbPasswordRegister
            // 
            this.tbPasswordRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPasswordRegister.Location = new System.Drawing.Point(329, 221);
            this.tbPasswordRegister.Name = "tbPasswordRegister";
            this.tbPasswordRegister.Size = new System.Drawing.Size(182, 22);
            this.tbPasswordRegister.TabIndex = 5;
            this.tbPasswordRegister.UseSystemPasswordChar = true;
            // 
            // tbUsernameRegister
            // 
            this.tbUsernameRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsernameRegister.Location = new System.Drawing.Point(329, 174);
            this.tbUsernameRegister.Name = "tbUsernameRegister";
            this.tbUsernameRegister.Size = new System.Drawing.Size(182, 22);
            this.tbUsernameRegister.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.AliceBlue;
            this.label5.Location = new System.Drawing.Point(167, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Admin Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.AliceBlue;
            this.label4.Location = new System.Drawing.Point(167, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.AliceBlue;
            this.label3.Location = new System.Drawing.Point(167, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Username*";
            // 
            // panelR1
            // 
            this.panelR1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelR1.Controls.Add(this.label9);
            this.panelR1.Controls.Add(this.label8);
            this.panelR1.Controls.Add(this.label7);
            this.panelR1.Location = new System.Drawing.Point(6, 3);
            this.panelR1.Name = "panelR1";
            this.panelR1.Size = new System.Drawing.Size(678, 119);
            this.panelR1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.AliceBlue;
            this.label8.Location = new System.Drawing.Point(71, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(541, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "Admins please fill out the username, password and admin code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.AliceBlue;
            this.label7.Location = new System.Drawing.Point(103, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(482, 31);
            this.label7.TabIndex = 0;
            this.label7.Text = "Please fill out the following fields below";
            // 
            // panelUserLogin
            // 
            this.panelUserLogin.Controls.Add(this.btnLoginBack);
            this.panelUserLogin.Controls.Add(this.btnLoginUser);
            this.panelUserLogin.Controls.Add(this.label10);
            this.panelUserLogin.Controls.Add(this.label6);
            this.panelUserLogin.Controls.Add(this.tbLoginPassword);
            this.panelUserLogin.Controls.Add(this.tbLoginUsername);
            this.panelUserLogin.Controls.Add(this.panelUL1);
            this.panelUserLogin.Location = new System.Drawing.Point(12, 12);
            this.panelUserLogin.Name = "panelUserLogin";
            this.panelUserLogin.Size = new System.Drawing.Size(533, 384);
            this.panelUserLogin.TabIndex = 11;
            // 
            // btnLoginBack
            // 
            this.btnLoginBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginBack.ForeColor = System.Drawing.Color.LightGreen;
            this.btnLoginBack.Location = new System.Drawing.Point(87, 283);
            this.btnLoginBack.Name = "btnLoginBack";
            this.btnLoginBack.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLoginBack.Size = new System.Drawing.Size(138, 55);
            this.btnLoginBack.TabIndex = 11;
            this.btnLoginBack.Text = "Go back";
            this.btnLoginBack.UseVisualStyleBackColor = true;
            this.btnLoginBack.Click += new System.EventHandler(this.btnLoginBack_Click);
            // 
            // btnLoginUser
            // 
            this.btnLoginUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginUser.ForeColor = System.Drawing.Color.PowderBlue;
            this.btnLoginUser.Location = new System.Drawing.Point(271, 283);
            this.btnLoginUser.Name = "btnLoginUser";
            this.btnLoginUser.Size = new System.Drawing.Size(138, 55);
            this.btnLoginUser.TabIndex = 5;
            this.btnLoginUser.Text = "Login";
            this.btnLoginUser.UseVisualStyleBackColor = true;
            this.btnLoginUser.Click += new System.EventHandler(this.btnLoginUser_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.AliceBlue;
            this.label10.Location = new System.Drawing.Point(91, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 24);
            this.label10.TabIndex = 4;
            this.label10.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.AliceBlue;
            this.label6.Location = new System.Drawing.Point(91, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "Username";
            // 
            // tbLoginPassword
            // 
            this.tbLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLoginPassword.Location = new System.Drawing.Point(224, 221);
            this.tbLoginPassword.Name = "tbLoginPassword";
            this.tbLoginPassword.Size = new System.Drawing.Size(180, 22);
            this.tbLoginPassword.TabIndex = 2;
            this.tbLoginPassword.UseSystemPasswordChar = true;
            // 
            // tbLoginUsername
            // 
            this.tbLoginUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLoginUsername.Location = new System.Drawing.Point(224, 160);
            this.tbLoginUsername.Name = "tbLoginUsername";
            this.tbLoginUsername.Size = new System.Drawing.Size(180, 22);
            this.tbLoginUsername.TabIndex = 1;
            // 
            // panelUL1
            // 
            this.panelUL1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelUL1.Controls.Add(this.label12);
            this.panelUL1.Controls.Add(this.label11);
            this.panelUL1.Location = new System.Drawing.Point(8, 6);
            this.panelUL1.Name = "panelUL1";
            this.panelUL1.Size = new System.Drawing.Size(503, 106);
            this.panelUL1.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.AliceBlue;
            this.label12.Location = new System.Drawing.Point(208, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 31);
            this.label12.TabIndex = 1;
            this.label12.Text = "to login";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.AliceBlue;
            this.label11.Location = new System.Drawing.Point(79, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(367, 31);
            this.label11.TabIndex = 0;
            this.label11.Text = "Please fill in the details below";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.AliceBlue;
            this.label9.Location = new System.Drawing.Point(115, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(435, 24);
            this.label9.TabIndex = 2;
            this.label9.Text = "General Users fill out username and password only\r\n";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(714, 484);
            this.Controls.Add(this.panelReg);
            this.Controls.Add(this.panelUserLogin);
            this.Controls.Add(this.panelLoginPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.panelLP1.ResumeLayout(false);
            this.panelLP1.PerformLayout();
            this.panelLoginPage.ResumeLayout(false);
            this.panelReg.ResumeLayout(false);
            this.panelReg.PerformLayout();
            this.panelR1.ResumeLayout(false);
            this.panelR1.PerformLayout();
            this.panelUserLogin.ResumeLayout(false);
            this.panelUserLogin.PerformLayout();
            this.panelUL1.ResumeLayout(false);
            this.panelUL1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLP1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel panelLoginPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelReg;
        private System.Windows.Forms.Button btnRegisterUser;
        private System.Windows.Forms.TextBox tbAdminCodeRegister;
        private System.Windows.Forms.TextBox tbPasswordRegister;
        private System.Windows.Forms.TextBox tbUsernameRegister;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelR1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelUserLogin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLoginPassword;
        private System.Windows.Forms.TextBox tbLoginUsername;
        private System.Windows.Forms.Panel panelUL1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnLoginUser;
        private System.Windows.Forms.Button btnLoginBack;
        private System.Windows.Forms.Label label9;
    }
}
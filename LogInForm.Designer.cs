namespace ClinicInfoSys.Forms
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.usernamelabel = new System.Windows.Forms.Label();
            this.passwordlabel = new System.Windows.Forms.Label();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.systemName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jenloginpicture = new System.Windows.Forms.PictureBox();
            this.ForgotPassLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.jenloginpicture)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(516, 139);
            this.comboBoxRole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(276, 24);
            this.comboBoxRole.TabIndex = 2;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(516, 198);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(276, 22);
            this.textBoxUsername.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(516, 255);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(276, 22);
            this.textBoxPassword.TabIndex = 4;
            // 
            // usernamelabel
            // 
            this.usernamelabel.AutoSize = true;
            this.usernamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernamelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.usernamelabel.Location = new System.Drawing.Point(512, 178);
            this.usernamelabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernamelabel.Name = "usernamelabel";
            this.usernamelabel.Size = new System.Drawing.Size(81, 17);
            this.usernamelabel.TabIndex = 5;
            this.usernamelabel.Text = "Username";
            // 
            // passwordlabel
            // 
            this.passwordlabel.AutoSize = true;
            this.passwordlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passwordlabel.Location = new System.Drawing.Point(512, 235);
            this.passwordlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordlabel.Name = "passwordlabel";
            this.passwordlabel.Size = new System.Drawing.Size(77, 17);
            this.passwordlabel.TabIndex = 6;
            this.passwordlabel.Text = "Password";
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.BackColor = System.Drawing.Color.Navy;
            this.buttonLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogIn.ForeColor = System.Drawing.SystemColors.Menu;
            this.buttonLogIn.Location = new System.Drawing.Point(571, 330);
            this.buttonLogIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(177, 28);
            this.buttonLogIn.TabIndex = 7;
            this.buttonLogIn.Text = "Log In";
            this.buttonLogIn.UseVisualStyleBackColor = false;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click_1);
            // 
            // systemName
            // 
            this.systemName.AutoSize = true;
            this.systemName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemName.ForeColor = System.Drawing.Color.Navy;
            this.systemName.Location = new System.Drawing.Point(485, 36);
            this.systemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.systemName.Name = "systemName";
            this.systemName.Size = new System.Drawing.Size(316, 23);
            this.systemName.TabIndex = 8;
            this.systemName.Text = "JenCare Clinic Management System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(512, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Log In As";
            // 
            // jenloginpicture
            // 
            this.jenloginpicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.jenloginpicture.Image = ((System.Drawing.Image)(resources.GetObject("jenloginpicture.Image")));
            this.jenloginpicture.Location = new System.Drawing.Point(1, 0);
            this.jenloginpicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.jenloginpicture.Name = "jenloginpicture";
            this.jenloginpicture.Size = new System.Drawing.Size(473, 421);
            this.jenloginpicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jenloginpicture.TabIndex = 0;
            this.jenloginpicture.TabStop = false;
            // 
            // ForgotPassLabel
            // 
            this.ForgotPassLabel.AutoSize = true;
            this.ForgotPassLabel.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.ForgotPassLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ForgotPassLabel.Location = new System.Drawing.Point(567, 283);
            this.ForgotPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ForgotPassLabel.Name = "ForgotPassLabel";
            this.ForgotPassLabel.Size = new System.Drawing.Size(147, 16);
            this.ForgotPassLabel.TabIndex = 10;
            this.ForgotPassLabel.TabStop = true;
            this.ForgotPassLabel.Text = "Forgot Your Password?";
            this.ForgotPassLabel.VisitedLinkColor = System.Drawing.Color.Silver;
            this.ForgotPassLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForgotPassLabel_LinkClicked);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(840, 423);
            this.Controls.Add(this.ForgotPassLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.systemName);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.passwordlabel);
            this.Controls.Add(this.usernamelabel);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.jenloginpicture);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LogInForm";
            this.Text = "LogInForm";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jenloginpicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox jenloginpicture;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label usernamelabel;
        private System.Windows.Forms.Label passwordlabel;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.Label systemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel ForgotPassLabel;
    }
}
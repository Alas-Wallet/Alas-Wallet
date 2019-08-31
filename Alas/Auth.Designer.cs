namespace Alas
{
    partial class Auth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
            this.singin = new System.Windows.Forms.Button();
            this.reset_password = new System.Windows.Forms.Button();
            this.reg = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // singin
            // 
            this.singin.BackColor = System.Drawing.Color.Transparent;
            this.singin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.singin.FlatAppearance.BorderSize = 0;
            this.singin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.singin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.singin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.singin.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.singin.ForeColor = System.Drawing.Color.Transparent;
            this.singin.Location = new System.Drawing.Point(29, 299);
            this.singin.Name = "singin";
            this.singin.Size = new System.Drawing.Size(240, 56);
            this.singin.TabIndex = 57;
            this.singin.UseVisualStyleBackColor = false;
            this.singin.Click += new System.EventHandler(this.Singin_Click);
            // 
            // reset_password
            // 
            this.reset_password.BackColor = System.Drawing.Color.Transparent;
            this.reset_password.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reset_password.FlatAppearance.BorderSize = 0;
            this.reset_password.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.reset_password.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.reset_password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset_password.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reset_password.ForeColor = System.Drawing.Color.Transparent;
            this.reset_password.Location = new System.Drawing.Point(39, 243);
            this.reset_password.Name = "reset_password";
            this.reset_password.Size = new System.Drawing.Size(122, 16);
            this.reset_password.TabIndex = 58;
            this.reset_password.UseVisualStyleBackColor = false;
            // 
            // reg
            // 
            this.reg.BackColor = System.Drawing.Color.Transparent;
            this.reg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reg.FlatAppearance.BorderSize = 0;
            this.reg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.reg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.reg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reg.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reg.ForeColor = System.Drawing.Color.Transparent;
            this.reg.Location = new System.Drawing.Point(66, 428);
            this.reg.Name = "reg";
            this.reg.Size = new System.Drawing.Size(161, 48);
            this.reg.TabIndex = 59;
            this.reg.UseVisualStyleBackColor = false;
            this.reg.Click += new System.EventHandler(this.Reg_Click);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
            this.login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(177)))), ((int)(((byte)(180)))));
            this.login.Location = new System.Drawing.Point(44, 129);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(210, 19);
            this.login.TabIndex = 60;
            this.login.Text = "Логин";
            this.login.Click += new System.EventHandler(this.Login_Click);
            this.login.Leave += new System.EventHandler(this.Login_Leave);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(177)))), ((int)(((byte)(180)))));
            this.password.Location = new System.Drawing.Point(44, 199);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(210, 19);
            this.password.TabIndex = 61;
            this.password.Text = "Пароль";
            this.password.Click += new System.EventHandler(this.Password_Click);
            this.password.Leave += new System.EventHandler(this.Password_Leave);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close.ForeColor = System.Drawing.Color.Transparent;
            this.close.Location = new System.Drawing.Point(260, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(34, 35);
            this.close.TabIndex = 62;
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
            this.BackgroundImage = global::Alas.Properties.Resources.auth1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(297, 488);
            this.Controls.Add(this.close);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.reg);
            this.Controls.Add(this.reset_password);
            this.Controls.Add(this.singin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alas-Авторизация";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button singin;
        public System.Windows.Forms.Button reset_password;
        public System.Windows.Forms.Button reg;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;
        public System.Windows.Forms.Button close;
    }
}
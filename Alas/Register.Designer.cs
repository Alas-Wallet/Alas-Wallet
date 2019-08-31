namespace Alas
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.close = new System.Windows.Forms.Button();
            this.singin = new System.Windows.Forms.Button();
            this.back_login = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.password2 = new System.Windows.Forms.TextBox();
            this.secretword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            this.close.TabIndex = 63;
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.Close_Click);
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
            this.singin.Location = new System.Drawing.Point(29, 341);
            this.singin.Name = "singin";
            this.singin.Size = new System.Drawing.Size(240, 56);
            this.singin.TabIndex = 64;
            this.singin.UseVisualStyleBackColor = false;
            this.singin.Click += new System.EventHandler(this.Singin_Click);
            // 
            // back_login
            // 
            this.back_login.BackColor = System.Drawing.Color.Transparent;
            this.back_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back_login.FlatAppearance.BorderSize = 0;
            this.back_login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.back_login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.back_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_login.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_login.ForeColor = System.Drawing.Color.Transparent;
            this.back_login.Location = new System.Drawing.Point(81, 439);
            this.back_login.Name = "back_login";
            this.back_login.Size = new System.Drawing.Size(138, 36);
            this.back_login.TabIndex = 65;
            this.back_login.UseVisualStyleBackColor = false;
            this.back_login.Click += new System.EventHandler(this.Back_login_Click);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
            this.login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(177)))), ((int)(((byte)(180)))));
            this.login.Location = new System.Drawing.Point(41, 130);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(210, 19);
            this.login.TabIndex = 66;
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
            this.password.Location = new System.Drawing.Point(41, 184);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(210, 19);
            this.password.TabIndex = 67;
            this.password.Text = "Пароль";
            this.password.Click += new System.EventHandler(this.Password_Click);
            this.password.Leave += new System.EventHandler(this.Password_Leave);
            // 
            // password2
            // 
            this.password2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
            this.password2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password2.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(177)))), ((int)(((byte)(180)))));
            this.password2.Location = new System.Drawing.Point(41, 235);
            this.password2.Name = "password2";
            this.password2.Size = new System.Drawing.Size(210, 19);
            this.password2.TabIndex = 68;
            this.password2.Text = "Пароль ещё раз";
            this.password2.Click += new System.EventHandler(this.Password2_Click);
            this.password2.Leave += new System.EventHandler(this.Password2_Leave);
            // 
            // secretword
            // 
            this.secretword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
            this.secretword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secretword.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secretword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(177)))), ((int)(((byte)(180)))));
            this.secretword.Location = new System.Drawing.Point(41, 285);
            this.secretword.Name = "secretword";
            this.secretword.Size = new System.Drawing.Size(210, 19);
            this.secretword.TabIndex = 69;
            this.secretword.Text = "Секретное слово";
            this.secretword.Click += new System.EventHandler(this.Secretword_Click);
            this.secretword.Leave += new System.EventHandler(this.Secretword_Leave);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Alas.Properties.Resources.register1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(300, 483);
            this.Controls.Add(this.secretword);
            this.Controls.Add(this.password2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.back_login);
            this.Controls.Add(this.singin);
            this.Controls.Add(this.close);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alas-Регистрация";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button close;
        public System.Windows.Forms.Button singin;
        public System.Windows.Forms.Button back_login;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox password2;
        private System.Windows.Forms.TextBox secretword;
    }
}
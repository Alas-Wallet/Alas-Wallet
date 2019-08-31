using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alas
{
    public partial class Auth : Form
    {
        Register register;
        public Auth()
        {
            InitializeComponent();
            register = new Register(this);
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
        }
        public void pasteLoginandPassword(string Loggin, string Passwordd)
        {
            login.Text = Loggin;
            password.Text = Passwordd;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private Point MouseHook;
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }
        private void Singin_Click(object sender, EventArgs e)
        {
            AutoUpdater.Mandatory = true;
            AutoUpdater.RunUpdateAsAdmin = false;
            AutoUpdater.UpdateMode = Mode.ForcedDownload;
            AutoUpdater.Start("http://alas-wallet.xyz/Alas/update.xml");
        }
        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.IsUpdateAvailable == true)
            {
                //Обновляем
                if (AutoUpdater.DownloadUpdate())
                {
                    Application.Exit();
                }
            }
            else
            {
                string request = ApiRequest.Login(login.Text, password.Text);
                if (request.Contains("Login error"))
                {
                    login.ForeColor = System.Drawing.Color.Red;
                    password.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    ApiRequest.GetAllAddres();
                    ApiRequest.GetAllBalance();
                    ApiRequest.GetAllCursAndFee();
                    this.Hide();
                    new Main().Show();
                }
            }
        }

        private void Reg_Click(object sender, EventArgs e)
        {
            this.Hide();
            register.Show();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (login.Text.Equals("Логин"))
            {
                login.Text = "";
            }
        }

        private void Login_Leave(object sender, EventArgs e)
        {
            if (login.Text.Equals(""))
            {
                login.Text = "Логин";
            }
        }

        private void Password_Click(object sender, EventArgs e)
        {
            if (password.Text.Equals("Пароль"))
            {
                password.UseSystemPasswordChar = true;
                password.Text = "";
            }
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (password.Text.Equals(""))
            {
                password.UseSystemPasswordChar = false;
                password.Text = "Пароль";
            }
        }
    }
}

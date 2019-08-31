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
    public partial class Register : Form
    {
        Auth auth;
        public Register(Auth auth_)
        {
            InitializeComponent();
            auth = auth_;
        }
        private Point MouseHook;
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }
        private void Singin_Click(object sender, EventArgs e)
        {
            if (password.Text.Equals(password2.Text))
            {
                if (!string.IsNullOrEmpty(login.Text) && !login.Text.Equals("Логин"))
                {
                    if (!string.IsNullOrEmpty(password.Text) && !password.Text.Equals("Пароль"))
                    {
                        if (!string.IsNullOrEmpty(secretword.Text) && !secretword.Text.Equals("Секретное слово"))
                        {
                            string response = ApiRequest.Register(login.Text, password.Text, secretword.Text);
                            MessageBox.Show(response);
                            if(response.Equals("Регистрация прошла успешно"))
                            {
                                auth.pasteLoginandPassword(login.Text, password.Text);
                                auth.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите секретное слово!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите пароль!");
                    }
                }
                else
                {
                    MessageBox.Show("Введите логин!");
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
            }
        }

        private void Back_login_Click(object sender, EventArgs e)
        {
            auth.Show();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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
                password.Text = "";
            }
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (password.Text.Equals(""))
            {
                password.Text = "Пароль";
            }
        }

        private void Password2_Click(object sender, EventArgs e)
        {
            if (password2.Text.Equals("Пароль ещё раз"))
            {
                password2.Text = "";
            }
        }

        private void Password2_Leave(object sender, EventArgs e)
        {
            if (password2.Text.Equals(""))
            {
                password2.Text = "Пароль ещё раз";
            }
        }

        private void Secretword_Click(object sender, EventArgs e)
        {
            if (secretword.Text.Equals("Секретное слово"))
            {
                secretword.Text = "";
            }
        }

        private void Secretword_Leave(object sender, EventArgs e)
        {
            if (secretword.Text.Equals(""))
            {
                secretword.Text = "Секретное слово";
            }
        }
    }
}

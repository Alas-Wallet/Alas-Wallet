using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alas
{
    public partial class Main : Form
    {
        public static Dictionary<string, double> AllBalance { get; private set; }
        public static Dictionary<string, string> AllAddres { get; private set; }
        public static Dictionary<string, string> AllCursAndFee { get; private set; }
        Calculate calculate = new Calculate();
        decimal All_I;
        bool left, change_index;
        Connects connects = new Connects();
        public Main()
        {
            InitializeComponent();
            change_index = false;
        }

        private void Support_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            TextChangedCurrency();
        }

        private void Exchange_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void Wallet_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }
        private Point MouseHook;
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            Thread balance_updater = new Thread(Balance_Updater);
            balance_updater.Start();
            Thread curs_update = new Thread(Curs_Update);
            curs_update.Start();
            Thread balance_update = new Thread(Balance_Update);
            balance_update.Start();
            exchange_coin.Text = "AUSD";
            exchange_coin_to.Text = "ARUB";
            exchange_in_pic.Image = Properties.Resources.usd as Bitmap;
            exchange_to_pic.Image = Properties.Resources.rub as Bitmap;
            var style = NumberStyles.AllowDecimalPoint;
            CultureInfo provider = CultureInfo.InvariantCulture;
            decimal fee1 = Decimal.Parse(AllCursAndFee["Exchange"], style, provider) * 100;
            decimal fees = Decimal.Parse(AllCursAndFee["Send"], style, provider) * 100;
            fee.Text = "Комиссия " + decimal.Round(fee1,1).ToString() + "%";
            Fee_Send.Text = "Комиссия " + decimal.Round(fees, 1).ToString() + "%";
            ruborusd.Text = "Rub";
            currency.Text = "ARUB";
        }
        public void Balance_Updater()
        {
            AllAddres = ApiRequest.AllAddres;
            AllBalance = ApiRequest.AllBalance;
            AllCursAndFee = ApiRequest.AllCursAndFee;
            while (true)
            {
                Thread.Sleep(300000);
                AllAddres = ApiRequest.AllAddres;
                AllBalance = ApiRequest.AllBalance;
                AllCursAndFee = ApiRequest.AllCursAndFee;
            }

        }
        private void Curs_Update()
        {
            AllCursAndFee = ApiRequest.GetAllCursAndFee();
            // EUR UAH
            BeginInvoke(new MethodInvoker(delegate
            {
                course_usd.Text = "₽" + AllCursAndFee["AUSD"];
                course_uah.Text = "₽" + AllCursAndFee["AUAH"];
            }));
            Thread balance_all = new Thread(Balance_All);
            balance_all.Start();
            while (true)
            {
                Thread.Sleep(TimeSpan.FromMinutes(60));
                AllCursAndFee = ApiRequest.GetAllCursAndFee();
                // EUR UAH
                BeginInvoke(new MethodInvoker(delegate
                {
                    course_usd.Text = "₽" + AllCursAndFee["AUSD"];
                    course_uah.Text = "₽" + AllCursAndFee["AUAH"];
                }));
            }
        }
        private void Balance_All()
        {
            All_I = (decimal)AllBalance["ARUB"] + Decimal.Multiply((decimal)AllBalance["AUSD"], Convert.ToDecimal(AllCursAndFee["AUSD"].Replace('.', ',')))+ Decimal.Multiply((decimal)AllBalance["AUAH"], Convert.ToDecimal(AllCursAndFee["AUAH"].Replace('.', ',')));
            BeginInvoke(new MethodInvoker(delegate
            {
                Balance.Text = decimal.Round(All_I, 2).ToString() + " ₽";
            }));
            while (true)
            {
                Thread.Sleep(320000);
                All_I = (decimal)AllBalance["ARUB"] + Decimal.Multiply((decimal)AllBalance["AUSD"], Convert.ToDecimal(AllCursAndFee["AUSD"].Replace('.', ',')))+ Decimal.Multiply((decimal)AllBalance["AUAH"], Convert.ToDecimal(AllCursAndFee["AUAH"].Replace('.', ',')));
                BeginInvoke(new MethodInvoker(delegate
                {
                    Balance.Text = decimal.Round(All_I, 2).ToString() + " ₽";
                }));
            }
        }
        private void Balance_Update()
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                rub.Text = "₽"+ decimal.Round((decimal)AllBalance["ARUB"], 2).ToString();
                usd.Text = "$" + decimal.Round((decimal)AllBalance["AUSD"], 2).ToString(); 
                uah.Text = "₴" + decimal.Round((decimal)AllBalance["AUAH"], 2).ToString();
                UpdateToRub();
            }));
            while (true)
            {
                //decimal.Round((decimal)AllBalance["ARUB"], 2)
                Thread.Sleep(AppSettings.UpdateTime);
                AllBalance = ApiRequest.GetAllBalance();
                BeginInvoke(new MethodInvoker(delegate
                {
                    rub.Text = "₽" + decimal.Round((decimal)AllBalance["ARUB"], 2).ToString();
                    usd.Text = "$" + decimal.Round((decimal)AllBalance["AUSD"], 2).ToString();
                    uah.Text = "₴" + decimal.Round((decimal)AllBalance["AUAH"], 2).ToString();
                    UpdateToRub();
                }));
            }
        }

        private void Exchange_coin_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_index = true;
            Exchange_Coin_Select(0);
            exchange1(true);
            change_index = false;
        }

        private void Exchange_coin_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_index = true;
            Exchange_Coin_Select(1);
            exchange1(true);
            change_index = false;
        }

        private void Exchanching_Click(object sender, EventArgs e)
        {
            decimal.TryParse(exchange_amount.Text, out decimal IN_amount);
            decimal.TryParse(recive_amount.Text, out decimal OUT_amount);
            Console.WriteLine("IN_amount = " + IN_amount);
            Console.WriteLine("OUT_amount = " + OUT_amount);
            if (IN_amount > 0 && OUT_amount > 0)
            {
                if (connects.Exchange(exchange_coin.Text, exchange_coin_to.Text, IN_amount, OUT_amount) == true && !exchange_coin.Text.Equals(exchange_coin_to.Text))
                {
                    MessageBox.Show("Обмен совершён!");
                    Balance_UpdateOne();
                    Exchange_Coin_Select(0);
                    Exchange_Coin_Select(1);
                }
                else
                {
                    MessageBox.Show("Не хватает баланса!");
                }
            }
        }

        private void exchange1(bool INtoOUT)
        {
            Console.WriteLine("exchange_amount.Text = " + exchange_amount.Text);
            decimal curs_in = 0;
            decimal curs_out = 0;
            int nuuls = 0;//сколько знаков после запятой
            string IN = exchange_coin.Text;
            string OUT = exchange_coin_to.Text;
            switch (OUT)
            {
                case "AUSD":
                    curs_out = Convert.ToDecimal(AllCursAndFee["AUSD"].Replace('.', ','));
                    nuuls = 2;
                    break;
                case "ARUB":
                    curs_out = 1;
                    nuuls = 2;
                    break;
                case "AUAH":
                    curs_out = Convert.ToDecimal(AllCursAndFee["AUAH"].Replace('.', ','));
                    nuuls = 2;
                    break;
                default:
                    break;
            }
            switch (IN)
            {
                case "AUSD":
                    curs_in = Convert.ToDecimal(AllCursAndFee["AUSD"].Replace('.', ','));
                    break;
                case "ARUB":
                    curs_in = 1;
                    break;
                case "AUAH":
                    curs_in = Convert.ToDecimal(AllCursAndFee["AUAH"].Replace('.', ','));
                    break;
                default:
                    break;
            }
            if (INtoOUT == true)
            {
                var style = NumberStyles.AllowDecimalPoint;
                decimal.TryParse(exchange_amount.Text, out decimal IN_amount);
                decimal result = calculate.Converter(IN_amount, curs_in, curs_out);
                result = result - Decimal.Multiply(result, Decimal.Parse(AllCursAndFee["Exchange"].Replace(".", ","), style));
                if (result <= 0) { exchanching.Enabled = false; } else { exchanching.Enabled = true; }
                recive_amount.Text = decimal.Round(result, nuuls).ToString();
            }
            else
            {
                var style = NumberStyles.AllowDecimalPoint;
                decimal.TryParse(recive_amount.Text, out decimal IN_amount);
                decimal result = calculate.Converter(IN_amount, curs_out, curs_in);
                result = result - Decimal.Multiply(result, Decimal.Parse(AllCursAndFee["Exchange"].Replace(".", ","), style));
                exchange_amount.Text = decimal.Round(result, nuuls).ToString();
            }
        }
        public static decimal GetAmount(decimal amount, string type)
        {
            var style = NumberStyles.AllowDecimalPoint;
            CultureInfo provider = CultureInfo.InvariantCulture;
            decimal comissions = Decimal.Parse(AllCursAndFee[type], style, provider);
            decimal newAmount = amount - Decimal.Multiply(amount, comissions);
            return newAmount;
        }
        private void Exchange_amount_TextChanged(object sender, EventArgs e)
        {
            if (left == true && change_index == false)
            {
                exchange1(true);
            }
        }

        private void Exchange_amount_Enter(object sender, EventArgs e)
        {
            left = true;
        }

        private void Exchange_amount_Leave(object sender, EventArgs e)
        {
            left = false;
        }

        private void Recive_amount_TextChanged(object sender, EventArgs e)
        {
            if (left == false && change_index == false)
            {
                //exchange1(false);
            }
        }

        private void Recive_amount_Enter(object sender, EventArgs e)
        {
            left = false;
        }

        private void Bu_payyer_Click(object sender, EventArgs e)
        {
            u_payyer.Checked = true;
        }

        private void Bu_qiwi_Click(object sender, EventArgs e)
        {
            u_qiwi.Checked = true;
        }

        private void Bu_yandexmoney_Click(object sender, EventArgs e)
        {
            u_yandexmoney.Checked = true;
        }

        private void Bu_btc_Click(object sender, EventArgs e)
        {
            u_btc.Checked = true;
        }

        private void U_payyer_CheckedChanged(object sender, EventArgs e)
        {
            ruborusd.Visible = true;
            GetMin(GetTypee());
            Fee_Send_Update();
        }

        private void U_btc_CheckedChanged(object sender, EventArgs e)
        {
            ruborusd.Visible = false;
            Min_With.Text = "Минимум: " + GetMin(GetTypee()) + "₽";
            Fee_Send_Update();
        }
        private string GetTypee()
        {
            string type = "";
            if (u_payyer.Checked == true) type = "Payeer";
            else if (u_qiwi.Checked == true) type = "Qiwi";
            else if (u_yandexmoney.Checked == true) type = "YandexMoney";
            else if (u_btc.Checked == true) type = "BTC";
            else if (u_alas.Checked == true) type = "Send";
            return type;
        }
        private decimal GetMin(string type)
        {
            decimal min = 0;
            switch (type)
            {
                case "Payeer":
                    min = 2000;
                    break;
                case "Qiwi":
                    min = 2000;
                    break;
                case "YandexMoney":
                    min = 2000;
                    break;
                case "BTC":
                    min = 2000;
                    break;
                case "Send":
                    min = 1;
                    break;
            }
            return min;
        }
        private void Fee_Send_Update()
        {
            var style = NumberStyles.AllowDecimalPoint;
            CultureInfo provider = CultureInfo.InvariantCulture;
            string type = GetTypee();
            Console.WriteLine("type = " + type);
            decimal fee1 = Decimal.Parse(AllCursAndFee[type], style, provider) * 100;

            Fee_Send.Text = "Комиссия " + decimal.Round(fee1, 1).ToString() + "%";
            UpdateAmountFee(type);
        }
        private void UpdateAmountFee(string type)
        {
            if (string.IsNullOrEmpty(balance_transfer.Text))
            {
                FinishedAmount.Text = "Итого: 0,00";
                bu_send.Enabled = false;
            }
            else
            {
                string b = balance_transfer.Text.Replace(",", ".");
                decimal res;
                decimal.TryParse(b, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out res);
                res = decimal.Round(GetAmount(res, type), 2);
                if (res <= 0) { bu_send.Enabled = false; } else { bu_send.Enabled = true; }
                FinishedAmount.Text = "Итого: " + res.ToString();
            }
        }
        private void Bu_send_Click(object sender, EventArgs e)
        {
            string type = GetTypee();
            string your_addres = "";
            decimal amount = 0;
            decimal min = GetMin(type);
            switch (currency.Text)
            {
                case "ARUB":
                    your_addres = AllAddres["ARUB"];
                    break;
                case "AUSD":
                    your_addres = AllAddres["AUSD"];
                    break;
                case "AUAH":
                    your_addres = AllAddres["AUAH"];
                    break;
            }
            decimal.TryParse(FinishedAmount.Text.Substring(7).Replace(",", "."), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out amount);
            Console.WriteLine("amount = " + amount);
            if (!type.Equals("Send"))
            {
                if(amount >= min && !string.IsNullOrEmpty(data_wallet.Text))
                {
                    string response = ApiRequest.Withdraw(ApiRequest.ApiKey, your_addres, type, Convert.ToDouble(balance_transfer.Text), Convert.ToDouble(balance_transfer_to_rub.Text.Substring(0, balance_transfer_to_rub.Text.Length - 4)), currency.Text, data_wallet.Text);
                    MessageBox.Show(response);
                    Balance_UpdateOne();
                    Exchange_Coin_Select(0);
                    Exchange_Coin_Select(1);
                    TextChangedCurrency();
                }
                else { MessageBox.Show("Недостаточно баланса или не введён адрес"); }
            }
            else
            {
                //Отправка
                if (ApiRequest.CheckAddres(ApiRequest.ApiKey, currency.Text, data_wallet.Text).Equals("There is"))
                {
                    decimal balance_send = Convert.ToDecimal(balance_transfer.Text);
                    var style = NumberStyles.AllowDecimalPoint;
                    balance_send = balance_send + Decimal.Multiply(balance_send, Decimal.Parse(AllCursAndFee["Send"].Replace(".", ","), style));
                    string your = ApiRequest.GetBalance(ApiRequest.ApiKey, currency.Text);
                    string response = ApiRequest.Send(ApiRequest.ApiKey, currency.Text, data_wallet.Text, Convert.ToDouble(balance_send));
                    MessageBox.Show(response);
                    Balance_UpdateOne();
                    Exchange_Coin_Select(0);
                    Exchange_Coin_Select(1);
                    TextChangedCurrency();
                }
                else
                {
                    MessageBox.Show("Адреса не существует");
                }
                //MessageBox.Show("Адреса не существует");
            }
        }
        private void Balance_UpdateOne()
        {
            AllBalance = ApiRequest.GetAllBalance();
            BeginInvoke(new MethodInvoker(delegate
            {
                rub.Text = decimal.Round((decimal)AllBalance["ARUB"], 2).ToString();
                usd.Text = decimal.Round((decimal)AllBalance["AUSD"], 2).ToString();
                uah.Text = decimal.Round((decimal)AllBalance["AUAH"], 2).ToString();

                UpdateToRub();
            }));
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string type = "";
            if (u_payyer.Checked == true) type = "Payeer";
            else if (u_qiwi.Checked == true) type = "Qiwi";
            else if (u_yandexmoney.Checked == true) type = "YandexMoney";
            else if (u_btc.Checked == true) type = "BTC";
            else if (u_alas.Checked == true) type = "Send";
            TextChangedCurrency();
            UpdateAmountFee(type);
        }

        private void TextChangedCurrency()
        {
            decimal curs = 0;
            if (currency.Text.Equals("AUSD"))
            {
                curs = Convert.ToDecimal(AllCursAndFee["AUSD"].Replace('.', ','));
                Balanse_in_send.Text = "Баланс: " + decimal.Round((decimal)AllBalance["AUSD"], 2).ToString();
            }
            else if (currency.Text.Equals("ARUB"))
            {
                curs = 1;
                Balanse_in_send.Text = "Баланс: " + decimal.Round((decimal)AllBalance["ARUB"], 2).ToString();
            }
            else if (currency.Text.Equals("AUAH"))
            {
                curs = Convert.ToDecimal(AllCursAndFee["AUAH"].Replace('.', ','));
                Balanse_in_send.Text = "Баланс: " + decimal.Round((decimal)AllBalance["AUAH"], 2).ToString();
            }
            if (!string.IsNullOrEmpty(balance_transfer.Text))
            {
                decimal.TryParse(balance_transfer.Text, out decimal b12);
                decimal bal = Decimal.Multiply(b12, curs);
                balance_transfer_to_rub.Text = decimal.Round(bal, 2).ToString() + " RUB";
            }
            else
            {
                balance_transfer_to_rub.Text = "0 RUB";
            }
        }
        private void Exchange_Coin_Select(int upORdown)
        {
            decimal curs_in = 0;
            decimal curs_out = 0;
            if (upORdown == 0)
            {
                switch (exchange_coin.Text)
                {
                    case "ARUB":
                        exchange_in_pic.Image = Properties.Resources.rub as Bitmap;
                        u_balance_in.Text = "Баланс: " + decimal.Round((decimal)AllBalance["ARUB"], 2).ToString();
                        curs_in = 1;
                        in_rub.Text = "В рублях: " + decimal.Round(Decimal.Multiply((decimal)AllBalance["ARUB"], curs_in), 2).ToString() + " ARUB";
                        break;
                    case "AUSD":
                        exchange_in_pic.Image = Properties.Resources.usd as Bitmap;
                        u_balance_in.Text = "Баланс: " + decimal.Round((decimal)AllBalance["AUSD"], 2).ToString();
                        curs_in = Convert.ToDecimal(AllCursAndFee["AUSD"].Replace('.', ','));
                        in_rub.Text = "В рублях: " + decimal.Round(Decimal.Multiply((decimal)AllBalance["AUSD"], curs_in), 2).ToString() + " ARUB";
                        break;
                    case "AUAH":
                        exchange_in_pic.Image = Properties.Resources.uah as Bitmap;
                        u_balance_in.Text = "Баланс: " + decimal.Round((decimal)AllBalance["AUAH"], 2).ToString();
                        curs_in = Convert.ToDecimal(AllCursAndFee["AUAH"].Replace('.', ','));
                        in_rub.Text = "В рублях: " + decimal.Round(Decimal.Multiply((decimal)AllBalance["AUAH"], curs_in), 2).ToString() + " ARUB";
                        break;
                    default:
                        exchange_in_pic.Image = Properties.Resources.usd as Bitmap;
                        break;
                }
            }
            else
            {
                switch (exchange_coin_to.Text)
                {
                    case "ARUB":
                        curs_out = 1;
                        exchange_to_pic.Image = Properties.Resources.rub as Bitmap;
                        out_rub.Text = "В рублях: " + decimal.Round(Decimal.Multiply((decimal)AllBalance["ARUB"], curs_out), 2).ToString() + " ARUB";
                        u_balance_to.Text = "Баланс: " + decimal.Round((decimal)AllBalance["ARUB"], 2).ToString();
                        break;
                    case "AUSD":
                        exchange_to_pic.Image = Properties.Resources.usd as Bitmap;
                        curs_out = Convert.ToDecimal(AllCursAndFee["AUSD"].Replace('.', ','));
                        u_balance_to.Text = "Баланс: " + decimal.Round((decimal)AllBalance["AUSD"], 2).ToString();
                        out_rub.Text = "В рублях: " + decimal.Round(Decimal.Multiply((decimal)AllBalance["AUSD"], curs_out), 2).ToString() + " ARUB";
                        break;
                    case "AUAH":
                        exchange_to_pic.Image = Properties.Resources.uah as Bitmap;
                        curs_out = Convert.ToDecimal(AllCursAndFee["AUAH"].Split(':')[0].Replace('.', ','));
                        out_rub.Text = "В рублях: " + decimal.Round(Decimal.Multiply((decimal)AllBalance["AUAH"], curs_out), 2).ToString() + " ARUB";
                        u_balance_to.Text = "Баланс: " + decimal.Round((decimal)AllBalance["AUAH"], 2).ToString();
                        break;
                    default:
                        exchange_to_pic.Image = Properties.Resources.rub as Bitmap;
                        break;
                }
            }
        }

        private void UpdateToRub()
        {
            decimal bal = Decimal.Multiply(Convert.ToDecimal(AllBalance["AUSD"].ToString()), Convert.ToDecimal(AllCursAndFee["AUSD"].Replace('.', ',')));
            usd_to_rub.Text = "₽" + decimal.Round(bal, 2).ToString();
            bal = Decimal.Multiply(Convert.ToDecimal(AllBalance["AUAH"].ToString()), Convert.ToDecimal(AllCursAndFee["AUAH"].Replace('.', ',')));
            uah_to_rub.Text = "₽" + decimal.Round(bal, 2).ToString();
        }

        private void Copy_adrUSD_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(AllAddres["AUSD"]);
        }

        private void Copy_adrUAH_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(AllAddres["AUAH"]);
        }

        private void Copy_adrRUB_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(AllAddres["ARUB"]);
        }

        private void UpUSD_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(string.Format("http://alas-wallet.xyz/price.html" + "?id="+ApiRequest.ID));
        }

        private void Bu_alas_Click(object sender, EventArgs e)
        {
            u_alas.Checked = true;
        }

        private void TabPage2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void TabPage1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void TabPage3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void Balance_transfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar == (char)Keys.Back) return;
            else
                e.Handled = true;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void UpdateToRub(object sender, EventArgs e)
        {
            decimal bal = Decimal.Multiply(Convert.ToDecimal(AllBalance["AUSD"].ToString()), Convert.ToDecimal(AllCursAndFee["AUSD"].Replace('.', ',')));
            usd_to_rub.Text = "₽" + decimal.Round(bal, 2).ToString();
            bal = Decimal.Multiply(Convert.ToDecimal(AllBalance["AUAH"].ToString()), Convert.ToDecimal(AllCursAndFee["AUAH"].Replace('.', ',')));
            uah_to_rub.Text = "₽" + decimal.Round(bal, 2).ToString();
        }
    }
}

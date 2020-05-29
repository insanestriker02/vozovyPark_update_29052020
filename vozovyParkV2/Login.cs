using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace vozovyParkV2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
        }

        private void loginClick(object sender, EventArgs e)
        {
            SHA256 sha256 = SHA256.Create();
            string user = uzivJmenoTxtBx.Text;
            string pass = hesloTxtBx.Text;
            byte[] userByte = Encoding.UTF8.GetBytes(user);
            byte[] encryptedPass = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
            string path = Environment.CurrentDirectory + "\\Uzivatele" + "\\" + BitConverter.ToString(userByte).Replace("-","").ToLower() + ".txt";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            if (!File.Exists(path))
            {
                label6.Text = "Zadali jste špatné jméno nebo heslo";
                label6.Show();
            }
            if (uzivJmenoTxtBx.Text == "" || hesloTxtBx.Text == "")
            {
                if (uzivJmenoTxtBx.Text == "")
                {
                    label4.Show();
                    label4.Text = "Zadejte uživatelské jméno";
                }

                if (hesloTxtBx.Text == "")
                {
                    label5.Show();
                    label5.Text = "Zadejte heslo";
                }
            }
            fs.Close();

            #region adminLogin
            if (user == "admin")
            {
                
                Regex rx = new Regex(@"(?<=pass: )\S+");
                using (StreamReader sr = new StreamReader(path))
                {
                    //Regex rx = new Regex(@"(?<=pass: )\S+");
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        if (rx.IsMatch(line))
                        {
                            if (Convert.ToString(rx.Match(line)) == BitConverter.ToString(encryptedPass).Replace("-", "").ToLower())
                            {
                                AdminskyForm af = new AdminskyForm();
                                af.Show();
                                this.Hide();
                                
                            }
                            else
                            {
                                label6.Text = "Zadali jste spatne heslo!";
                                label7.Text = pass;
                                label6.Show();
                            }
                        }
                        
                    }
                }
            }
            #endregion

            bool zmenahesla = false;
            Regex rg = new Regex(@"(?<=pass: )\S+");
            if (user != "" && pass != "")
            {
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (!rg.IsMatch(lines[i])  /*lines[i].Contains("zmenahesla")*/)
                        {
                            zmenahesla = true;
                        }
                    }
                    if (File.Exists(path) && zmenahesla == true)
                    {
                        zmenaHesla zh = new zmenaHesla(pass);
                        zh.Show();
                        this.Hide();
                    }
                }
            }
            
            




            if (File.Exists(path) && user != "admin")
            {
                string password = "";
                using (StreamReader sr = new StreamReader(path))
                {


                    Regex rx = new Regex(@"(?<=pass: )\S+");
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (rx.IsMatch(line))
                        {
                            password = Convert.ToString(rx.Match(line));
                            label5.Text = password;
                        }
                    }
                    label5.Text = password;
                    label5.Show();
                }
                if (BitConverter.ToString(encryptedPass).Replace("-", "").ToLower() == password)
                {

                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(DateTime.Now);
                    }
                    this.Hide();
                    UzivatelskyForm uf = new UzivatelskyForm();
                    uf.Show();  
                }
            }
            fs.Close();
            
        }
        
        #region TxtBxesFocused
        private void uzivJmenoFocus(object sender, EventArgs e)
        {
            label4.Hide();
            //label5.Hide();
            label6.Hide();
            
        }
        private void hesloFocus(object sender, EventArgs e)
        {
            //label4.Hide();
            label5.Hide();
            label6.Hide();
        }

        #endregion

        private void hesloTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = loginBtn;
                
            }
        }

        private void loginBtn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                loginBtn.PerformClick();
            }
        }
    }
}

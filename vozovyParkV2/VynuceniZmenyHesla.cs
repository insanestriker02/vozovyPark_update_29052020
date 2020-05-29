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
using System.Text.RegularExpressions;

namespace vozovyParkV2
{
    public partial class VynuceniZmenyHesla : Form
    {
        public VynuceniZmenyHesla()
        {
            InitializeComponent();
            listUzivatelu.Items.Add("aaaa");
            string path = Environment.CurrentDirectory + "\\Uzivatele";
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles(); //Getting Text files
            string[] uzivatele = new string[Files.Length];
            for (int i = 0; i < Files.Length; i++)
            {
                uzivatele[i] = Files[i].Name;
            }
            for (int i = 0; i < uzivatele.Length; i++)
            {
                listUzivatelu.Items.Add(Encoding.UTF8.GetString(StringToByteArrayFastest(uzivatele[i].Replace(".txt",""))));
            }
        }

        #region toto jsem zkopiroval z netu


        public static byte[] StringToByteArrayFastest(string hex)
        {
            //if (hex.Length % 2 == 1)
            //    throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
        #endregion

        private void potvrdPassResetBtn_Click(object sender, EventArgs e)
        {
            
            string selectedUser = listUzivatelu.SelectedItem.ToString();
            byte[] selectedUserByte = Encoding.UTF8.GetBytes(selectedUser);
            string path = Environment.CurrentDirectory + "\\Uzivatele" + "\\" + BitConverter.ToString(selectedUserByte).ToLower().Replace("-","") + ".txt";
            string tempFile = Environment.CurrentDirectory + "\\Uzivatele" + "\\" + "tempUserFutureToBeRenamed" + ".txt";
            //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            using (StreamReader sr = new StreamReader(path))
            using (StreamWriter sw = File.AppendText(tempFile))
            {
                Regex rx = new Regex(@"(?<=pass: )\S+");
                string[] lns = File.ReadAllLines(path);
                //string matchLine;
                //string matchLn;
                for (int i = 0; i < lns.Length; i++)
                {
                    if (rx.IsMatch(lns[i]))
                    {
                        sw.WriteLine("pass: ");


                        //matchLine = rx.Match(lns[i]).ToString();
                        //matchLn = lns[i];
                        //string emptyPass = "";
                        //lns[i] = emptyPass;  //lns[i].Replace(rx.Match(lns[i]).ToString(),"");
                        //MessageBox.Show("Heslo úspěšně smazáno", "Vynucená změna hesla");
                        //this.Close();
                    }
                    else
                    {
                        sw.WriteLine(sr.ReadLine());
                    }

                    
                }
                //fs.Close();
                
                
            }
            File.Delete(path);
            File.Move(tempFile, path);
            MessageBox.Show("Heslo úspěšně smazáno", "Vynucená změna hesla");
            this.Close();
        }
    }

}

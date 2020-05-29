using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vozovyParkV2
{
    public partial class zmenaHesla : Form
    {
        public zmenaHesla(string pass)
        {
            InitializeComponent();
            string stareHeslo = pass;
            label6.Hide();
            label6.Text = stareHeslo;
            label4.Hide();
            label5.Hide();

        }

        private void potvrdBtn_Click(object sender, EventArgs e)
        {
            string pathNew;

            string stareHesloEntered = stareHesloTxtBx.Text;
            string noveHesloEntered = newPassTxtBx.Text;
            if (stareHesloEntered == label6.Text)
            {
                if (noveHesloEntered != stareHesloEntered)
                {

                }
            }
            else
            {
                label4.Text = "Zadali jste špatné staré heslo!";
            }
        }
    }
}

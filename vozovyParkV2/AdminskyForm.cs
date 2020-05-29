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
    public partial class AdminskyForm : Form
    {
        public AdminskyForm()
        {
            InitializeComponent();
        }

        private void zmenaHeslaClick(object sender, EventArgs e)
        {
            VynuceniZmenyHesla vzh = new VynuceniZmenyHesla();
            //UzivatelskyForm uv = new UzivatelskyForm();
            //uv.Close();
            vzh.ShowDialog();
        }
    }
}

using DocGen7.Кастомные_контролы;
using OWC_Aggreems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfa_symple
{
    public partial class Editor_Price : Form
    {



        private string SQL = "";
        private Bootstrap _main = null;

        public Editor_Price(Bootstrap main)
        {
            //InitializeComponent();
            XInitializeComponent();
            _main = main;
            Action Update = UpdateMainScreen;
            LVCX.Dock = DockStyle.Fill;

        }


        public void UpdateMainScreen(string sql)
        {
            SQL = sql;
            LVCX.UpdateMainScreen(sql);
        }

        public void UpdateMainScreen()
        {

            LVCX.UpdateMainScreen(SQL);
        }

        private void Editor_Price_Load(object sender, EventArgs e)
        {

        }

        private void LVCX_Load(object sender, EventArgs e)
        {

        }

        private void LVCX_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {

        }
    }
}

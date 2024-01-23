using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfa_symple;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Doc4Lab
{
    public partial class AgreementEditorWindow : Form
    {
        public AgreementEditorWindow()
        {
            InitializeComponent();
            //растяжка окна
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Left = 0;
            this.Top = 0;




        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void SearchAgrems_Click(object sender, EventArgs e)
        {
            //Нажали F5
            отобразитьДоговораToolStripMenuItem_Click(sender, e);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void подключитьсяКБазеДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отключитьсяОтБазыДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отобразитьДоговораToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void новыйДоговорToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string SQL = $"INSERT INTO Agreements (Date,TotalSum)" +
                $"OUTPUT inserted.Guid  Values ('{DateTime.Now.ToShortDateString()}',0.0) ";
            ConnectorDB Data_point = new ConnectorDB();
            Data_point.ExecSQL(SQL);
            Data_point.Dispose();

            // отобразитьДоговораToolStripMenuItem_Click(sender, e);

        }

        private void Split_Agrems_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchAndFilter_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Create_New_ClientNAgreement(object sender, EventArgs e)
        {
            if (New_Client_Type.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите тип клиента: физическое или юридическое лицо ");
                return;
            }

            //
            // СОздаем нового клиента 
            ConnectorDB ConnectorDB = new ConnectorDB();

            string New_Date = New_Client_Date.Text;

            //путсая даата - сегодня
            if ((New_Date == "  .  .    ") || (New_Date== "  .  ."))
                { New_Date = DateTime.Now.ToShortDateString();  }

            string New_Client_Guid = Guid.NewGuid().ToString();
            string New_Agreement_Guid = Guid.NewGuid().ToString();


            int ClientTypeID = New_Client_Type.SelectedIndex + 1; //1 -фз 2 -юр


            //Тут вызывается самописная процедура внесения данных
            string ProcedureName = "[InsertNewAgreementWithEntity]";//юрлицо
            if (ClientTypeID == 1)
            {
                ProcedureName = "[InsertNewAgreementWithPrivate]";//физлица
            }


            string SQL = @"Declare @return_value int ;
                         EXEC @return_value = [dbo]." + ProcedureName+" "+ 
                        @"@Date = N'"+New_Date+"', "+
		                @"@Numdoc = N'"+ New_CLient_Number.Text + "', "+
		                "@NewDoc = '"+New_Agreement_Guid+"', "+
		                "@NewClient = '"+New_Client_Guid+"' ;" + 
                        "SELECT  'Return Value' = @return_value";

            try
            {
                string Result = ConnectorDB.ExecSQL(SQL);
                if (Result == null)
                {
                    MessageBox.Show("Новый клиент не добавлен. Вводные данные содержали ошибки.");
                }

            }
            catch
            { }



        }
    }
}

﻿using System;
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

        public MainWindow parent_core;

        public AgreementEditorWindow()
        {
            InitializeComponent();
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
            if ((New_Client_Type.SelectedIndex < 0) || (New_CLient_Number.Text == ""))
            {
                string MSG = "";

                if (New_Client_Type.SelectedIndex < 0)
                    MSG += "Выберите тип клиента: физическое или юридическое лицо. \n";

                if (New_CLient_Number.Text == "")
                    MSG += "Укажите номер документа \n";

                MessageBox.Show(MSG);

                parent_core.SearchData_Click(sender, e);
                return;
            }

            //
            // СОздаем нового клиента 
            ConnectorDB ConnectorDB = new ConnectorDB();

            string New_Date = New_Client_Date.Text;

            //путсая даата - сегодня
            if ((New_Date == "  .  .    ") || (New_Date == "  .  ."))
            { New_Date = DateTime.Now.ToShortDateString(); }

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
                         EXEC @return_value = [dbo]." + ProcedureName + " " +
                        @"@Date = N'" + New_Date + "', " +
                        @"@Numdoc = N'" + New_CLient_Number.Text + "', " +
                        "@NewDoc = '" + New_Agreement_Guid + "', " +
                        "@NewClient = '" + New_Client_Guid + "' ;" +
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

            New_Client_Date.Text = "";
            New_CLient_Number.Text = "";

            //обновлние
            parent_core.SearchData_Click(sender, e);


        }

        //Обновим привязнное таблицу клиентов
        private void listView_agreemtns_SelectedIndexChanged(object sender, EventArgs e)
        {



        }   //

        /// <summary>
        /// Список договоров  по клиенту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_agreemtns_Click(object sender, EventArgs e)
        {
            if (listView_agreemtns.SelectedItems == null)
                return;

            if (listView_agreemtns.SelectedItems.Count == 0)
                return;

            int ix = listView_agreemtns.Columns.IndexOfKey("Guid");
            //выход по пустышке
            if (ix < 0)
            { return; }

            string Guid = listView_agreemtns.SelectedItems[0].SubItems[ix].Text;




            //SelectClientsForAgreementsByID
            string SQL = "SELECT * FROM [dbo].[SelectClientsForAgreementsByID] ('" + Guid + "' )";
            listView_Clients.Items.Clear();

            //Колонки
            listView_Clients.Columns.Clear();

            using (ConnectorDB con = new ConnectorDB())
            using (SqlDataReader dr = con.ExecSQL(SQL, null))
            {
                if (dr != null)
                    while (dr.Read())
                    {
                        if (!dr.HasRows) break;

                        if (listView_Clients.Columns.Count == 0)
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                ColumnHeader ch = new ColumnHeader();
                                ch.Width = 100;
                                ch.Name = dr.GetName(i);
                                ch.Text = dr.GetName(i);

                                if (ch.Name.ToLower().IndexOf("guid") > -1)
                                    ch.Width = 50;

                                if (ch.Name.ToLower()==("id") )
                                    ch.Width = 50;
                                /// ch.Width = 200; для отладки

                                if (ch.Name.ToLower().IndexOf("name") > -1)
                                    ch.Width = 200;

                                ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                                listView_Clients.Columns.Add(ch);


                            }

                        }

                        //Select 	link.[LinkGuid], cp.Name as Name_Personal,  link.ClientTypeID From 
                        ListViewItem lv = new ListViewItem();

                        lv.Text = dr.GetValue(0).ToString();
                        ListViewItem.ListViewSubItem x = new ListViewItem.ListViewSubItem();
                        x.Name= dr.GetName(1);
                        x.Text = dr.GetValue(1).ToString();
                        

                        lv.SubItems.Add(x);

                        ListViewItem.ListViewSubItem x2 = new ListViewItem.ListViewSubItem();
                        x2.Name = dr.GetName(2);
                        x2.Text = dr.GetValue(2).ToString();
                        lv.SubItems.Add(x2);

                        listView_Clients.Items.Add(lv);
                    }
                dr.Close();



            }

            //выбираем договор вкладку для правки
            TabControlFull.SelectedTab = tabeditor_Agreement;

        }//click

        private void listView_Clients_Click(object sender, EventArgs e)
        {

            CreateNewAgrForThisCleint.Enabled = false;
            // Запрос сведений
            //SelectAgreementsForClientByID

            if (listView_Clients.SelectedItems == null) return;
            if (listView_Clients.SelectedItems.Count == 0) return;

            string ID = listView_Clients.SelectedItems[0].SubItems[2].Text;
            string SQL = "SELECT * FROM [dbo].[SelectAgreementsForClientByID] ( '" + ID + "')";

            parent_core.UpdateMainScreen(SQL, null);

            //разблокируем кнопку для нового договора для этого клиента
            if (ID != "")
            {
                CreateNewAgrForThisCleint.Enabled = !false;

                TabControlFull.SelectedTab = tabeditor_Client;

            }

            

        }

        /// <summary>
        /// Создать новый договор и привязать к этому клиенту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewAgrForThisCleint_Click(object sender, EventArgs e)
        {
            if (New_CLient_Number.Text == "")
            {
                string MSG = "";

                if (New_CLient_Number.Text == "")
                    MSG += "Укажите номер документа \n";

                MessageBox.Show(MSG);

                parent_core.SearchData_Click(sender, e);
                return;
            }

            //
            // СОздаем нового клиента 
            ConnectorDB ConnectorDB = new ConnectorDB();

            string New_Date = New_Client_Date.Text;

            //путсая даата - сегодня
            if ((New_Date == "  .  .    ") || (New_Date == "  .  ."))
            { New_Date = DateTime.Now.ToShortDateString(); }

            int ix = listView_Clients.SelectedItems[0].SubItems.IndexOfKey("LinkGuid");
            //нет колонок нафиг
            if (ix < 0)
            { return;  }

            //существующий клиент
            string Old_Client_Guid = listView_Clients.SelectedItems[0].SubItems[ix].Text   ;

            //новый документ
            string New_Agreement_Guid = Guid.NewGuid().ToString();

            ix = listView_Clients.SelectedItems[0].SubItems.IndexOfKey("ClientTypeID");
            string ClientTypeID = (listView_Clients.SelectedItems[0].SubItems[ix].Text) ; //1 -фз 2 -юр


            //Тут вызывается самописная процедура внесения данных
            string ProcedureName = "[InsertNewAgreementForClient]";//юрлицо

            string SQL = @"Declare @return_value int ;
                         EXEC @return_value = [dbo]." + ProcedureName + " " +
                        @"@Date = N'" + New_Date + "', " +
                        @"@Numdoc = N'" + New_CLient_Number.Text + "', " +
                        "@NewDoc = '" + New_Agreement_Guid + "', " +
                        "@ExistClient = '" + Old_Client_Guid + "' ," +
                        "@ClientType ="+ClientTypeID + 
                        "; SELECT  'Return Value' = @return_value";


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

            New_Client_Date.Text = "";
            New_CLient_Number.Text = "";


        }
    }
}

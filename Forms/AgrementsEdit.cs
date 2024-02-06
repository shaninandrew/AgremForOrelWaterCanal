using DocGen7.Кастомные_контролы;
using FastCore;
using OWC_Aggreems;
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



namespace Doc4Lab
{
    public partial class AgreementEditorWindow : Form
    {

        public Bootstrap parent_core;

        //редактор строк в БД
        private UC_Editor_Row_In_DB Editor_Row_In_DB_Clients = null;
        private UC_Editor_Row_In_DB Editor_Row_In_DB_Agreements = null;

        private string Last_SQL = "";
        private List<SqlParameter> Last_params = null;


        /// <summary>
        /// Ссылка на главное окно для работы с главным окном
        /// </summary>
        /// <param name="parentCore">Родительское окно</param>
        public AgreementEditorWindow(Bootstrap parentCore = null,
            string SQL = @"select * from [dbo].[SelectAgreementsMainPoint] (1000)
                           where [Guid] in (
                                            SELECT [Guid] FROM [dbo].[SelectAgreementsByString] ('')
                                            )")
        {
            InitializeComponent();
            parent_core = parentCore;
            Last_SQL = SQL;

            Action Update_Then_Need = UpdateMainScreen;

            Editor_Row_In_DB_Clients = new UC_Editor_Row_In_DB(tabeditor_Client, Update_Then_Need);
            Editor_Row_In_DB_Agreements = new UC_Editor_Row_In_DB(tabeditor_Agreement, Update_Then_Need);

            UpdateMainScreen();

        }




        /// <summary>
        /// Выход из окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void SearchAgrems_Click(object sender, EventArgs e)
        {
            //Нажали F5
            // listView_agreemtns_SelectedIndexChanged_1(sender, e);
        }



        private void новыйДоговорToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string SQL = $"INSERT INTO Agreements (Date,TotalSum)" +
                $"OUTPUT inserted.Guid  Values ('{DateTime.Now.ToShortDateString()}',0.0) ";
            var Data_point = new FastCore.FastCore();
            Data_point.ExecSQLScalar(SQL, null);
            Data_point.Dispose();

            // отобразитьДоговораToolStripMenuItem_Click(sender, e);

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

                //parent_core.SearchData_Click(sender, e);
                return;
            }

            //
            // СОздаем нового клиента 
            FastCore.FastCore ConnectorDB = new FastCore.FastCore();

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
                string Result = ConnectorDB.ExecSQLScalar(SQL, null);
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
            //parent_core.SearchData_Click(sender, e);


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


        }//click




        /// <summary>
        /// События щелчка по списку клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_Clients_Click(object sender, EventArgs e)
        {




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

                //parent_core.SearchData_Click(sender, e);
                return;
            }

            //
            // СОздаем нового клиента 
            FastCore.FastCore ConnectorDB = new FastCore.FastCore();

            string New_Date = New_Client_Date.Text;

            //путсая даата - сегодня
            if ((New_Date == "  .  .    ") || (New_Date == "  .  ."))
            { New_Date = DateTime.Now.ToShortDateString(); }

            int ix = listView_Clients.SelectedItems[0].SubItems.IndexOfKey("LinkGuid");
            //нет колонок нафиг
            if (ix < 0)
            { return; }

            //существующий клиент
            string Old_Client_Guid = listView_Clients.SelectedItems[0].SubItems[ix].Text;

            //новый документ
            string New_Agreement_Guid = Guid.NewGuid().ToString();

            ix = listView_Clients.SelectedItems[0].SubItems.IndexOfKey("ClientTypeID");
            string ClientTypeID = (listView_Clients.SelectedItems[0].SubItems[ix].Text); //1 -фз 2 -юр


            //Тут вызывается самописная процедура внесения данных
            string ProcedureName = "[InsertNewAgreementForClient]";//юрлицо

            string SQL = @"Declare @return_value int ;
                         EXEC @return_value = [dbo]." + ProcedureName + " " +
                        @"@Date = N'" + New_Date + "', " +
                        @"@Numdoc = N'" + New_CLient_Number.Text + "', " +
                        "@NewDoc = '" + New_Agreement_Guid + "', " +
                        "@ExistClient = '" + Old_Client_Guid + "' ," +
                        "@ClientType =" + ClientTypeID +
                        "; SELECT  'Return Value' = @return_value";


            try
            {
                string Result = ConnectorDB.ExecSQLScalar(SQL, null);
                if (Result == null)
                {
                    MessageBox.Show("Новый клиент не добавлен. Вводные данные содержали ошибки.");
                }

            }
            catch
            { }

            New_Client_Date.Text = "";
            New_CLient_Number.Text = "";


        } //+новый довговра


        /// <summary>
        /// Вызов редактора догворов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_agreemtns_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*if (listView_agreemtns.SelectedItems == null)
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

            using (var con = new FastCore.FastCore())
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

                                if (ch.Name.ToLower() == ("id"))
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
                        x.Name = dr.GetName(1);
                        x.Text = dr.GetValue(1).ToString();


                        lv.SubItems.Add(x);

                        ListViewItem.ListViewSubItem x2 = new ListViewItem.ListViewSubItem();
                        x2.Name = dr.GetName(2);
                        x2.Text = dr.GetValue(2).ToString();
                        lv.SubItems.Add(x2);

                        listView_Clients.Items.Add(lv);
                    }
                dr.Close();

                  */

        }


        //берем связку
        /*  string guid = listView_agreemtns.SelectedItems[0].SubItems["Guid"].Text;

          UpdateEditorAgreementsById(guid);

          string ClientGuid = listView_agreemtns.SelectedItems[0].SubItems["LinkGuid"].Text;
          string ClientTypeID = listView_agreemtns.SelectedItems[0].SubItems["ClientTypeID"].Text;

          UpdateEditorCleintById(ClientGuid, ClientTypeID);

          //выбираем договор вкладку для правки
          TabControlFull.SelectedTab = tabeditor_Agreement;     */




        /// <summary>
        /// Сменился выделенный элемент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_Clients_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            /* CreateNewAgrForThisCleint.Enabled = false;
             // Запрос сведений
             //SelectAgreementsForClientByID

             if (listView_Clients.SelectedItems == null) return;
             if (listView_Clients.SelectedItems.Count == 0) return;

             string ID = listView_Clients.SelectedItems[0].SubItems[2].Text;
             string SQL = "SELECT * FROM [dbo].[SelectAgreementsForClientByID] ( '" + ID + "')";

             UpdateMainScreen(SQL, null);

             //разблокируем кнопку для нового договора для этого клиента
             if (ID != "")
             {
                 CreateNewAgrForThisCleint.Enabled = !false;


                 //Показываем юзер контрол для редактирования

                 /*   if (Editor_Row_In_DB != null)
                    {
                        Editor_Row_In_DB.Hide();
                        Editor_Row_In_DB.Dispose();
                        Editor_Row_In_DB = null;
                    }*/


            //

            //инфа о клиента
            //берем связку
            /*     if (listView_Clients.SelectedItems.Count > 0)
                 {
                     string guid = listView_Clients.SelectedItems[0].SubItems["LinkGuid"].Text;
                     string type_client = listView_Clients.SelectedItems[0].SubItems["ClientTypeID"].Text;

                     UpdateEditorCleintById(guid, type_client);
                 }
                 //перворот страницы
                 TabControlFull.SelectedTab = tabeditor_Client;
             } */
        }



        /// <summary>
        /// Обновляет редактор  записи клиента в нужном контроле
        /// </summary>
        /// <param name="SQL"></param>
        private void UpdateEditorCleintById(string guid, string type_client)
        {

            string table = "ClientPersonal";
            string columns = @"[Name]
                                  ,[Address]
                                  ,[Phone]
                                  ,[Email]
                                  ,[ident_doc_name]
                                  ,[ident_doc_number]
                                  ,[ident_doc_date]
                                  ,[ident_doc_issue]";

            string title = "Физические лица";

            if (type_client == "2")
            {
                table = "ClientEntity";
                columns = "[Name] ,[Address]  ,[Phone]  ,[INN]   ,[OGRN] ,[Description]";
                title = "Юридические лица";
            }

            Editor_Row_In_DB_Clients.Title = title;
            //Editor_Row_In_DB_Clients.SetMotherControls(this, parent_core);

            //Подгурзка записи
            Editor_Row_In_DB_Clients.LoadData(table, "guid", guid, columns);

        }


        /// <summary>
        /// Обновляет редактор договоров по ID
        /// </summary>
        /// <param name="guid"></param>
        private void UpdateEditorAgreementsById(string guid)
        {
            string table = "Agreements";
            string columns = @"     [Name]
                                  ,[NumDoc]
                                  ,[Date]
                                  ,[Status]
                                  ,[TotalSum]

                                ";

            //Подгурзка записи

            Editor_Row_In_DB_Agreements.Title = "Договора";
            Editor_Row_In_DB_Agreements.LoadData(table, "guid", guid, columns);
        }



        /// <summary>
        /// Без параметров - повторит последний
        /// </summary>
        public void UpdateMainScreen()
        {
            UpdateMainScreen(Last_SQL, Last_params);
        }

        //
        /// <summary>
        /// Обновляет основной экран запросом сведений
        /// </summary>
        /// <param name="SQL">Базовый Select запрос для выдачи данных</param>
        /// <param name="sql_params">Параметры</param>
        public void UpdateMainScreen(string SQL, List<SqlParameter> sql_params = null)
        {
            //-- смохраняем выделенную позицию
            int selected_item = 0;
            Point scrollTo = this.dgv_Agreements.AutoScrollOffset;
            //созраняем настройки - промотку и т.п.
            int vertical_scroll = this.dgv_Agreements.FirstDisplayedScrollingRowIndex;

             if (this.dgv_Agreements.SelectedRows != null)
             {
                 if (this.dgv_Agreements.SelectedRows.Count > 0)
                 {
                    selected_item = this.dgv_Agreements.SelectedRows[0].Index;

                 }

             }
            
            // Соединение с БД и наполение данными

            FastCore.FastCore Data_point = new FastCore.FastCore();
            FastCore.MemoryDataSource ds = new MemoryDataSource(Data_point);

            ds.Load(SQL, sql_params, "agreements");

            this.dgv_Agreements.DataSource = ds.DataSet.Tables["agreements"];
            foreach (DataGridViewColumn k in this.dgv_Agreements.Columns)
            {
                if (k.DataPropertyName.ToLower().IndexOf("id") > -1) { k.Visible = false; }
            }

          

            //---Восстановление сохраненной позы ====
            if (this.dgv_Agreements.Rows.Count > selected_item)
            {
                if (this.dgv_Agreements.SelectedRows.Count>0)
                    this.dgv_Agreements.SelectedRows[0].Selected = false;//сброс
                this.dgv_Agreements.Rows[selected_item].Selected = true;
                this.dgv_Agreements.AutoScrollOffset = scrollTo;
                try
                {
                    this.dgv_Agreements.CurrentCell = dgv_Agreements[0, selected_item];
                    this.dgv_Agreements.CurrentCell.Selected = true;
                   

                }
                catch { }



                //Anti errror

                if (selected_item > 0)
                {
                    this.dgv_Agreements.FirstDisplayedCell = dgv_Agreements.CurrentCell;
                    this.dgv_Agreements.FirstDisplayedScrollingRowIndex =  vertical_scroll;

                }

                    //this.dgv_Agreements.(selected_item);
                }

            } //Update Main screen

            private void AgreementEditorWindow_Load(object sender, EventArgs e)
        {

        }

        private void dgv_Agreements_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string Guid = dgv_Agreements.SelectedRows[0].Cells["Guid"].Value.ToString();
                string LinkedGuid = dgv_Agreements.SelectedRows[0].Cells["LinkGuid"].Value.ToString();
                string clientTypeid = dgv_Agreements.SelectedRows[0].Cells["ClientTypeID"].Value.ToString();

                UpdateEditorCleintById(LinkedGuid, clientTypeid);
                UpdateEditorAgreementsById(Guid);
            }
            catch (Exception ex)
            { }

        }
    }
}
    

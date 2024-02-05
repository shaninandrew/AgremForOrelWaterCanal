using DocGen7.Кастомные_контролы;
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

        public MainWindow parent_core;

        //редактор строк в БД
        private UC_Editor_Row_In_DB Editor_Row_In_DB_Clients = null;
        private UC_Editor_Row_In_DB Editor_Row_In_DB_Agreements = null;

        private string Last_SQL = "";
        private List<SqlParameter> Last_params = null;


        /// <summary>
        /// Ссылка на главное окно для работы с главным окном
        /// </summary>
        /// <param name="parentCore"></param>
        public AgreementEditorWindow(MainWindow parentCore=null)
        {
            InitializeComponent();

            parent_core = parentCore;

            Action Update_Then_Need = UpdateMainScreen;

            Editor_Row_In_DB_Clients = new UC_Editor_Row_In_DB(tabeditor_Client, Update_Then_Need , parent_core) ;
            Editor_Row_In_DB_Agreements = new UC_Editor_Row_In_DB(tabeditor_Agreement, Update_Then_Need,  parent_core);
      
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void SearchAgrems_Click(object sender, EventArgs e)
        {
            //Нажали F5
            listView_agreemtns_SelectedIndexChanged_1( sender,  e)    ;
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


        /// <summary>
        /// Вызов редактора догворов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_agreemtns_SelectedIndexChanged_1(object sender, EventArgs e)
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



            }

            
            //берем связку
            string guid = listView_agreemtns.SelectedItems[0].SubItems["Guid"].Text;

            UpdateEditorAgreementsById(guid);

            string ClientGuid = listView_agreemtns.SelectedItems[0].SubItems["LinkGuid"].Text;
            string ClientTypeID = listView_agreemtns.SelectedItems[0].SubItems["ClientTypeID"].Text;

            UpdateEditorCleintById(ClientGuid, ClientTypeID);

            //выбираем договор вкладку для правки
            TabControlFull.SelectedTab = tabeditor_Agreement;

        }

        /// <summary>
        /// Сменился выделенный элемент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_Clients_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
             CreateNewAgrForThisCleint.Enabled = false;
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
                if (listView_Clients.SelectedItems.Count > 0)
                {
                    string guid = listView_Clients.SelectedItems[0].SubItems["LinkGuid"].Text;
                    string type_client = listView_Clients.SelectedItems[0].SubItems["ClientTypeID"].Text;

                    UpdateEditorCleintById(guid, type_client);
                }
                //перворот страницы
                TabControlFull.SelectedTab = tabeditor_Client;

                

            }


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
            Editor_Row_In_DB_Clients.SetMotherControls(this, parent_core);

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
            Point scrollTo = this.listView_agreemtns.AutoScrollOffset;
            if (this.listView_agreemtns.SelectedItems != null)
            {
                if (this.listView_agreemtns.SelectedItems.Count > 0)
                {
                    selected_item = this.listView_agreemtns.SelectedItems[0].Index;

                }

            }

            // Соединение с БД и наполение данными

            ConnectorDB Data_point = new ConnectorDB();
            this.listView_agreemtns.Items.Clear();
            this.listView_agreemtns.Columns.Clear();

            List<string> Groups = new List<string>();
            //Красивая визуалка
            var p = this;
            var Main = parent_core;
            Main.Progresso.Value = 0;
            //--------------


            SqlDataReader dr = Data_point.ExecSQL(SQL, sql_params);

            if (dr != null)
            {
                //считываем строку из БД
                while (dr.Read())
                {
                    if (!dr.HasRows) break;

                    if (this.listView_agreemtns.Columns.Count == 0)
                    {
                        //Сохраняем
                        Last_SQL = SQL;
                        Last_params = sql_params;

                        // забиваем колонки в контроле
                        for (int i = 0; i < dr.FieldCount; i++)
                        {

                            ColumnHeader ch = new ColumnHeader();
                            ch.Width = 150;
                            ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                            ch.Text = dr.GetName(i);
                            ch.Name = dr.GetName(i);

                            //Название шире
                            if (ch.Name.ToLower() == "name")
                                ch.Width = 250;

                            //прячем все ID
                            if (ch.Name.ToLower().IndexOf("id") > -1)
                            {
                                ch.Width = 30;
                                /// ch.Width = 200; для отладки
                            }
                            else
                            {
                                ch.TextAlign = HorizontalAlignment.Center;
                                ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                            }

                            this.listView_agreemtns.Columns.Add(ch);
                        }

                    }//if первая строка

                    List<string> row = new List<string>();

                    ListViewItem lv_row = new ListViewItem();

                    string Date_for_group = "";
                    for (int i = 0; i < dr.FieldCount; i++)
                    {

                        string fieldName = dr.GetName(i);

                        string val = dr[i].ToString();
                        if (val.IndexOf("0:00:00") > 0)
                        {
                            val = val.Replace("0:00:00", "");
                            Date_for_group = val;
                        }


                        if (i > 0)
                        {
                            var x = lv_row.SubItems.Add(val);
                            x.Name = fieldName;
                            if (fieldName.ToLower().IndexOf("id") > -1)
                            {
                                //id подсветим
                                x.BackColor = Color.Coral;
                            }

                        }
                        else
                        {
                            //1 столбик
                            lv_row.Text = val;
                        }

                    }

                    Main.Progresso.Value = (Main.Progresso.Value + 10) % Main.Progresso.Maximum;
                    lv_row.UseItemStyleForSubItems = true;
                    lv_row.SubItems[1].ForeColor = Color.Coral;

                    //ГШРуппировка по датам
                    lv_row.Group = new ListViewGroup(Date_for_group);


                    var item = this.listView_agreemtns.Items.Add(lv_row);

                    if (Groups.IndexOf(Date_for_group) == -1)
                    {
                        Groups.Add(Date_for_group);
                        this.listView_agreemtns.Groups.Add("Дата", Date_for_group);


                    }
                    var group = this.listView_agreemtns.Groups[this.listView_agreemtns.Groups.Count - 1];
                    group.Items.Add(item);
                    group.Footer = " "; //разрыв дял визуалки
                    //group.Subtitle  = " Дата";

                }

                dr.Close();
            }//if

            Data_point.Dispose();

            Main.Progresso.Value = 0;
            this.listView_agreemtns.ShowGroups = true;

            //---Восстановление сохраненной позы ====
            if (this.listView_agreemtns.Items.Count > selected_item)
            {
                this.listView_agreemtns.Items[selected_item].Selected = true;
                this.listView_agreemtns.AutoScrollOffset = scrollTo;
                this.listView_agreemtns.EnsureVisible(selected_item);
            }




        } //Update Main screen


    }
}

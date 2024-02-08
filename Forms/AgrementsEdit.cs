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
using static System.ComponentModel.Design.ObjectSelectorEditor;



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

        private string Selected_Agreement_GUID = "";



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

            int ix = dgv_Clients.SelectedRows[0].Index;  // .Cells["LinkGuid"].Value.ToString();
            //нет колонок нафиг
            if (ix < 0)
            { return; }

            //существующий клиент
            string Old_Client_Guid = dgv_Clients.SelectedRows[0].Cells["LinkGuid"].Value.ToString();

            //новый документ
            string New_Agreement_Guid = Guid.NewGuid().ToString();

            //ix =   //listView_Clients.SelectedItems[0].SubItems.IndexOfKey();
            string ClientTypeID = dgv_Clients.SelectedRows[0].Cells["ClientTypeID"].Value.ToString(); //1 -фз 2 -юр


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
         

        }





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

            using (FastCore.FastCore Data_point = new FastCore.FastCore())
            {
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
                    if (this.dgv_Agreements.SelectedRows.Count > 0)
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
                        this.dgv_Agreements.FirstDisplayedScrollingRowIndex = vertical_scroll;

                    }

                    //this.dgv_Agreements.(selected_item);
                }

                Data_point.CloseConnection();
            }//using


        } //Update Main screen


        /// <summary>
        /// Загрузка окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgreementEditorWindow_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Выбор контаркта - запоминаем его ID в  Selected_Agreement_GUID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Agreements_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //глобальный выбор 
                Selected_Agreement_GUID = "";
                if (dgv_Agreements.CurrentRow != null)
                    try
                    {
                        Selected_Agreement_GUID = dgv_Agreements.CurrentRow.Cells["Guid"].Value.ToString();
                    }
                    catch
                    {
                        try
                        {
                            Selected_Agreement_GUID = dgv_Agreements.SelectedRows[0].Cells["Guid"].Value.ToString();
                        }
                        catch
                        {
                            Selected_Agreement_GUID = "";
                        }
                    }

                //=====================

                string Guid = Selected_Agreement_GUID;

                string LinkedGuid = dgv_Agreements.SelectedRows[0].Cells["LinkGuid"].Value.ToString();
                string clientTypeid = dgv_Agreements.SelectedRows[0].Cells["ClientTypeID"].Value.ToString();

                UpdateEditorCleintById(LinkedGuid, clientTypeid);
                UpdateEditorAgreementsById(Guid);

                //в фоне
                UpdateClientsList(Guid);



                //список услуг

                btn_RefreshService_Click(sender, e);



            }
            catch (Exception ex)
            { }

        }


        /// <summary>
        ///  Обновляет ListViewClient списком клиентов которые привязаны к договору
        /// </summary>
        /// <param name="Guid_of_Agreements">ID договораа</param>
        /// <returns></returns>
        public async void UpdateClientsList(string Guid_of_Agreements)
        {

            dgv_Clients.DataSource = null;

            using (FastCore.FastCore fast_core = new FastCore.FastCore())
            {
                FastCore.MemoryDataSource msd = new MemoryDataSource(fast_core);
                msd.Load($"Select * from SelectClientsForAgreementsByID ('{Guid_of_Agreements}') ", null, "clients");

                dgv_Clients.DataSource = msd.DataSet.Tables["clients"];

                if (dgv_Clients.Columns.Count > 0)
                    foreach (DataGridViewColumn item in dgv_Clients.Columns)
                    {
                        try { item.Visible = item.DataPropertyName.ToLower().IndexOf("id") > -1 ? !true : !false; }
                        catch { break; }
                    }

                fast_core.CloseConnection();
            }

        }

        private void listView_Clients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Отбор договоров по клиенту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Clients_Click(object sender, EventArgs e)
        {
            if (dgv_Clients.CurrentRow == null)
                return;

            Selected_Agreement_GUID = ""; //скидываем выделение контракта
            string ID = dgv_Clients.CurrentRow.Cells["LinkGuid"].Value.ToString();
            string SQL = "SELECT * FROM [dbo].[SelectAgreementsForClientByID] ( '" + ID + "')";

            UpdateMainScreen(SQL, null);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dgv_Clients.CurrentRow == null)
                return;


            if (Selected_Agreement_GUID == "") return;

            // добавляем пакет услуг. Процедуре нужен контракт. Данные добавяться из прайса действующего на дату.
            using (FastCore.FastCore fc = new FastCore.FastCore())
            {
                fc.ExecSQLScalar(@$"DECLARE @return_value int ;
                                EXEC	@return_value = [dbo].[InsertNewServiceForAgreement] @GuidAgr = '{Selected_Agreement_GUID}';
                            Select @return_value ", null);
            }


            UpdateServiceList(Selected_Agreement_GUID);


        }


        /// <summary>
        /// Список услуг оказываемых по договору
        /// </summary>
        /// <param name="AgreementGuid">Guid контракта</param>
        void UpdateServiceList(string Guid)
        {
            dgv_Service.DataSource = null;
            string sql = $"SELECT * FROM  SelectServicesByAgreementID ('{Guid}') ";

            using (FastCore.FastCore fast_core = new FastCore.FastCore())
            {
                FastCore.MemoryDataSource msd = new MemoryDataSource(fast_core);
                msd.Load(sql, null, "services");

                dgv_Service.DataSource = msd.DataSet.Tables["services"];

                if (dgv_Service.Columns.Count > 0)
                    foreach (DataGridViewColumn item in dgv_Service.Columns)
                    {
                        try { item.Visible = item.DataPropertyName.ToLower().IndexOf("id") > -1 ? !true : !false; }
                        catch { break; }
                    }

                ///FFF
                //
                //_FXX
                // --- Итого по договору
                TotalSum.Text =        fast_core.ExecSQLScalar($"Select TotalSum from GetTotalServiceByAgreementID('{Guid}')", null);

                fast_core.CloseConnection();
            }

        }

        /// <summary>
        /// Обновление списка услуг
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_RefreshService_Click(object sender, EventArgs e)
        {
            string guid = dgv_Agreements.CurrentRow.Cells["Guid"].Value.ToString();
            UpdateServiceList(guid);
        }

        private void btn_DeleteService_Click(object sender, EventArgs e)
        {
            using (FastCore.FastCore fc = new FastCore.FastCore())
            {
                foreach (DataGridViewRow r in dgv_Service.SelectedRows)
                {
                    string ID = r.Cells["Id"].Value.ToString();
                    fc.ExecSQLScalar(@$"
                                        DECLARE	@return_value int
                                        EXEC	@return_value = [dbo].[DeleteServiceByAgreements]
		                                        @ID = {ID}
                                        SELECT	'Return Value' = @return_value", null);
                }

                fc.CloseConnection();
            }


            btn_RefreshService_Click(sender, e);
        }

        /// <summary>
        /// Добавляет услугу
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddService_Click(object sender, EventArgs e)
        {
            using (FastCore.FastCore fc = new FastCore.FastCore())
            {
                string SQL = "";
                foreach (DataGridViewRow r in dgv_Service.SelectedRows)
                {
                    string ID = r.Cells["Id"].Value.ToString();
                    SQL += @$"  UPDATE ServiceByAgreements  SET Count = Count+1  WHERE [ID] = {ID}  ;  ";
                }

                fc.ExecSQLScalar(SQL, null);
                fc.CloseConnection();
            }


            btn_RefreshService_Click(sender, e);
        }

        /// <summary>
        /// Обнулить все выделенные услуги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (FastCore.FastCore fc = new FastCore.FastCore())
            {
                string SQL = "";
                foreach (DataGridViewRow r in dgv_Service.SelectedRows)
                {
                    string ID = r.Cells["Id"].Value.ToString();
                    SQL += @$"  UPDATE ServiceByAgreements  SET Count = 0 WHERE [ID] = {ID}  ;  ";
                }

                fc.ExecSQLScalar(SQL, null);

                fc.CloseConnection();
            }


            btn_RefreshService_Click(sender, e);
        }

        private void dgv_Agreements_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

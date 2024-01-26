using Doc4Lab;
using DocGen7.Формы;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace wfa_symple
{
    public partial class MainWindow : Form
    {
        Color default_Color = Color.White;
        Color default_BackColor = Color.White;

        //Вложенные формы
        public Editor_Price editor_price = new Editor_Price();
        public ReportGenerator report_generator = new ReportGenerator();
        public Settings settings = new Settings();
        public AgreementEditorWindow agr_editor = new AgreementEditorWindow();


        public ConnectorDB Data_point = null;

        public string MainSQL = "";

        //последние параметры
        private string Last_SQL = "";
        private List<SqlParameter> Last_params = null;


        public Action task_alone = null;

        

        public MainWindow()
        {
            InitializeComponent();


            //скрытый редактор


            editor_price.Dock = DockStyle.Fill;
            editor_price.FormBorderStyle = FormBorderStyle.None;
            editor_price.TopLevel = false;
            editor_price.Parent = Main_Split_Conatainer.Panel2;

            report_generator.Dock = DockStyle.Fill;
            report_generator.FormBorderStyle = FormBorderStyle.None;
            report_generator.TopLevel = false;
            report_generator.Parent = Main_Split_Conatainer.Panel2;


            settings.Dock = DockStyle.Fill;
            settings.FormBorderStyle = FormBorderStyle.None;
            settings.TopLevel = false;
            settings.Parent = Main_Split_Conatainer.Panel2;



            agr_editor.Dock = DockStyle.Fill;
            agr_editor.FormBorderStyle = FormBorderStyle.None;
            agr_editor.TopLevel = false;
            agr_editor.Parent = Main_Split_Conatainer.Panel2;


            //Загрузить договора
            ShowAgreements_Click(this, new EventArgs());
            //ShowPrice_Click(this, new EventArgs());

        }


        private void HideAll()
        {
            editor_price.Hide();
            report_generator.Hide();
            settings.Hide();
            agr_editor.Hide();

            ShowPrice.BackColor = Color.DodgerBlue;
            ShowPrice.ForeColor = Color.Navy;


            ShowAgrs.BackColor = Color.DodgerBlue;
            ShowAgrs.ForeColor = Color.Navy;

            ShowGenerator.BackColor = Color.DodgerBlue;
            ShowGenerator.ForeColor = Color.Navy;

            Show_Settings.BackColor = Color.DodgerBlue;
            Show_Settings.ForeColor = Color.Navy;


        }


        private void RePosButtons()
        {
            ShowGenerator.Dock = DockStyle.Bottom;
            Show_Settings.Dock = DockStyle.Bottom;
            //.Dock = DockStyle.Bottom;
            ShowAgrs.Dock = DockStyle.Bottom;
            ShowPrice.Dock = DockStyle.Bottom;

        }

        private void ShowPrice_Click(object sender, EventArgs e)
        {
            HideAll();
            editor_price.Show();

            RePosButtons();
            ShowPrice.Dock = DockStyle.Top;


            ShowPrice.BackColor = Color.Navy;
            ShowPrice.ForeColor = Color.Azure;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideAll();
            report_generator.Show();

            RePosButtons();
            ShowGenerator.Dock = DockStyle.Top;

            ShowGenerator.BackColor = Color.Navy;
            ShowGenerator.ForeColor = Color.Azure;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            HideAll();
            settings.Show();

            RePosButtons();
            Show_Settings.Dock = DockStyle.Top;

            Show_Settings.BackColor = Color.Navy;
            Show_Settings.ForeColor= Color.Azure;

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


        private void RefreshListOfAgreements(object sender, EventArgs e)
        {
        }




        /// <summary>
        /// Поиск данных по строке ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SearchData_Click(object sender, EventArgs e)
        {
            
            List<SqlParameter> sql_params = null;

            //Сам запрос
            string SQL = $"Select  * from [Agreements] ";

            if (InputFilterText.Text != "")
            {
                sql_params = new List<SqlParameter>();
                sql_params.Add(new SqlParameter("@SEARCH", InputFilterText.Text));

                SQL += "  WHERE [ID] in ( Select ID FROM SelectAgreementsByString (@SEARCH) )";
            }

            UpdateMainScreen(SQL,sql_params);
           
        }

        private void Main_Split_Conatainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Показать договора в главном окне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAgreements_Click(object sender, EventArgs e)
        {
            ShowAgrs.Dock = DockStyle.Top;
            HideAll();
            RePosButtons();

            ShowAgrs.Dock = DockStyle.Top;
            agr_editor.parent_core = this;

            agr_editor.Show();


            ShowAgrs.BackColor = Color.Navy;
            ShowAgrs.ForeColor = Color.Azure;

            SearchData_Click(this, new EventArgs());

        }

        private void SearchData_Enter(object sender, EventArgs e)
        {

        }



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
            ConnectorDB Data_point = new ConnectorDB();
            agr_editor.listView_agreemtns.Items.Clear();
            agr_editor.listView_agreemtns.Columns.Clear();

            //Красивая визуалка
            var p = this;
            var Main = (MainWindow)p;
            Main.Progresso.Value = 0;
            //--------------


            
            SqlDataReader dr = Data_point.ExecSQL(SQL, sql_params);

            if (dr != null)
            {
              

                while (dr.Read())
                {
                    if (!dr.HasRows) break;

                    if (agr_editor.listView_agreemtns.Columns.Count == 0)
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
                            
                            agr_editor.listView_agreemtns.Columns.Add(ch);
                        }

                    }//if первая строка

                    List<string> row = new List<string>();

                    ListViewItem lv_row = new ListViewItem();
                    for (int i=0; i<dr.FieldCount; i++) 
                    {

                        string fieldName = dr.GetName(i);

                        string val = dr[i].ToString();
                        if (val.IndexOf("0:00:00") > 0)
                        {
                            val = val.Replace("0:00:00", "");
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
                    lv_row.SubItems[1].ForeColor= Color.Coral;
                    
                    agr_editor.listView_agreemtns.Items.Add(lv_row );
                }

                dr.Close();
            }//if

            Data_point.Dispose();

           
            Main.Progresso.Value = 0;
            

        }




    }

}

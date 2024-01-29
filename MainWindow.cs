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
        public Editor_Price editor_price = null;
        public ReportGenerator report_generator = new ReportGenerator();
        public Settings settings = new Settings();
        public AgreementEditorWindow agr_editor = null;


        public ConnectorDB Data_point = null;

        public string MainSQL = "";

        //последние параметры
        private string Last_SQL = "";
        private List<SqlParameter> Last_params = null;


        public Action task_alone = null;



        public MainWindow()
        {
            InitializeComponent();

            agr_editor = new AgreementEditorWindow(this);

            //скрытый редактор


            editor_price = new Editor_Price(this);
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
            Show_Settings.ForeColor = Color.Azure;

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
            //если активно окно работы с договорами
            if (editor_price.Visible)
            {

                List<SqlParameter> sql_params = null;

                //Сам запрос
                string SQL = $"Select TOP ((1000)) [Service]  ,[Price]     ,[Date_start] ,[Date_end] ,[Guid] from PriceList  ";
                //Сортировка результатов
                SQL += "  order by [Date_start] desc";

                editor_price.LVCX.UpdateMainScreen(SQL, sql_params);

            }
            //если активно окно работы с договорами
            if (agr_editor.Visible)
            {

                List<SqlParameter> sql_params = null;

                //Сам запрос
                string SQL = $"Select * from SelectAgreementsMainPoint (1000) ";

                if (InputFilterText.Text != "")
                {
                    sql_params = new List<SqlParameter>();
                    sql_params.Add(new SqlParameter("@SEARCH", InputFilterText.Text));

                    SQL += "  WHERE [ID] in ( Select ID FROM SelectAgreementsByString (@SEARCH) )  ";
                }

                //Сортировка результатов
                SQL += "  order by [Date] desc";
                agr_editor.UpdateMainScreen(SQL, sql_params);
            }

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



       

        /// <summary>
        /// При наборе запроса можно нажать Enter для поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputFilterText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Enter?
            if (e.KeyCode == Keys.Enter) 
            {
                //ищем
                SearchData_Click(sender, e);
            }

        }
    }

}

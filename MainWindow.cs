using Doc4Lab;
using DocGen7.Формы;
using System.Data.SqlClient;


namespace wfa_symple
{
    public partial class MainWindow : Form
    {
        Color default_Color = Color.White;
        Color default_BackColor = Color.White;

        //Вложенные формы
        public Editor_Price ep = new Editor_Price();
        public AgrmGenerator agrm = new AgrmGenerator();
        public Settings settings = new Settings();
        public AgreementEditorWindow agr_editor = new AgreementEditorWindow();


        public ConnectorDB Data_point = null;

        public MainWindow()
        {
            InitializeComponent();


            //скрытый редактор


            ep.Dock = DockStyle.Fill;
            ep.FormBorderStyle = FormBorderStyle.None;
            ep.TopLevel = false;
            ep.Parent = Main_Split_Conatainer.Panel2;

            agrm.Dock = DockStyle.Fill;
            agrm.FormBorderStyle = FormBorderStyle.None;
            agrm.TopLevel = false;

            agrm.Parent = Main_Split_Conatainer.Panel2;


            settings.Dock = DockStyle.Fill;
            settings.FormBorderStyle = FormBorderStyle.None;
            settings.TopLevel = false;
            settings.Parent = Main_Split_Conatainer.Panel2;



            agr_editor.Dock = DockStyle.Fill;
            agr_editor.FormBorderStyle = FormBorderStyle.None;
            agr_editor.TopLevel = false;
            agr_editor.Parent = Main_Split_Conatainer.Panel2;



            //ShowPrice_Click(this, new EventArgs());

        }



        private void ShowPrice_Click(object sender, EventArgs e)
        {


            agrm.Hide();
            ep.Show();
            settings.Hide();
            agr_editor.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            agrm.Show();
            ep.Hide();
            agr_editor.Hide();
            settings.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            agrm.Hide();
            ep.Hide();
            agr_editor.Hide();
            settings.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            agrm.Hide();
            ep.Hide();
            settings.Hide();
            agr_editor.Show();
        }


        private void RefreshListOfAgreements(object sender, EventArgs e)
        {



        }

        private void SearchData_Click(object sender, EventArgs e)
        {
            ConnectorDB Data_point = new ConnectorDB();
            agr_editor.listView_agreemtns.Items.Clear();

            List<string> cols = new List<string>() { "NumDoc", "Date", "Name", "ID", "Guid", "TotalSum" };


            agr_editor.listView_agreemtns.Columns.Clear();

            foreach (string col in cols)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Width = 100;

                ch.Text = col;
                //Название шире
                if (col.ToLower() == "name")
                    ch.Width = 200;

                if (ch.Text.ToLower().IndexOf("id") > -1)
                {
                    ch.Width = 0;
                }
                else
                {

                    ch.TextAlign = HorizontalAlignment.Center;
                    ch.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

                }

                agr_editor.listView_agreemtns.Columns.Add(ch);
            }

            string in_sql = string.Join(",", cols);

            //Сам запрос
            string SQL = $"Select  {in_sql} from [Agreements] ";

            List<SqlParameter> sql_params = null;

            if (InputFilterText.Text != "")
            {
                sql_params = new List<SqlParameter>();
                sql_params.Add(new SqlParameter("@SEARCH", InputFilterText.Text));

                SQL += "  WHERE (Name like  '%'+@SEARCH+'%') ";
            }



            SqlDataReader dr = Data_point.ExecSQL(SQL, sql_params);

            if (dr != null)
            {
                while (dr.Read())
                {
                    List<string> row = new List<string>();

                    foreach (string col in cols)
                    { row.Add(dr[col].ToString()); }

                    agr_editor.listView_agreemtns.Items.Add(new ListViewItem(row.ToArray()));
                }

                dr.Close();
            }//if

            Data_point.Dispose();
        }

        private void Main_Split_Conatainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

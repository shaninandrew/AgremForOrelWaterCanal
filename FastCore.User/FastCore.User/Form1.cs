namespace FastCore.User
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Runtime.ExceptionServices;
    using System.Security.Cryptography;
    using System.Text;


    public partial class Form1 : Form
    {

        string connection_string = "Server=Localhost; Trusted_Connection=True; Database=Docs;";
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

        }

        private void RunTest_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            
            FastCore fc = new FastCore(connection_string);

            //массив


            string SQL = $"Select * From Test ";
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < trackBar1.Value; i++)
            {
                s.Clear();
                //StringBuilder s = new StringBuilder();
                //string s = "";


                Stopwatch sw = new Stopwatch();
                sw.Start();

                using (SqlDataReader dr = fc.ExecSQL(SQL, null))
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            s.AppendLine(dr.GetString(2).ToString() + dr.GetGuid(1).ToString() + "\n");
                            // s += dr.GetString(2).ToString() + dr.GetGuid(1).ToString() + "\n";
                        }
                        dr.Close();
                        // fc.CloseConnection();

                    }
                //fc.Dispose();
                sw.Stop();



                if (i % 2 == 0) GC.Collect();
                listBox1.Items.Add($"Запрос выполнен за {sw.ElapsedMilliseconds} мс -  {s.Length} байт ( {s.Length / (sw.ElapsedMilliseconds)} Кб/с) | {GC.GetGCMemoryInfo().MemoryLoadBytes}  байт загружено");



                dataGridView1.DataSource = null;

                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                MemoryDataSource ds = new MemoryDataSource(connection_string);
                ds.Load(SQL, null, "test");
                sw1.Stop();
                listBox1.Items.Add($" * Загрузка данных выполнена за {sw1.ElapsedMilliseconds} мс -  {ds.DataSet.Tables[0].Rows.Count} строк  ");

                sw1.Start();
                dataGridView1.DataSource = ds.DataSet.Tables[0];
                sw1.Stop();
                listBox1.Items.Add($" * отображение данных за {sw1.ElapsedMilliseconds} мс   ");
            }  // FOR

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Searcher_TextChanged(object sender, EventArgs e)
        {

            string SQL = $"Select * From Test";
            string lower = Searcher.Text.ToLower();

            List<SqlParameter> sql_params = null;

            if (Searcher.Text.Length > 0)
            {
                sql_params = new List<SqlParameter>() { new SqlParameter("@Info", lower) };

                SQL += $" where ([Info] like '%'+@Info+'%')";

            }

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            MemoryDataSource ds = new MemoryDataSource(connection_string);
            ds.Load(SQL, sql_params , "test");
            dataGridView1.DataSource = ds.DataSet.Tables[0];
            sw1.Stop();

            listBox1.Items.Add($"Запрос + загрузка данных {sw1.ElapsedMilliseconds} мс: {SQL}");


        }
    }
}

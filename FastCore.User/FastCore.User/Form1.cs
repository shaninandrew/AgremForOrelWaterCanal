namespace FastCore.User
{

    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Runtime.ExceptionServices;
    using System.Text;
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RunTest_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string connection_string = "Server=Localhost; Trusted_Connection=True; Database=Docs;";
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
                            s.AppendLine ( dr.GetString(2).ToString() + dr.GetGuid(1).ToString() + "\n");
                           // s += dr.GetString(2).ToString() + dr.GetGuid(1).ToString() + "\n";
                        }
                        dr.Close();
                       // fc.CloseConnection();

                    }
                //fc.Dispose();
                sw.Stop();
                


                if (i%2==0) GC.Collect();   
                listBox1.Items.Add($"«апрос выполнен за {sw.ElapsedMilliseconds} мс -  {s.Length} байт ( {s.Length / (sw.ElapsedMilliseconds)}  б/с) | {GC.GetGCMemoryInfo().MemoryLoadBytes}  байт загружено" );
            


            dataGridView1.DataSource = null;

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            MemoryDataSource ds = new MemoryDataSource(connection_string);
            ds.Load(SQL, null, "test");
            sw1.Stop();
            listBox1.Items.Add($" * «агрузка данных выполнена за {sw1.ElapsedMilliseconds} мс -  {ds.DataSet.Tables[0].Rows.Count} строк  ");

            sw1.Start();
            dataGridView1.DataSource = ds.DataSet.Tables[0];
            sw1.Stop();
            listBox1.Items.Add($" * отображение данных за {sw1.ElapsedMilliseconds} мс   ");
            }  // FOR

        }
    }
}

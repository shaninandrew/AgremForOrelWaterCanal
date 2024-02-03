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

            FastCore fc = new FastCore("Server=Localhost; Trusted_Connection=True; Database=Docs;");

            //массив


            StringBuilder s = new StringBuilder();

            for (int i = 0; i < trackBar1.Value; i++)
            {
                s.Clear();
                //StringBuilder s = new StringBuilder();
                //string s = "";


                Stopwatch sw = new Stopwatch();
                sw.Start();

                using (SqlDataReader dr = fc.ExecSQL($"Select * From Test where {i}={i}", null))
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
                listBox1.Items.Add($"Запрос выполнен за {sw.ElapsedMilliseconds} мс -  {s.Length} байт ( {s.Length / (sw.ElapsedMilliseconds)} Кб/с) | {GC.GetGCMemoryInfo().MemoryLoadBytes}  байт загружено" );
            }

            


        }
    }
}

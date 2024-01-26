using Doc4Lab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfa_symple;

namespace DocGen7.Кастомные_контролы
{
    /// <summary>
    /// Контрол для реадктирования строк в базе данных
    /// 1 строки: нужно передать имя таблицы и имя ID колонки, ключ ID - для обновления
    /// </summary>
    public partial class UC_Editor_Row_In_DB : UserControl
    {

        /// <summary>
        /// Таблица откуда читать/писать данные
        /// 
        /// </summary>
        public string _table = "Agreements";
        public string _ID_name = "Guid";
        public string _ID_Value = "";

        private ConnectorDB db = null;
        private string? _connection_string = null;

        // список контролов
        private List<MaskedTextBox> _list = new List<MaskedTextBox>();
        private List<Label> _titles = new List<Label>();


        public UC_Editor_Row_In_DB(Control parent, string? connection_string = null)
        {
            InitializeComponent();
            _connection_string = connection_string;
            this.Parent = parent;
        }


        public void LoadData(string table, string ID_name, string ID_Value, string Fields = "*")
        {
            var p =  this.Parent;
            while (p.GetType().Name != "MainWindow")
            {
                if (p != null)
                    p = p.Parent;
            }

            var Main = (MainWindow)p ;
            Main.Progresso.Value = 0;

            _table = table;
            _ID_name = ID_name;
            _ID_Value = ID_Value;

            SaveIt.Enabled = false;

            string sql = $"SELECT {Fields} FROM [{_table}] WHERE {_ID_name} = @IDV ";

            using (db = new ConnectorDB())
            {


                List<SqlParameter> sql_par = new List<SqlParameter>();
                sql_par.Add(new SqlParameter("@IDV", _ID_Value));
                using (SqlDataReader dr = db.ExecSQL(sql, sql_par))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            //нет данных пока!
                            if (!dr.HasRows) { break; }
                            _list.Clear();
                            _titles.Clear();

                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                
                                Main.Progresso.Value = (Main.Progresso.Value +10) % Main.Progresso.Maximum;

                                MaskedTextBox txt = new MaskedTextBox();
                                txt.Parent = this;
                                txt.Visible = false;

                                txt.Name = dr.GetName(i);
                                
                                //проверка на тип
                                txt.ValidatingType = dr.GetFieldType(i);

                                switch (dr.GetFieldType(i).Name.ToLower())
                                {
                                    case "datetime":
                                        txt.Mask = "00/00/0000";
                                        txt.ValidatingType = DateTime.Now.GetType();
                                        break;

                                    case "int":
                                        txt.Mask = "00000";
                                        break;

                                    case "float":
                                        txt.Mask = "#####0.00";
                                        break;

                                }
                                txt.Text = dr.GetValue(i).ToString();


                                //расстановка на контроле
                                txt.Top = i * (txt.Height + 2) + 5;
                                txt.Left = this.Width / 3 + 5;
                                txt.Width = Math.Abs(2 * this.Width / 3 - 5);

                                _list.Add(txt);

                                Label label = new Label();
                                label.Visible = false;
                                label.Top = txt.Top;
                                label.Left = 5;
                                label.Text = dr.GetName(i).ToString();
                                label.Width = this.Width / 3 + 3;

                                label.Parent = this;


                                _titles.Add(label);

                            }




                        }
                    }

                    dr.Close();
                }
                Main.Progresso.Value = Main.Progresso.Maximum;

                this.AutoScroll = true;
                Task.Run(async () =>
                {
                    Task.Delay(2000);
                    Main.Progresso.Value = 0;
                    Main.Progresso.Value = 0;


                });

            }//db connection

            
            //если данные есть то покажем их
            if (_list != null)
            {
                //позиция последней строки ввода 
                int last_top = 0;

                SaveIt.Hide();
                if (_list.Count > 0) 
                {
                    foreach (var t in _list.AsParallel())
                    {
                        t.Visible = true;
                        last_top = t.Top + t.Height + 5;
                    }
                    foreach (var t in _titles.AsParallel())
                    {
                        t.Visible = true;
                    }

                    SaveIt.Top = last_top;
                    SaveIt.Show();
                    SaveIt.Enabled = !false;

                }
                
                

            }



        }


        private void UC_Editor_Row_In_DB_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveIt_Click(object sender, EventArgs e)
        {

           

            using (db = new ConnectorDB())
            {
                string SQL = "Update [" + _table + "] SET ";
                string WHERE = " WHERE [" + _ID_name + "] = '" + _ID_Value + "' ";

                string Col_Val = "";
                foreach (var m in _list)
                {

                   

                    //нормальное значение
                    if (m.MaskCompleted)
                    {
                        //запятая если уже сть данные
                        if (Col_Val != "") { Col_Val += ", "; }

                        //собираем значения
                        Col_Val += " [" + m.Name + "] = '" + m.Text + "' ";
                    }
                }

                SQL = SQL + Col_Val + "  OUTPUT  Inserted.["+_ID_name+"]  " + WHERE;

                if (db.ExecSQL(SQL) == null)
                    MessageBox.Show("Не могу сохранить данные!");
               

            }
        }//SaveIt
    }
}

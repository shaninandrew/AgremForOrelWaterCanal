using Doc4Lab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfa_symple;
using static System.Net.Mime.MediaTypeNames;
using Label = System.Windows.Forms.Label;



using FastCore;
using OWC_Aggreems;




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

        private FastCore.FastCore db = null;
        private string? _connection_string = null;

        // список контролов
        private List<MaskedTextBox> _list = new List<MaskedTextBox>();
        private List<Label> _titles = new List<Label>();

       // private Bootstrap Main = null;


        public string Title = "Заголовок";
        private Label title_X = null;


        public bool DataUpdated = false;

        private Delegate _call_update = null;


        private AgreementEditorWindow agreementEditorWindow = null;
        public void SetMotherControls(AgreementEditorWindow w)
        {
            agreementEditorWindow = w;
            DataUpdated = false;

            
            //устанавливаем связь для управления главным окном (обновление и прочее)
           // Main = main;
        }

        public UC_Editor_Row_In_DB(Control parent, Action CallUpdate ,  string? connection_string = null)
        {
            InitializeComponent();
            _connection_string = connection_string;
            this.Parent = parent;

            //связка с событием
            _call_update = CallUpdate;

            //очистка и сохранение состояния
            _list.Clear();
            _titles.Clear();

           // Main= main;

            try
            {
                //попытка управлять родительским окном
                var p = this.Parent;
                if (p != null)
                {
              /*      while (p.GetType().Name != "MainWindow")
                    {
                        if (p != null)
                            p = p.Parent;
                    }

                    Main = (MainWindow)p;    */
                }//p!null
            }

            catch (Exception ex) 
                { }

            //Нельзя взять и нажать
            SaveIt.Enabled = false;

            title_X = new Label();
            title_X.Text = Title;
            title_X.Parent = this;

            title_X.Top = 5;
            title_X.Left = 5;
            title_X.Visible = true;
            title_X.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size + 2); //крупнее
            title_X.AutoSize = !true;
            title_X.Width = this.Width / 2 + 100;

            this.Dock = DockStyle.Fill;
            this.Height = parent.Height - 5;
            this.AutoScroll = false;

        }


        public void LoadData(string table, string ID_name, string ID_Value, string Fields = "*")
        {
            //управление главным окном
           // Main.Progresso.Value = 0;

            _table = table;
            _ID_name = ID_name;
            _ID_Value = ID_Value;

            SaveIt.Enabled = false;

            string sql = $"SELECT {Fields} FROM [{_table}] WHERE {_ID_name} = @IDV ";

            //title_X = new Label();
            title_X.Text = Title;
            title_X.Update();
            // title_X.Parent = this;

            /* title_X.Top = 5;
             title_X.Left = 5;
             title_X.Visible = true;
             title_X.Font = new Font(this.Font.FontFamily, this.Font.Size + 2); //крупнее
             title_X.AutoSize = true;*/

            using (db = new FastCore.FastCore())
            {

                List<SqlParameter> sql_par = new List<SqlParameter>();
                sql_par.Add(new SqlParameter("@IDV", _ID_Value));
                using (SqlDataReader dr = db.ExecSQL(sql, sql_par))
                {
                    if (dr != null)
                    {

                        //предывдущий размер списка
                        int was_list_size = _list.Count;


                        while (dr.Read())
                        {
                            //нет данных пока!
                            if (!dr.HasRows) { break; }


                            bool re_use = !false;
                            if (dr.FieldCount != _list.Count)
                            {

                                foreach (var k in _list)
                                {
                                    k.Hide();
                                    k.Dispose();
                                }

                                foreach (var k in _titles)
                                {
                                    k.Hide();
                                    k.Dispose();
                                }

                                _list.Clear();
                                _titles.Clear();
                                was_list_size = 0;
                                re_use = false;
                            }

                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                               /* if (Main != null)
                                { Main.Progresso.Value = (100 * i / dr.FieldCount) % Main.Progresso.Maximum; } 
                               */
                                //если список меньше то добавляем заново
                                if (re_use)
                                {
                                    _list[i].Name = "";
                                    _list[i].Text = "";
                                    _titles[i].Text = "";
                                }

                                //если коллекция пуста - то набиваем ее
                                if (!re_use)//(was_list_size < dr.FieldCount)
                                {

                                   var txt = new MaskedTextBox();
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
                                            txt.Text = dr.GetFloat(i).ToString().Replace(",", "");
                                            break;

                                        case "float":
                                           

                                            txt.Mask = "## ###.00";
                                            txt.ValidatingType = null;
                                            txt.Text = dr.GetFloat(i).ToString().Replace(",",".");


                                            break;

                                        case "double":
                                            txt.Mask = "## ###.00";
                                            txt.ValidatingType = null;
                                            txt.Text = dr.GetFloat(i).ToString().Replace(",", ".");

                                            break;

                                        default:
                                            txt.Text = dr.GetValue(i).ToString();
                                            break;

                                    }


                                    Label label = new Label();
                                    label.Visible = false;
                                    label.Top = i * (txt.Height + 2) + 25 + title_X.Top + title_X.Height;
                                    
                                    label.Left = 5;
                                    label.AutoSize = !true;
                                    label.Text = dr.GetName(i).ToString();
                                    label.Width = 400;
                                    
                                    
                                    label.Parent = this;


                                    _titles.Add(label);

                                    //расстановка на контроле
                                    txt.Top = label.Top;
                                    txt.Left = label.Width +label.Left + 50;
                                    txt.Width = 450;

                                    _list.Add(txt);

                                   
                                }

                                else
                                {
                                    _titles[i].Text = dr.GetName(i).ToString();
                                    _list[i].Name = dr.GetName(i);


                                    MaskedTextBox txt = _list[i];
                                    switch (dr.GetFieldType(i).Name.ToLower())
                                    {
                                        case "datetime":
                                            txt.Mask = "00/00/0000";
                                            txt.ValidatingType = DateTime.Now.GetType();
                                            break;

                                        case "int":
                                            txt.Mask = "00000";
                                            txt.Text = dr.GetFloat(i).ToString().Replace(",", "");
                                            break;

                                        case "float":
                                            txt.Mask = "## ###.00";
                                           
                                            txt.Text = dr.GetFloat(i).ToString().Replace(",", ".");


                                            break;

                                        case "double":
                                            txt.Mask = "## ###.00";
                           
                                            txt.Text = dr.GetFloat(i).ToString().Replace(",", ".");

                                            break;

                                        default:
                                            txt.Text = dr.GetValue(i).ToString();
                                            break;

                                    }
                                    _list[i] = txt;
                       

                                }

                            }
                        }
                    }

                    dr.Close();
                }


                this.AutoScroll = true;

                //данные есть будем схранятся
                SaveIt.Enabled = !false;


            }//db connection


            //если данные есть то покажем их
            if (_list != null)
            {
                //позиция последней строки ввода 
                int last_top = 0;

                //SaveIt.Hide();
                if (_list.Count > 0)
                {
                    foreach (var t in _list)
                    {

                        t.Visible = true;
                        
                    }
                    foreach (var t in _titles.AsParallel())
                    {
                        t.Visible = true;
                    }


                    last_top = _list.Last().Top + _list.Last().Height + 50;
                    

                }

                SaveIt.Top = title_X.Top    ;
                SaveIt.Left = title_X.Width + title_X.Left + 100;

                if (!SaveIt.Visible)
                        SaveIt.Show();


                SaveIt.Enabled = !false;

            }// list


        } //загрузка


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
            DataUpdated = false;

            SaveIt.Enabled = false;

            if (_ID_Value == "")
            {
                MessageBox.Show("Данные были сохранены.");
                return;
            }


            using (db = new FastCore.FastCore())
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

                SQL = SQL + Col_Val + "  OUTPUT  Inserted.[" + _ID_name + "]  " + WHERE;

                if (db.ExecSQLScalar(SQL,null) == null)
                    MessageBox.Show("Не могу сохранить данные!");

                //данные обновлены 29-01 статус
                DataUpdated = !false;

                //специально стираем, чтобы не было ошибок
                this._ID_Value = "";

                //var p = (MainWindow)Main;

                SaveIt.Enabled = false;
                //без параметров
                //SaveIt.Top  = 


                //Вызов функции обновления экрана и Прочих фишек
                _call_update.DynamicInvoke() ;
                
            }
        }//SaveIt


        /// <summary>
        /// Мышь зашла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_Editor_Row_In_DB_MouseEnter(object sender, EventArgs e)
        {

            /*var p = agreementEditorWindow;
            p.listView_agreemtns.Enabled = false;
            p.listView_Clients.Enabled = false;   */

            //this.BackColor = Color.Black;
            //this.ForeColor = Color.Orange;
            
        }

        private void UC_Editor_Row_In_DB_MouseLeave(object sender, EventArgs e)
        {
          
        }
    }
}

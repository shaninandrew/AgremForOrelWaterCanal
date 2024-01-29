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
    public partial class ListViewForDataPoint : UserControl
    {

        private string Last_SQL = "";
        private List<SqlParameter> Last_params = null;

        public string SQL = "";
        public List<SqlParameter> sql_params = null;


        private UC_Editor_Row_In_DB editor = null;



        /// <summary>
        /// Название контрола
        /// </summary>
        /// <param name="s"></param>
        public void Title(string s)
        {
            LVC_Title.Text = s;
        }





        /// <summary>
        /// Редактор таблиц встроенный
        /// </summary>
        /// <param name="title"></param>
        public ListViewForDataPoint(MainWindow main)
        {
            InitializeComponent();
            Title("Редактор таблиц");

            Action refresh = Refresh;

            editor = new UC_Editor_Row_In_DB(this.PanelForEditor, refresh, main);
            editor.Dock = DockStyle.Fill;


        }

        /// <summary>
        /// Обновление данных при смене строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Guid = LVC.SelectedItems[0].SubItems["Guid"].Text;

                editor.LoadData("PriceList", "Guid", Guid, "[Service] ,[Price]  ,[Date_start]    ,[Date_end] ");
            }
            catch (Exception ex)
            { }

        }


        /// <summary>
        /// Обновление списка данных
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sql_params_"></param>
        public void UpdateMainScreen(string sql, List<SqlParameter> sql_params_ = null)
        {

            //Связка
            SQL = sql;
            sql_params = sql_params_;

            //-- смохраняем выделенную позицию
            int selected_item = 0;
            Point scrollTo = LVC.AutoScrollOffset;
            if (this.LVC.SelectedItems != null)
            {
                if (this.LVC.SelectedItems.Count > 0)
                {
                    selected_item = this.LVC.SelectedItems[0].Index;

                }

            }

            // Соединение с БД и наполение данными

            ConnectorDB Data_point = new ConnectorDB();
            this.LVC.Items.Clear();
            this.LVC.Columns.Clear();

            List<string> Groups = new List<string>();

            LVC.View = View.Details;

            //Красивая визуалка
            /*var p = this;
            var Main = parent_core;
            Main.Progresso.Value = 0; */
            //--------------


            SqlDataReader dr = Data_point.ExecSQL(SQL, sql_params);

            if (dr != null)
            {
                //считываем строку из БД
                while (dr.Read())
                {
                    if (!dr.HasRows) break;

                    if (this.LVC.Columns.Count == 0)
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

                            this.LVC.Columns.Add(ch);
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

                            //Сортировать по последней колонке дат!!!
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

                    //Main.Progresso.Value = (Main.Progresso.Value + 10) % Main.Progresso.Maximum;
                    lv_row.UseItemStyleForSubItems = true;
                    lv_row.SubItems[1].ForeColor = Color.Coral;

                    //ГШРуппировка по датам
                    lv_row.Group = new ListViewGroup(Date_for_group);


                    var item = this.LVC.Items.Add(lv_row);

                    if (Groups.IndexOf(Date_for_group) == -1)
                    {
                        Groups.Add(Date_for_group);
                        this.LVC.Groups.Add("Дата", Date_for_group);


                    }
                    var group = this.LVC.Groups[this.LVC.Groups.Count - 1];
                    group.Items.Add(item);
                    group.Footer = " "; //разрыв дял визуалки
                    //group.Subtitle  = " Дата";

                }

                dr.Close();
            }//if

            Data_point.Dispose();

            //Main.Progresso.Value = 0;
            this.LVC.ShowGroups = true;

            //---Восстановление сохраненной позы ====
            if (this.LVC.Items.Count > selected_item)
            {
                this.LVC.Items[selected_item].Selected = true;
                this.LVC.AutoScrollOffset = scrollTo;
                this.LVC.EnsureVisible(selected_item);
            }




        } //Update Main screen

        public void Refresh()
        {
            UpdateMainScreen(SQL, sql_params);

        }
        private void ListViewForDataPoint_Load(object sender, EventArgs e)
        {

        }

        private void PanelForEditor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

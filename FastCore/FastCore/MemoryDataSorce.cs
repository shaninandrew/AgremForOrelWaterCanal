using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCore
{
    public class MemoryDataSource
    {

        public System.Data.DataSet DataSet { get; set; } = null;
        
        string _connection_string =  null;
        /// <summary>
        /// Конструктор
        /// </summary>
        public MemoryDataSource( string connection_string )
        { 
            _connection_string = connection_string;
            DataSet = new System.Data.DataSet();
            DataSet.Clear();
        }


        /// <summary>
        /// Считывает из БД данные
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="sql_params"></param>
        /// <param name="table_name">Имя таблицы в памяти</param>
        /// <returns></returns>
        public bool Load(string SQL, List<SqlParameter> sql_params,string table_name="table")
        {
            int ix = DataSet.Tables.IndexOf(table_name);
            if (ix == -1) 
                { DataSet.Tables.Add(table_name); }
            else
                { DataSet.Tables[ix].Clear(); }
            
            FastCore fastCore = new FastCore(_connection_string);
            SqlDataReader dr =  fastCore.ExecSQL(SQL, sql_params);
            //нет данных - выход
            if (dr == null)
            {
                fastCore.Dispose();
                return false;
            }

            DataSet.Load(dr, System.Data.LoadOption.OverwriteChanges, new string[] { table_name});

            fastCore.Dispose();
            return true;
        }

    }
}

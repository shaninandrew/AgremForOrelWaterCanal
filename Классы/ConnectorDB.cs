using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Doc4Lab
{
    public  class ConnectorDB  :IDisposable
    {
        /*
         * Data Source=10.1.1.8; Initial Catalog=ovk; Integrated Security=False; Persist Security Info=False; User ID=userovk; password=Lehtym13; Connect Timeout=20; TrustServerCertificate=False
         * */


        private string _Connection_string = "Server=10.1.1.8; Database=Docs; Integrated Security=False; Persist Security Info=False; User ID=userovk; password=Lehtym13; Connect Timeout=30; Trusted_Connection=True; TrustServerCertificate=True;";

        private SqlConnection connection = null;
        private bool disposedValue;

        private SqlCommand cmd = null;


        /// <summary>
        /// Создает точку подключания к БД
        /// </summary>
        /// <param name="connection_string"></param>
        public ConnectorDB(string connection_string = "") 
        {
            if (connection_string !="")
                _Connection_string=connection_string;
        }


        /// <summary>
        /// Выполняет запрос и возрващает DataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sql_params"></param>
        /// <returns></returns>
        public SqlDataReader ExecSQL(string sql , List<SqlParameter> sql_params = null)
        {
            SqlDataReader r = null;
            try
            {
                if (connection == null)
                {
                    connection = new System.Data.SqlClient.SqlConnection(_Connection_string);
                    connection.Open();
                }

                //открываем снова
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection = new System.Data.SqlClient.SqlConnection(_Connection_string);
                    connection.Open();
                }

                //если открыто ок 
                if (connection.State == System.Data.ConnectionState.Open)
                    {
                        cmd = connection.CreateCommand();

                        cmd.CommandText = sql;
                        if  (sql_params !=null)
                            cmd.Parameters.AddRange(sql_params.ToArray());

                        r = cmd.ExecuteReader();
                        
                        return (r); //возврат готового редера
                     }

            }
             catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.Source);

                if (cmd!=null)
                    cmd.Dispose();

                //закрываем соедениение
                connection.Close();
                connection.Dispose();
                connection = null;

                
            }

            return null;
        }



        /// <summary>
        /// Выполняет запрос вида Select A from Table.
        /// ExecuteScalar.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecSQL(string sql)
        {
            
            try
            {
                if (connection == null)
                {
                    connection = new System.Data.SqlClient.SqlConnection(_Connection_string);
                    connection.Open();
                }

                //открываем снова
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection = new System.Data.SqlClient.SqlConnection(_Connection_string);
                    connection.Open();
                }

                //если открыто ок 
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = sql;

                    string s = cmd.ExecuteScalar().ToString();

                    cmd.Dispose();

                    connection.Close();
                    connection.Dispose();
                    connection = null;

                    return (s); //возврат готового результат
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.Source);

                if (cmd!=null)
                    cmd.Dispose();

                //закрываем соедениение
                connection.Close();
                connection.Dispose();
                connection = null;
            }

            return null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты)
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~ConnectorDB()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            try
            {
                if (cmd!=null)
                    cmd.Dispose();

                cmd = null;
            }
            catch (Exception ex)
            {
            }


            try
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch
            { }
            finally
            {
                connection = null;
            }

            

            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }


   
}

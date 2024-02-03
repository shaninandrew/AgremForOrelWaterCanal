namespace FastCore
{
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Data.Common;
    using System.Net.Security;
    using System.Security.AccessControl;
    using System.Diagnostics;

    /// <summary>
    /// Класс библитеки подключения к БД
    /// </summary>
    public class FastCore : IDisposable
    {
        private string _connection_string = "Server=localhost; ";

        private SqlConnection connection = null;

        private bool _disposed = false;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connection_string">Строка подключение</param>
        public FastCore(string connection_string = "")
        {

            if (connection_string != "")
            {
                _connection_string = connection_string;
            }

            try
            {
                ReConnect();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace.ToString());
            }

        }//конструктор


        /// <summary>
        /// Выполняет запрос и возвращает DataReader
        /// </summary>
        /// <param name="SQL">Запрос</param>
        /// <param name="sql_params">Список параметров</param>
        /// <returns></returns>
        public SqlDataReader ExecSQL(string SQL, List<SqlParameter>? sql_params)
        {
            while (!ReConnect())
            {
                Thread.Sleep(1000);

            }
            SqlCommand sqlCommand = new SqlCommand(SQL, connection);
            sqlCommand.Parameters.Clear();

            if (sql_params != null)
                sqlCommand.Parameters.AddRange(sql_params.ToArray());

            SqlDataReader dr = sqlCommand.ExecuteReader();
            return dr;


            return null;
        }

        public string ExecSQLScalar(string SQL, List<SqlParameter>? sql_params)
        {
            string data = "";
            while (!ReConnect())
            {
                Thread.Sleep(1000);

            }

            using (SqlCommand sqlCommand = new SqlCommand(SQL, connection))
            {
                sqlCommand.Parameters.Clear();
                if (sql_params != null)
                    sqlCommand.Parameters.AddRange(sql_params.ToArray());

                data = sqlCommand.ExecuteScalar().ToString();

            }

            return data;
        }//Exec SQL Scalar


        /// <summary>
        /// Уничтожение объекта
        /// </summary>
        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }

            GC.Collect();
            GC.SuppressFinalize(this);
            _disposed = true;
        }//Dispose



        private bool ReConnect()
        {
            if (connection != null)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
            }


            try
            {
                connection = new SqlConnection(_connection_string);
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace.ToString());

                //Паузим
                Thread.Sleep(100);
                return false;
            }

        }  //ReConnect


        public  bool CloseConnection()
        {
            if (connection != null)
            {
                    connection.Close();
                    return true;
                
            }
            return false;
        }

    }
        
}

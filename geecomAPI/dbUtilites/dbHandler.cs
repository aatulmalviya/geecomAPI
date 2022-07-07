using System;
using geecomAPI.data;
using MySql.Data.MySqlClient;

namespace geecomAPI.dbUtilites
{
    public class DbHandler
    {
        private MySqlConnection _connection;
        private MySqlCommand _command;

        public DbHandler()
        {
            _connection = new MySqlConnection();
            _connection.ConnectionString = constantProps.dbconn;
        }

        public MySqlParameterCollection Parameters
        {
            get { return _command.Parameters; }
            set
            {
                foreach (MySqlParameter param in value)
                    _command.Parameters.Add(param);
            }
        }

        public bool OpenConnection()
        {
            try
            {
                _connection.Open();
                _command = new MySqlCommand() { Connection = _connection };
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        throw new Exception("Cannot connect to server. Contact administrator !");

                    case 1045:
                        throw new Exception("Invalid username/password. Please check your connection string and try again !");
                }
                return false;
            }
            return true;
        }

        private bool CloseConnection()
        {
            try
            {
                _connection.Close();
                _refreshCommand(null);
                return true;
            }
            catch (MySqlException ex)
            {
                if (ex.InnerException == null)
                    throw new Exception(ex.Message);
                throw new Exception(ex.InnerException.Message);
            }
        }

        public int ExecuteStoredProcedure(string name)
        {
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.CommandText = name;
            int count = _command.ExecuteNonQuery();

            _refreshCommand(_connection);
            return count;
        }

        private void _refreshCommand(MySqlConnection con)
        {
            _command = new MySqlCommand() { Connection = con };
        }


    }
}

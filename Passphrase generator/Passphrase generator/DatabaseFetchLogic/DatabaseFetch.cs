using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace Passphrase_generator.DatabaseFetchLogic
{
    class DatabaseFetch
    {
        private static string connectionString;

        MySqlConnection conn = new MySqlConnection(connectionString);
        public DatabaseFetch()
        {
            connectionString = "server=localhost;database=passgen;userid=root;password=sqlmc123;";
            conn.Open();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;
using System.Data.Entity;

namespace Passphrase_generator.DatabaseFetchLogic
{
    class DatabaseFetch : DbContext
    {
        private static string connectionString;

        public DatabaseFetch() : base("MySqlDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
    }
}

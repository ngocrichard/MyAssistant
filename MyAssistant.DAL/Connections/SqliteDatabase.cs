using Ninject;
using System.Configuration;

namespace MyAssistant.DAL
{
    public class SqliteDatabase : ISqliteDatabase
    {
        #region Constructor

        [Inject]
        public SqliteDatabase()
        {
#if (DEBUG)
            ConnectionString = ConfigurationManager.ConnectionStrings["DebugDb"].ConnectionString;
#else
            ConnectionString = ConfigurationManager.ConnectionStrings["ReleaseDb"].ConnectionString;
#endif
        }

        public SqliteDatabase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        #endregion

        #region Connection string

        /// <summary>
        /// Use this connection string to connect to database
        /// </summary>
        public string ConnectionString { get; set; }

        #endregion
    }
}

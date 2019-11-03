using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MyAssistant.DAL
{
    public class DapperRepository
    {
        #region Constructor

        protected ISqliteDatabase sqliteDb;

        public DapperRepository(ISqliteDatabase sqliteDb)
        {
            this.sqliteDb = sqliteDb;
        }

        #endregion

        #region Fetch

        /// <summary>
        /// Excute SELECT query
        /// </summary>
        /// <typeparam name="T">Type of model</typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>List of models from database that auto mapped by Dapper</returns>
        public List<T> Fetch<T>(string query, object parameters = null)
        {
            using IDbConnection connection = new SQLiteConnection(sqliteDb.ConnectionString);
            try
            {
                var output = connection.Query<T>(query, parameters).AsList();
                return output;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        #endregion

        #region Insert

        /// <summary>
        /// Excute INSERT query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>Id of new record, return null if cannot insert</returns>
        public long? InsertAndGetId(string query, object parameters)
        {
            using SQLiteConnection connection = new SQLiteConnection(sqliteDb.ConnectionString);
            try
            {
                // Open connection in order to get id of the last row inserted
                connection.Open();
                int affectedRow = connection.Execute(query, parameters);
                // Check if any record inserted
                if (affectedRow == 0)
                    throw new SQLiteException("Cannot insert to database.");
                // Try to get the inserted id
                return connection.LastInsertRowId;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        #endregion

        #region Modify

        /// <summary>
        /// Excute UPDATE/DELETE query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>Number of rows affected</returns>
        public async Task<int> Modify(string query, object parameters)
        {
            using SQLiteConnection connection = new SQLiteConnection(sqliteDb.ConnectionString);
            try
            {
                // Open connection in order to get id of the last row inserted
                connection.Open();
                return await Task.Run(() => connection.Execute(query, parameters));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return 0;
            }
        }

        #endregion
    }
}

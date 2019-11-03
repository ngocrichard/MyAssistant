using MyAssistant.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAssistant.DAL
{
    public class AppRepository : DapperRepository, IAppRepository
    {
        #region Table info

        public string TableApps { get; } = "apps";
        public string ColumnId { get; } = "Id";
        public string ColumnName { get; } = "Name";
        public string ColumnPath { get; } = "Path";

        #endregion

        #region Constructor

        public AppRepository(ISqliteDatabase sqliteDb) : base(sqliteDb) { }

        #endregion

        #region Queries

        public List<AppModel> SelectAllApps()
        {
            string query = $"SELECT * FROM {TableApps}";
            return Fetch<AppModel>(query);
        }

        public long? InsertNewApp(string name, string path)
        {
            string query = $"INSERT INTO {TableApps} ({ColumnName}, {ColumnPath}) VALUES (@Name, @Path)";
            var parammeters = new { Name = name, Path = path };
            // Insert to database and get new record id
            var id = InsertAndGetId(query, parammeters);
            // If cannot insert then return null
            if (id == null)
                return null;
            return id.Value;
        }

        public async Task<bool> UpdateAppById(long id, string name, string path)
        {
            // Query for each condition
            string query = GetQueryForUpdateApp(name, path);
            // If both name and path is null then nothing we can do
            if (string.IsNullOrEmpty(query))
                return true;
            // Parameters
            var parameters = new { Id = id, Name = name, Path = path };
            // Excute query
            int affectedRows = await Modify(query, parameters);
            return affectedRows != 0;
        }

        public async Task<bool> DeleteAppById(long id)
        {
            string query = $"DELETE FROM {TableApps} WHERE {ColumnId} = @Id";
            // Parameters
            var parameters = new { Id = id };
            // Excute query
            int affectedRows = await Modify(query, parameters);
            return affectedRows != 0;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Get query for excuting
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns>Query for excuting, null if both name and path is null</returns>
        public string GetQueryForUpdateApp(string name, string path)
        {
            // If both name and path is null, return null
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(path))
                return null;

            // If name is null, update only path
            if (string.IsNullOrEmpty(name))
                return $"UPDATE {TableApps} SET {ColumnPath} = @Path WHERE {ColumnId} = @Id";

            // If path is null update only name
            if (string.IsNullOrEmpty(path))
                return $"UPDATE {TableApps} SET {ColumnName} = @Name WHERE {ColumnId} = @Id";

            // If both name and path is not null, update both
            return $"UPDATE {TableApps} SET {ColumnName} = @Name, {ColumnPath} = @Path WHERE {ColumnId} = @Id";
        }

        #endregion
    }
}

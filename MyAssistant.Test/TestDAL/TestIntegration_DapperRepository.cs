using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAssistant.DAL;
using System.IO;

namespace MyAssistant.Test.TestDAL
{
    /*
     * SAMPLE DATA:
     * - Id, Name, Path
     * + 1, Name1, Path1
     * + 2, Name2, Path2
     */

    [TestClass]
    // Copy sample database and SQLite library to deployment directory
    [DeploymentItem(SOURCE_PATH)]
    [DeploymentItem("x64", "x64")]
    [DeploymentItem("x86", "x86")]
    public class TestIntegration_DapperRepository
    {
        public const string SOURCE_PATH = @"ForTesting\db_test.db";
        public const string TARGET_PATH = @"db_test.db";
        public const string TEMP_PATH = @"db_test_temp.db";
        public AppRepository AppRepo;

        /// <summary>
        /// Initialize database for each test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Copy database for each test
            File.Copy(TARGET_PATH, TEMP_PATH);
            // Connect to temp database
            var connectionString = @"Data Source=.\" + $"{TEMP_PATH}; Version=3;";
            AppRepo = new AppRepository(new SqliteDatabase(connectionString));
        }

        /// <summary>
        /// Clean up after each test
        /// </summary>
        [TestCleanup]
        public void Clean()
        {
            // Delete temp database after each test
            File.Delete(TEMP_PATH);
        }
    }
}
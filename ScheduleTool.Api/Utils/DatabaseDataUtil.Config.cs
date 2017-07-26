namespace ScheduleTool.Api.Utils
{
    public partial class DatabaseDataUtil
    {
        private const string DatabaseName = "scheduleTool";
        private const string DeafultDatabase = "localhost";

        // Tables
        private enum DbTable
        {
            Commands,
            ScheduleTasks,
            Log
        }
    }
}
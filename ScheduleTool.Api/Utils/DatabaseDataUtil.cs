

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using RethinkDb.Driver;
using RethinkDb.Driver.Ast;
using RethinkDb.Driver.Net;
using ScheduleTool.Api.Model;

namespace ScheduleTool.Api.Utils
{
    public partial class DatabaseDataUtil
    {
        private static DatabaseDataUtil _instance;
        public static DatabaseDataUtil Instance => _instance ?? (_instance = new DatabaseDataUtil());
        private static readonly RethinkDB R = RethinkDB.R;
        private readonly Connection _connection;
        private static bool _initialized;

        private DatabaseDataUtil()
        {
            var hostName = Environment.GetEnvironmentVariable("DATABASE") ?? DeafultDatabase;
            Console.WriteLine($"Connecting to database: {hostName}");
            var ips = Dns.GetHostAddressesAsync(hostName).Result.ToList();
            ips.ForEach(d => Console.WriteLine(d.ToString()));
            try
            {
                _connection = R.Connection()
                    .Hostname(hostName)
                    .Port(RethinkDBConstants.DefaultPort)
                    .Timeout(60)
                    .Connect();
            }
            catch (Exception ex)
            {
                if (!ips.Any())
                {
                    throw new HttpException(HttpStatusCode.InternalServerError, ex.Message);
                }
                _connection = R.Connection()
                    .Hostname(ips.First().MapToIPv4().ToString())
                    .Port(RethinkDBConstants.DefaultPort)
                    .Timeout(60)
                    .Connect();
            }
            CheckAndPopulateIfNeeded();
        }

        private Table GetTable(DbTable table)
        {
            return R.Db(DatabaseName).Table(table.ToString());
        }

        private void CheckAndPopulateIfNeeded()
        {
            if (_initialized) return;
            var list = R.DbList().Run<List<string>>(_connection);
            if (!list.Contains(DatabaseName))
            {
                R.DbCreate(DatabaseName).Run(_connection);
            }
            var tables = R.Db(DatabaseName).TableList().RunResult<List<string>>(_connection);
            foreach (DbTable dbTable in Enum.GetValues(typeof(DbTable)))
            {
                if(!tables.Contains(dbTable.ToString()))
                R.Db(DatabaseName).TableCreate(dbTable.ToString()).Run(_connection);
            }
            _initialized = true;
        }

        private string GetNewUuid()
        {
            return R.Uuid().RunResult<string>(_connection);
        }
    }
}

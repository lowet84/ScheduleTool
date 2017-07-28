using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ScheduleTool.Api.Model;

namespace ScheduleTool.Api.Utils
{
    public partial class DatabaseDataUtil
    {
        public void Log(LogItem logItem)
        {
            if (logItem.id != null)
            {
                return;
            }
            logItem.id = GetNewUuid();
            var result = GetTable(DbTable.Log).Insert(logItem).Run(_connection);
        }
    }
}

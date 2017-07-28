using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RethinkDb.Driver.Net;
using ScheduleTool.Api.Model;

namespace ScheduleTool.Api.Utils
{
    public partial class DatabaseDataUtil
    {
        public Dictionary<string, string> GetAllSchedules()
        {
            Cursor<ScheduleTask> cursor = GetTable(DbTable.ScheduleTasks).Run<ScheduleTask>(_connection);
            return cursor.ToDictionary(d => d.id, d => d.Name);
        }

        public ScheduleTask GetScheduleTask(string id)
        {
            return GetTable(DbTable.ScheduleTasks).Get(id).RunResult<ScheduleTask>(_connection);
        }

        public string AddScheduleTask(ScheduleTask task)
        {
            if (task.id != null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "Cannot add a schedule task that already has an id. It might already exist.");
            }
            task.id = GetNewUuid();
            var result = GetTable(DbTable.ScheduleTasks).Insert(task).Run(_connection);
            return task.id;
        }

        public void UpdateScheduleTask(ScheduleTask task)
        {
            if (task.id == null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "Task id cannot be null");
            }
            var table = GetTable(DbTable.ScheduleTasks);
            var existing = table.Get(task.id).RunResult<ScheduleTask>(_connection);
            if (existing == null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "No task matching id");
            }

            table.Get(task.id).Update(task).Run(_connection);
        }

        public void DeleteScheduleTask(string id)
        {
            var table = GetTable(DbTable.ScheduleTasks);
            var existing = table.Get(id).RunResult<ScheduleTask>(_connection);
            if (existing == null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "No task matching id");
            }
            table.Get(id).Delete().Run(_connection);
        }

        public List<ScheduleTask> GetAllScheduleTasks()
        {
            Cursor<ScheduleTask> cursor = GetTable(DbTable.ScheduleTasks).Run<ScheduleTask>(_connection);
            return cursor.ToList();
        }
    }
}

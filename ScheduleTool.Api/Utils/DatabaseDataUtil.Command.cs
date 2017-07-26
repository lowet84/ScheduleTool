using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyModel;
using RethinkDb.Driver.Ast;
using RethinkDb.Driver.Net;
using ScheduleTool.Api.Model;

namespace ScheduleTool.Api.Utils
{
    public partial class DatabaseDataUtil
    {
        public Dictionary<string, string> GetAllCommands()
        {
            Cursor<RunCommand> cursor = GetTable(DbTable.Commands).Run<RunCommand>(_connection);
            return cursor.ToDictionary(d => d.id, d => d.Name);
        }

        public RunCommand GetCommand(string id)
        {
            return GetTable(DbTable.Commands).Get(id).RunResult<RunCommand>(_connection);
        }

        public string AddCommand(RunCommand command)
        {
            if (command.id != null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "Cannot add a command that already has an id. It might already exist.");
            }
            command.id = GetNewUuid();
            var result = GetTable(DbTable.Commands).Insert(command).Run(_connection);
            return command.id;
        }

        public void UpdateCommand(RunCommand command)
        {
            if (command.id == null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "Command id cannot be null");
            }
            var table = GetTable(DbTable.Commands);
            var existing = table.Get(command.id).RunResult<RunCommand>(_connection);
            if (existing == null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "No command matching id");
            }

            table.Get(command.id).Update(command).Run(_connection);
        }

        public void DeleteCommand(string id)
        {
            var table = GetTable(DbTable.Commands);
            var existing = table.Get(id).RunResult<RunCommand>(_connection);
            if (existing == null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "No command matching id");
            }
            table.Get(id).Delete().Run(_connection);
        }
    }
}

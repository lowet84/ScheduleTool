using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleTool.Api.Model;
using ScheduleTool.Api.Utils;

namespace ScheduleTool.Api.Controllers
{
    [Route("api/[controller]")]
    public class CommandController : Controller
    {
        [HttpGet]
        public Dictionary<string,string> Get()
        {
            return DatabaseDataUtil.Instance.GetAllCommands();
        }

        [HttpGet("{id}")]
        public RunCommand Get(string id)
        {
            return DatabaseDataUtil.Instance.GetCommand(id);
        }

        [HttpPost]
        public string Post([FromBody] RunCommand command)
        {
            return DatabaseDataUtil.Instance.AddCommand(command);
        }

        [HttpPut]
        public void Put([FromBody] RunCommand command)
        {
            DatabaseDataUtil.Instance.UpdateCommand(command);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            DatabaseDataUtil.Instance.DeleteCommand(id);
        }
    }
}

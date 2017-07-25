using Microsoft.AspNetCore.Mvc;
using ScheduleTool.Api.Model;
using ScheduleTool.Api.Utils;

namespace ScheduleTool.Api.Controllers
{
    [Route("api/[controller]")]
    public class RunController : Controller
    {
        [HttpPost]
        public string Run([FromBody] RunCommand command)
        {
            return RunUtil.Run(command);
        }

        [HttpGet("{id}")]
        public string RunCommand(string id)
        {
            var command = DatabaseDataUtil.Instance.GetCommand(id);
            return command != null ? RunUtil.Run(command) : "Command does not exist!";
        }
    }
}

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
    public class ScheduleController : Controller
    {
        [HttpGet]
        public Dictionary<string,string> Get()
        {
            return DatabaseDataUtil.Instance.GetAllSchedules();
        }

        [HttpGet("{id}")]
        public ScheduleTask Get(string id)
        {
            return DatabaseDataUtil.Instance.GetScheduleTask(id);
        }

        [HttpPost]
        public string Post([FromBody] ScheduleTask task)
        {
            return DatabaseDataUtil.Instance.AddScheduleTask(task);
        }

        [HttpPut]
        public void Put([FromBody] ScheduleTask task)
        {
            DatabaseDataUtil.Instance.UpdateScheduleTask(task);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            DatabaseDataUtil.Instance.DeleteScheduleTask(id);
        }
    }
}

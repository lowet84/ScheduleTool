using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleTool.Api.Model
{
    public abstract class ModelBase
    {
        // ReSharper disable once InconsistentNaming, RethinkDb equires name to be "id" and not "Id"
        public string id { get; set; }
    }
}

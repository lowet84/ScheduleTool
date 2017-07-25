namespace ScheduleTool.Api.Model
{
    public class RunCommand : ModelBase
    {
        public string Name { get; set; }
        public string Application { get; set; }
        public string Arguments { get; set; }
        public string WorkDir { get; set; }
    }
}

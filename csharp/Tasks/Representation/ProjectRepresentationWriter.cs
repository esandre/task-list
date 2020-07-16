namespace Tasks.Representation
{
    internal class ProjectRepresentationWriter
    {
        private readonly IConsole _console;
        private readonly TaskRepresentationWriter _taskRepresentationWriter;

        public ProjectRepresentationWriter(IConsole console)
        {
            _console = console;
            _taskRepresentationWriter = new TaskRepresentationWriter(console);
        }

        public void Show(Project project)
        {
            _console.WriteLine(project.Name);

            foreach (var task in project.Tasks)
            {
                _taskRepresentationWriter.Write(task);
            }

            _console.WriteLine();
        }
    }
}

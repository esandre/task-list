namespace Tasks.Representation
{
    internal class TaskRepresentationWriter
    {
        private readonly IConsole _console;

        public TaskRepresentationWriter(IConsole console)
        {
            _console = console;
        }

        public void Write(Task task)
        {
            var doneRepresentation = task.Done ? 'x' : ' ';
            var taskRepresentation = $"    [{doneRepresentation}] {task.Id}: {task.Description}";
            _console.WriteLine(taskRepresentation);
        }
    }
}

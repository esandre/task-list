namespace Tasks.Representation
{
    internal class TaskRepresentation
    {
        private readonly Task _task;

        public TaskRepresentation(Task task)
        {
            _task = task;
        }

        public override string ToString()
        {
            var doneRepresentation = _task.Done ? 'x' : ' ';
            return $"    [{doneRepresentation}] {_task.Id}: {_task.Description}";
        }
    }
}

using System.Collections.Generic;

namespace Tasks
{
    internal class Project
    {
        private readonly UniqueTaskIdProvider _taskIdProvider;
        private readonly ICollection<Task> _tasks;

        public Project(string name, UniqueTaskIdProvider taskIdProvider)
        {
            Name = name;
            _taskIdProvider = taskIdProvider;
            _tasks = new List<Task>();
        }

        public string Name { get; }
        public IEnumerable<Task> Tasks => _tasks;
        public void AddTaskWithDescription(string taskDescription)
        {
            _tasks.Add(new Task(_taskIdProvider.NextId(), taskDescription));
        }
    }
}

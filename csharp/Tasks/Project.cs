using System.Collections.Generic;

namespace Tasks
{
    internal class Project
    {
        private readonly ICollection<Task> _tasks;

        public Project(string name)
        {
            Name = name;
            _tasks = new List<Task>();
        }

        public string Name { get; }
        public IEnumerable<Task> Tasks => _tasks;
        public void AddTask(Task task) => _tasks.Add(task);
    }
}

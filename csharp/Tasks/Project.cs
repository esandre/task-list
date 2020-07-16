using System.Collections.Generic;

namespace Tasks
{
    internal class Project
    {
        private readonly ICollection<Task> _tasks;

        public Project(string key)
        {
            Key = key;
            _tasks = new List<Task>();
        }

        public string Key { get; }
        public IEnumerable<Task> Value => _tasks;
        public void Add(Task task) => _tasks.Add(task);
    }
}

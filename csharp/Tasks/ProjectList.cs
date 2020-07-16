using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    internal class ProjectList : IEnumerable<Project>
    {
        private readonly UniqueTaskIdProvider _taskIdProvider;

        public ProjectList(UniqueTaskIdProvider taskIdProvider)
        {
            _taskIdProvider = taskIdProvider;
        }

        private readonly ICollection<Project> _projects = new List<Project>();

        public void AddProjectWithName(string projectName) => _projects.Add(new Project(projectName, _taskIdProvider));

        public IEnumerator<Project> GetEnumerator() => _projects.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

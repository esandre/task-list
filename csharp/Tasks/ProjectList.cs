using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    internal class ProjectList : IEnumerable<Project>
    {
        private readonly ICollection<Project> _projects = new List<Project>();

        public void Add(Project project) => _projects.Add(project);

        public IEnumerator<Project> GetEnumerator() => _projects.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

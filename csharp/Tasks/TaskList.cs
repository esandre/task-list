using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.Representation;

namespace Tasks
{
	public sealed class TaskList
    {
        private const string Prompt = "> ";
		private const string Quit = "quit";
        private const string ShowCommand = "show";
        private const string AddCommand = "add";
        private const string CheckCommand = "check";
        private const string UncheckCommand = "uncheck";
        private const string HelpCommand = "help";
        private const string ProjectSubcommand = "project";
        private const string TaskSubCommand = "task";

        private readonly ICollection<Project> _projects;
		private readonly IConsole _console;
        private readonly UniqueTaskIdProvider _taskIdProvider;

        public TaskList(IConsole console)
		{
			_console = console;
			_projects = new List<Project>();
			_taskIdProvider = new UniqueTaskIdProvider();
		}

		public void Run()
		{
			while (true) {
				_console.Write(Prompt);
				var command = _console.ReadLine();
				if (command == Quit) {
					break;
				}
				Execute(command);
			}
		}

		private void Execute(string commandLine)
		{
			var commandRest = commandLine.Split(" ".ToCharArray(), 2);
			var command = commandRest[0];
			switch (command) {
			case ShowCommand:
				Show();
				break;
			case AddCommand:
				Add(commandRest[1]);
				break;
			case CheckCommand:
				CheckTask(commandRest[1]);
				break;
			case UncheckCommand:
				UncheckTask(commandRest[1]);
				break;
			case HelpCommand:
				Help();
				break;
			default:
				Error(command);
				break;
			}
		}

		private void Show()
		{
			foreach (var project in _projects) {
				_console.WriteLine(project.Name);
				foreach (var task in project.Tasks) {
					var representation = new TaskRepresentation(task);
					_console.WriteLine(representation.ToString());
				}
				_console.WriteLine();
			}
		}

		private void Add(string commandLine)
		{
			var subcommandRest = commandLine.Split(" ".ToCharArray(), 2);
			var subcommand = subcommandRest[0];
			if (subcommand == ProjectSubcommand) {
				AddProject(subcommandRest[1]);
			} else if (subcommand == TaskSubCommand) {
				var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 2);
				AddTaskWithDescriptionToProject(projectTask[0], projectTask[1]);
			}
		}

		private void AddProject(string name)
		{
			_projects.Add(new Project(name, _taskIdProvider));
		}

        private Project FindProject(string projectKey) => _projects.SingleOrDefault(project => project.Name == projectKey);

        private void AddTaskWithDescriptionToProject(string projectName, string taskDescription)
        {
            var projectFound = FindProject(projectName);
			if(projectFound is null)
            {
				Console.WriteLine("Could not find a project with the name \"{0}\".", projectName);
				return;
			}

            projectFound.AddTaskWithDescription(taskDescription);		
        }

		private void CheckTask(string idString)
		{
			SetTaskDone(idString, true);
		}

		private void UncheckTask(string idString)
		{
			SetTaskDone(idString, false);
		}

		private void SetTaskDone(string idString, bool done)
		{
			var id = int.Parse(idString);

			var identifiedTask = _projects
				.Select(project => project.Tasks.FirstOrDefault(task => task.Id == id))
                .FirstOrDefault(task => task != null);

			if (identifiedTask == null) {
				_console.WriteLine("Could not find a task with an ID of {0}.", id);
				return;
			}

			if(done) identifiedTask.Check();
            else identifiedTask.Uncheck();
        }

		private void Help()
		{
			_console.WriteLine("Commands:");
			_console.WriteLine($"  {ShowCommand}");
			_console.WriteLine($"  {AddCommand} {ProjectSubcommand} <project name>");
			_console.WriteLine($"  {AddCommand} {TaskSubCommand} <project name> <task description>");
			_console.WriteLine($"  {CheckCommand} <task ID>");
			_console.WriteLine($"  {UncheckCommand} <task ID>");
			_console.WriteLine();
		}

		private void Error(string command)
		{
			_console.WriteLine("I don't know what the command \"{0}\" is.", command);
		}
	}
}

namespace Tasks
{
	public class Task
	{
        public Task(long id, string description)
        {
            Id = id;
            Description = description;
            Done = false;
        }

		public long Id { get; }

		public string Description { get; }

		public bool Done { get; private set; }

        public void Check()
        {
            Done = true;
        }

        public void Uncheck()
        {
            Done = false;
        }
	}
}

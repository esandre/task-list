namespace Tasks
{
    public static class Program
    {
        public static void Main()
        {
            new TaskListRunner(new RealConsole()).Run();
        }
    }
}

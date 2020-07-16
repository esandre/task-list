namespace Tasks
{
    public static class Program
    {
        public static void Main()
        {
            new TaskList(new RealConsole()).Run();
        }
    }
}

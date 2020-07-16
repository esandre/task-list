namespace Tasks
{
    internal class UniqueTaskIdProvider
    {
        private readonly object _lock = new object();
        private long _lastId;

        public long NextId()
        {
            lock (_lock)
            {
                _lastId++;
                return _lastId;
            }
        }
    }
}

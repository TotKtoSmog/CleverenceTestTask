namespace CleverenceTestTask.Задание_2
{
    public static class Server
    {
        private static int _count = 0;
        private static readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            _lock.EnterReadLock();
            try
            {
                return _count;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public static void AddToCount(int count)
        {
            _lock.EnterWriteLock();
            try
            {
                _count += count;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        #if DEBUG
        public static void Clear()
        {
            _lock.EnterWriteLock();
            try
            {
                _count = 0;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
        #endif
    }
}

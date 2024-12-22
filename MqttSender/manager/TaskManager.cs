namespace MqttSender.manager
{
    /**
     * Manages all tasks from all robots
     *
     * Feature 1: based on the series of task from robots,
     *  tracts which task is completed or which task should be generated next.
     *
     * - This should maintain the order of the queue
     * - This is only effective after when user attempts to publish messages
     * Todo: handle all types of robots - use Robot type
     * 
     */
    public class TaskManager
    {
        
        private static TaskManager _instance;

        // Lock object for thread safety
        private static readonly object _lock = new object();
        
        private TaskManager() { }
        
        public static TaskManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new TaskManager();
                    }
                }
            }
            return _instance;
        }
        
        //Initialize user input data - enqueue all robots with tasks
        
        //Dequeue
        
        //Flush queue
        
        //Get all queue
        
        //get total task duration
        
    }
}
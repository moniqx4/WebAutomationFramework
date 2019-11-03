namespace AutomationUtilityLibrary.Logger
{
    public class Logger : ILogger
    {
        private readonly string _testName;

        public Logger(string testName)
        {
            _testName = testName;
        }

        public void Log(string message)
        {
            System.Console.WriteLine($"{_testName} : {message}");
        }

        public void Log(string message, params object[] param)
        {
            System.Console.WriteLine(message, param);
        }
    }
}

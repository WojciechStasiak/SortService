namespace SortService.Helpers
{
    // custom exception class for throwing application specific exceptions (e.g. for validation) 
    // that can be caught and handled within the application
    public class CustomException: Exception
    {
        public CustomException() : base() {}

        public CustomException(string message) : base(message) { }

        public CustomException(string message, params object[] args) 
            : base(String.Format(message, args))
        {
        }
    }
}
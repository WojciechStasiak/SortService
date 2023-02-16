using SortService.Helpers;

namespace SortService.Services
{
    public interface ISortService
    {
        List<int> Sort(string multipleValues);
        List<int> Reverse(string multipleValues);
    }
    public class SortingService : ISortService
    {
        List<int> numberList = new List<int>();
        private readonly ILogger _logger;

        public SortingService(ILogger<SortingService> logger)
        {
            _logger = logger;
        }

        // sorts the numbers with descending order
        public List<int> Reverse(string multipleValues)
        {
            _logger.LogInformation("Reverse invoked with string value: " + multipleValues);
            GetNumbersFromString(multipleValues);
            return numberList.OrderByDescending(v => v).ToList();
        }

        // sorts the numbers with ascending order
        public List<int> Sort(string multipleValues)
        {
            _logger.LogInformation("Sort invoked with string value: " + multipleValues);
            GetNumbersFromString(multipleValues);
            return numberList.OrderBy(v => v).ToList();
        }

        // gets only numbers from string
        private void GetNumbersFromString(string multipleValues)
        {
            if(multipleValues == "")
                throw new CustomException("The incoming data is empty!");

            string integerString = string.Empty;
            foreach (char c in multipleValues)
            {
                if (char.IsDigit(c))
                {
                    integerString += c;
                }
                else if (integerString.Length > 0)
                {
                    numberList.Add(int.Parse(integerString));
                    integerString = "";
                }
            }

            if (integerString != "")
                numberList.Add(int.Parse(integerString));

            if (numberList.Count == 0)
                throw new CustomException("The list is empty!");
        }
    }
}

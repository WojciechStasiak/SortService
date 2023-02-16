using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace SortServiceTest
{
    public class SortServiceTest
    {
        [Fact]
        public async Task Sort_WhenCalledWithGivenValues_ReturnsSortedListOfThatValues()
        {
            var sortedValues = "[2,23,343]";
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/sorting/sort/23fd343sf2");
            var data = await response.Content.ReadAsStringAsync();

            Assert.Equal(sortedValues, data);

        }
        [Fact]
        public async Task Reverse_WhenCalledWithGivenValues_ReturnsSortedDescendingListOfThatValues()
        {
            var sortedValues = "[343,23,2]";
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/sorting/reverse/23fd343sf2");
            var data = await response.Content.ReadAsStringAsync();

            Assert.Equal(sortedValues, data);

        }
    }
}
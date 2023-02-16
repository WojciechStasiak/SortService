using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using SortService.Controllers;
using SortService.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SortServiceTest
{
    public class SortServiceTest
    {
        [Fact]
        public async Task SortTest()
        {
            // arrange
            var values = "243 34 5 55";
            var sortedValues = new List<int>() {5, 34, 55, 243};
            
            var mockSortService = new Mock<ISortService>();
            mockSortService
                .Setup(service => service.Sort(values))
                .Returns(new List<int>() { 5, 34, 55, 243 });
            var cont = new SortController(mockSortService.Object);

            // act
            var result = await cont.Sort(values);

            // assert
            Assert.Equal(sortedValues, result);
        }

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
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI;
using Xunit;

namespace WebAPITestProject
{
    public class MethodsTest
    {
        [Fact]
        public void SwapTest()
        {
            List<int> zee = new List<int>();
            zee.Add(6);
            zee.Add(3);
            zee.Add(9);
            zee.Swap(2, 1);
            Assert.True(zee[2] == 3);
        }

        [Fact]
        public void SortTest()
        {
            List<int> input = new List<int>() { 5, 1, 4, 9, 10, 111, 90, 5, 1, 0 };
            List<int> result = new List<int>() { 0, 1, 1, 4, 5, 5, 9, 10, 90, 111 };
            input.BubbleSort();
            Assert.True(input.SequenceEqual(result));

            input = new List<int>() { 5, 4, 3, 7, 8, 9 };
            result = new List<int>() { 3, 4, 5, 7, 8, 9 };
            input.BubbleSort();
            Assert.True(input.SequenceEqual(result));
        }
    }
}

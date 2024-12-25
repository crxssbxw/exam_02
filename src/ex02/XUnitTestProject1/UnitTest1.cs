using System;
using Xunit;
using ex02;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Graph graph = new Graph();
            graph.SetKolchugino();

            bool expected = true;
            bool result = graph.adjaencyMatrix[1, 0];

            Assert.Equal(expected, result);
        }
    }
}

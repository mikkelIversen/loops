using System;
using Xunit;


namespace StringTests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            String inputString = "ABC";
            char seperatorChar = '-';
            String expected = "A-B-C-";
            
            Assert.Equal(Strings.Program.AddSeparator(inputString, seperatorChar), expected);
        }
    }
}
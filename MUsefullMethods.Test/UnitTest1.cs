using System;
using System.Diagnostics;
using Xunit;

namespace MUsefullMethods.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Should_GenerateUpperCode()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Debug.WriteLine(StringHelpers.GenerateUpperCode());
                }
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void Should_GenerateUniqueCode()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Debug.WriteLine(StringHelpers.GenerateUniqueCode());
                }
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                Assert.True(false);
            }
        }
    }
}

using System;
using System.Diagnostics;
using Xunit;

namespace MUsefulMethods.Test
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
                    Trace.WriteLine(StringHelpers.GenerateUpperCode());
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
                    Trace.WriteLine(StringHelpers.GenerateUniqueCode());
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

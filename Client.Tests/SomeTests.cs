namespace Client.Tests
{
    using Xunit;

    public class SomeTests
    {
        [Fact]
        public void ThisIsATest()
        {
            var client = ApiFactory.CreateClient();
        }
    }
}

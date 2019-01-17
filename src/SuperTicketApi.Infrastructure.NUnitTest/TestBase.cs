namespace SuperTicketApi.Infrastructure.NUnitTest
{
    /// <summary>
    /// Base class of all tests
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase"/> class.
        /// </summary>
        protected TestBase()
        {
            this.TestHelper = new TestHelper();
        }

        /// <summary>
        /// Gets the test helper.
        /// </summary>
        public ITestHelper TestHelper { get; }
    }
}

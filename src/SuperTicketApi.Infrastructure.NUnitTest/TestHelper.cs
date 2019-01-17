namespace SuperTicketApi.Infrastructure.NUnitTest
{
    using System;

    using Moq;

    /// <summary>
    /// The test helper.
    /// </summary>
    internal class TestHelper : ITestHelper
    {
        /// <summary>
        /// The make mock.
        /// </summary>
        /// <param name="mockSetups">
        /// The mock setups.
        /// </param>
        /// <typeparam name="T">Mocked <c>object</c>
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T MakeMock<T>(params Action<Mock<T>>[] mockSetups)
            where T : class
        {
            var mock = new Mock<T>();

            foreach (var mockSetup in mockSetups)
            {
                mockSetup(mock);
            }

            return mock.Object;
        }
    }
}
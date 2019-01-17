namespace SuperTicketApi.Infrastructure.NUnitTest
{
    using System;

    using Moq;

    /// <summary>
    /// The TestHelper interface.
    /// </summary>
    public interface ITestHelper
    {
        /// <summary>
        /// Create mock object of the T type
        /// </summary>
        /// <typeparam name="T">Mocked type</typeparam>
        /// <param name="mockSetups">Actions which should set the mock up</param>
        /// <returns>Mock object with set up</returns>
        T MakeMock<T>(params Action<Mock<T>>[] mockSetups)
            where T : class;
    }
}
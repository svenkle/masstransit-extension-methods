using MassTransit;
using Xunit;

namespace Svenkle.MassTransitExtensionMethods.Tests
{
    public class BusExtensionsTests
    {
        public class TheGetSendEndpointMethod : BusExtensionsTests
        {
            [Fact]
            public void ReturnsNullIfBusIsNull()
            {
                // Prepare & Act
                var endpoint = ((IBus)null).GetSendEndpoint("q");

                // Assert
                Assert.Null(endpoint);
            }
        }
    }
}

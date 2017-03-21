using System;
using MassTransit;

namespace Svenkle.MassTransitExtensionMethods
{
    public static class PublishEndpointExtensions
    {
        public static void Publish(this IPublishEndpoint publishEndpoint, Type interfaceType, object message)
        {
            var method = typeof(PublishEndpointExtensions).GetMethod(nameof(CallPublishEndpointPublish));
            var genericMethod = method.MakeGenericMethod(interfaceType);
            genericMethod.Invoke(null, new[] { publishEndpoint, message });
        }

        private static void CallPublishEndpointPublish<T>(IPublishEndpoint publishEndpoint, T message) where T : class
        {
            publishEndpoint.Publish(message);
        }
    }
}

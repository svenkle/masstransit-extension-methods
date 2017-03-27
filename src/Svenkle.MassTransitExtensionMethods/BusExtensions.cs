using System;
using System.Threading.Tasks;
using MassTransit;
using Svenkle.ExtensionMethods;

namespace Svenkle.MassTransitExtensionMethods
{
    public static class BusExtensions
    {
        public static Task<ISendEndpoint> GetSendEndpoint(this IBus bus, string queue)
        {
            return bus?.GetSendEndpoint(new Uri($"{bus.Address.GetBaseUri()}/{queue}"));
        }

        public static IRequestClient<TRequest, TResponse> CreateRequestClient<TRequest, TResponse>(this IBus bus, string queue, TimeSpan timeout, TimeSpan? ttl = null, Action<SendContext<TRequest>> callback = null) where TRequest : class where TResponse : class
        {
            return bus.CreateRequestClient<TRequest, TResponse>(new Uri($"{bus.Address.GetBaseUri()}/{queue}"), timeout, ttl, callback);
        }
    }
}
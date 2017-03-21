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
            return bus.GetSendEndpoint(new Uri($"{bus.Address.GetBaseUri()}/{queue}"));
        }
    }
}

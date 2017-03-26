using System;
using System.Reflection;
using MassTransit;

namespace Svenkle.MassTransitExtensionMethods
{
    public static class SendEndpointExtensions
    {
        public static void Send(this ISendEndpoint sendEndpoint, Type interfaceType, object message)
        {
            var method = typeof(SendEndpointExtensions).GetMethod(nameof(CallSendEndpointSend), BindingFlags.NonPublic | BindingFlags.Static);
            var genericMethod = method.MakeGenericMethod(interfaceType);
            genericMethod.Invoke(null, new[] { sendEndpoint, message });
        }

        private static void CallSendEndpointSend<T>(ISendEndpoint sendEndpoint, T message) where T : class
        {
            sendEndpoint.Send(message);
        }
    }
}

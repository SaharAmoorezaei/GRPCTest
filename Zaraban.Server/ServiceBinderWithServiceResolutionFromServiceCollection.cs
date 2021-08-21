
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Zaraban.Server
{
    internal class ServiceBinderWithServiceResolutionFromServiceCollection : ServiceBinder
    {
        private readonly IServiceCollection services;

        public ServiceBinderWithServiceResolutionFromServiceCollection(IServiceCollection services)
        {
            this.services = services;
        }

        public override IList<object> GetMetadata(MethodInfo method, Type contractType, Type serviceType)
        {
            var resolvedServiceType = serviceType;
            if (serviceType.IsInterface)
                resolvedServiceType = services.SingleOrDefault(x => x.ServiceType == serviceType)?.ImplementationType ?? serviceType;

            return base.GetMetadata(method, contractType, resolvedServiceType);
        }
    }
}

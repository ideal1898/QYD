﻿using System.Reflection;

namespace PigRunner.WebApi.Commons.Helpers
{
    /// <summary>
    /// 服务注册类
    /// </summary>
    public static class IOCHelper
    {
        /// <param name="services"></param>
        public static IServiceCollection InjectionAllServices(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Injection(typeof(IScopedService), assemblies, services);
            Injection(typeof(ITransientService), assemblies, services);
            Injection(typeof(ISingletonService), assemblies, services);
            return services;
        }

        private static void Injection(Type type, Assembly[] assemblies, IServiceCollection services)
        {
            var allTypes = assemblies.SelectMany(p => p.DefinedTypes).Select(p => p.AsType()).Where(p => p != type && type.IsAssignableFrom(p));
            var implementTypes = allTypes.Where(x => x.IsClass).ToList();
            var interfaceTypes = allTypes.Where(x => x.IsInterface).ToList();
            foreach (var implementType in implementTypes)
            {
                var interfaceType = interfaceTypes.FirstOrDefault(p => p.IsAssignableFrom(implementType));
                if (interfaceType != null)
                {
                    if (type.Name == nameof(IScopedService))
                    {
                        services.AddScoped(interfaceType, implementType);
                    }
                    else if (type.Name == nameof(ITransientService))
                    {
                        services.AddTransient(interfaceType, implementType);
                    }
                    else if (type.Name == nameof(ISingletonService))
                    {
                        services.AddSingleton(interfaceType, implementType);
                    }
                }
                else
                {
                    if (type.Name == nameof(IScopedService))
                    {
                        services.AddScoped(implementType);
                    }
                    else if (type.Name == nameof(ITransientService))
                    {
                        services.AddTransient(implementType);
                    }
                    else if (type.Name == nameof(ISingletonService))
                    {
                        services.AddSingleton(implementType);
                    }
                }
            }
        }
    }
    /// <summary>
    /// 区域服务接口
    /// </summary>
    public interface IScopedService { }
    /// <summary>
    /// 瞬时接口
    /// </summary>
    public interface ITransientService { }
    /// <summary>
    /// 单例接口
    /// </summary>
    public interface ISingletonService { }
}

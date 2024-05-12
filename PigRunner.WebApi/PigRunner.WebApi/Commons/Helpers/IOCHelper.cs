using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.VisualBasic;
using PigRunner.Public.Interface;
using System.Reflection;

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
            LoadByReferencedAssemblies(services);
            return services;
        }

        private static void LoadByReferencedAssemblies(this IServiceCollection services) {
            Assembly? assembly = Assembly.GetEntryAssembly();
            var types = assembly!.GetReferencedAssemblies()//获取当前程序集所引用的外部程序集
                .Select(Assembly.Load)//装载
                .Concat(new List<Assembly>() { assembly })//与本程序集合并
                .SelectMany(x => x.GetTypes())//获取所有类
                .Distinct();//排重

            Register(typeof(IScopedService), types, services);
            Register(typeof(ITransientService), types, services);
            Register(typeof(ISingletonService), types, services);
        }

        private static void Register(Type type,IEnumerable<Type> types,IServiceCollection services) {
            var allTypes= types.Where(x => x != type && type.IsAssignableFrom(x)).ToList();
            var implementTypes = allTypes.Where(x => x.IsClass).ToList();
            var interfaceTypes = allTypes.Where(x => x.IsInterface).ToList();
            foreach (var implementType in implementTypes)
            {
                var interfaceType = interfaceTypes.FirstOrDefault(p => p.IsAssignableFrom(implementType));
                if (interfaceType != null)
                {
                    Type? tp= implementType.GetInterface(type.Name);
                    if (tp != null) {
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

        private static void InjectByDLL(this IServiceCollection services) {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Injection(typeof(IScopedService), assemblies, services);
            Injection(typeof(ITransientService), assemblies, services);
            Injection(typeof(ISingletonService), assemblies, services);
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
}

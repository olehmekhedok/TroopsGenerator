using System;
using System.Collections.Generic;

namespace Services.ConfigService
{
    public class ConfigService : IConfigService
    {
        private readonly Dictionary<Type, IConfig> _configs = new Dictionary<Type, IConfig>();

        public ConfigService(params IConfig[] configs)
        {
            foreach (var config in configs)
            {
                _configs.Add(config.GetType(), config);
            }
        }

        public T GetConfig<T>() where T : class, IConfig
        {
            return _configs[typeof(T)] as T;
        }
    }
}

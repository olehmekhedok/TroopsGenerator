using System;
using Services.ConfigService;

namespace TroopsGenerator
{
    [Serializable]
    public class TroopsConfig : IConfig
    {
        public TroopConfig[] Troops;
    }

    [Serializable]
    public class TroopConfig
    {
        public string TypeId;

        public string IconId => TypeId;
        public string NameKey => TypeId;
    }
}
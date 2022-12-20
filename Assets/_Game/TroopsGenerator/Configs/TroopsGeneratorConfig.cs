using System;
using Services.ConfigService;
using UnityEngine;

namespace TroopsGenerator
{
    [Serializable]
    public class TroopsGeneratorConfig : IConfig
    {
        [Range(0,1)]
        public float Variety;
    }
}

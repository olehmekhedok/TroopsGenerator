using TroopsGenerator;
using UnityEngine;

namespace Services.ConfigService
{
    [CreateAssetMenu]
    public class GameConfigs : ScriptableObject
    {
        public TroopsConfig TroopsConfig;
        public TroopsGeneratorConfig TroopsGeneratorConfig;
    }
}
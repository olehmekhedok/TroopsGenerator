using Services.FeatureService;

namespace Game.TroopsGenerator
{
    public class TroopsGeneratorFeature : FeatureBase
    {
        public TroopsGeneratorFeature()
        {
            AddController(new InitTroopsGenerator());
            AddController(new TroopsGeneratorController());
        }
    }
}
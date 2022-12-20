using System;
using System.Collections.Generic;
using Game.TroopsGenerator;

namespace Services.FeatureService
{
    public class FeaturesService
    {
        private readonly List<FeatureBase> _features = new List<FeatureBase>();
        private bool _initialized;

        public FeaturesService()
        {
            _features.Add(new TroopsGeneratorFeature());
        }

        public void Init()
        {
            if (_initialized)
            {
                Log.Error("[FeaturesService] is already initialized");
                return;
            }

            _initialized = true;

            foreach (var feature in _features)
            {
                try
                {
                    feature.Init();
                }
                catch (Exception e)
                {
                    Log.Error($"[{GetType()}]" + e);
                }
            }
        }
    }
}

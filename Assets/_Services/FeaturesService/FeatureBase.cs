using System;
using System.Collections.Generic;

namespace Services.FeatureService
{
    public abstract class FeatureBase
    {
        private readonly List<ControllerBase> _controllers = new List<ControllerBase>();

        public void Init()
        {
            foreach (var controller in _controllers)
            {
                try
                {
                    controller.Init();
                }
                catch (Exception e)
                {
                    Log.Error($"[{GetType()}]" + e);
                }
            }
        }

        protected void AddController(ControllerBase controller)
        {
            _controllers.Add(controller);
        }
    }
}
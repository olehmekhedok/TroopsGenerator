using System;
using System.Collections.Generic;
using Services.ResourceService;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.ScreenService
{
    //TODO moq implementation
    public class ScreenService : IScreenService
    {
        private Dictionary<Type, IScreen> _active = new Dictionary<Type, IScreen>();
        private Dictionary<Type, IScreen> _cache = new Dictionary<Type, IScreen>();

        private IResourceService _resourceService;
        private Transform _uiCanvas;

        public ScreenService(IResourceService resourceService, Transform uiCanvas)
        {
            _resourceService = resourceService;
            _uiCanvas = uiCanvas;
        }

        public void OpenScreen<TScreen>()
            where TScreen : ScreenBase, IScreen<NoParam>
        {
            OpenScreen<TScreen, NoParam>(new NoParam());
        }

        public void OpenScreen<TScreen, TParam>(TParam param)
            where TScreen : ScreenBase, IScreen<TParam>
            where TParam : struct, IScreenParam
        {
            var screenType = typeof(TScreen);
            if (_cache.TryGetValue(screenType, out var screen) == false)
            {
                var template = _resourceService.GetScreen<TScreen>();
                screen = Object.Instantiate(template, _uiCanvas);
                _cache.Add(screenType, screen);
            }

            _active[screenType] = screen;
            ((IScreen<TParam>)screen).Open(param);
        }

        public void CloseScreen<TScreen>()
            where TScreen : IScreen
        {
            var screenType = typeof(TScreen);

            if (_active.TryGetValue(screenType, out var screen))
            {
                _active.Remove(screenType);
                screen.Close();
            }
        }
    }
}

using Services.ScreenService;
using UnityEngine;

namespace Services.ResourceService
{
    //TODO draft implementation
    public class ResourceService : IResourceService
    {
        private const string _troopsIconsPrefix = "troops_icons/";
        private const string _screensPrefix = "screens/";

        public Sprite GetSpriteById(string id)
        {
            return Resources.Load<Sprite>(_troopsIconsPrefix + id);
        }

        public T GetScreen<T>() where T : IScreen
        {
            var screen = Resources.Load<GameObject>(_screensPrefix + typeof(T).Name);
            return screen.GetComponent<T>();
        }
    }
}

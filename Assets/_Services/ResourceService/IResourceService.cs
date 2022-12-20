using Services.ScreenService;
using UnityEngine;

namespace Services.ResourceService
{
    public interface IResourceService
    {
        Sprite GetSpriteById(string id);
        T GetScreen<T>() where T : IScreen;
    }
}
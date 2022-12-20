using UnityEngine;

namespace Services.ScreenService
{
    public abstract class ScreenBase : MonoBehaviour, IScreen
    {
        protected abstract void OnClose();

        void IScreen.Close()
        {
            OnClose();
        }
    }
}
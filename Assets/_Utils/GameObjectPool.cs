using System.Collections.Generic;
using Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils
{
    public interface IPoolItem
    {
        void InitItem();
        void TerminateItem();
    }

    public class GameObjectPool<TView> where TView : MonoBehaviour, IPoolItem
    {
        private readonly Stack<TView> _pool = new Stack<TView>();
        private readonly List<TView> _alive = new List<TView>();
        private readonly TView _template;
        private readonly Transform _parent;

        public GameObjectPool(TView template, Transform parent)
        {
            _template = template;
            _parent = parent;
        }

        public TView Pull()
        {
            var newView = _pool.Count > 0 ? _pool.Pop() : Object.Instantiate(_template, _parent);
            _alive.Add(newView);

            return InitItem(newView);
        }

        public void Push(TView value)
        {
            if (value == null)
            {
                Log.Error("value can't be null");
                return;
            }

            _alive.RemoveAll(a => a.GetInstanceID() == value.GetInstanceID());
            _pool.Push(TerminateItem(value));
        }

        public void PushAllAlive()
        {
            foreach (var item in _alive)
            {
                _pool.Push(TerminateItem(item));
            }

            _alive.Clear();
        }

        private TView InitItem(TView value)
        {
            value.gameObject.SetActive(true);
            value.InitItem();

            return value;
        }

        private TView TerminateItem(TView value)
        {
            value.gameObject.SetActive(false);
            value.transform.SetParent(_parent);
            value.TerminateItem();

            return value;
        }
    }
}
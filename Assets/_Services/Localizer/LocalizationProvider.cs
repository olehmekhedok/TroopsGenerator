using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Localizer
{
    [CreateAssetMenu]
    public class LocalizationProvider : ScriptableObject, ILocalizationProvider
    {
        [Serializable]
        public class LocalizationKey
        {
            public string Key;
            public string Text;
        }

        [SerializeField] private List<LocalizationKey> _localization;

        private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();

        public string GetText(string key)
        {
            if (_cache.TryGetValue(key, out var text))
            {
                return text;
            }

            foreach (var localizationKey in _localization)
            {
                if (localizationKey.Key == key)
                {
                    _cache[key] = localizationKey.Text;

                    return localizationKey.Text;
                }
            }

            Log.Warning("[LocalizationProvider] can't find text for key:" + key);

#if UNITY_EDITOR
            return "THIS TEXT IS MISSED";
#endif
#pragma warning disable 162
            return string.Empty;
#pragma warning restore 162
        }
    }
}
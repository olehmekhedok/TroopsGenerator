using TMPro;
using UnityEngine;

namespace Services.Localizer
{
    [RequireComponent(typeof(TMP_Text))]
    public class TMPLocalizer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string _key;

        //TODO DI
        private ILocalizer _localizer;

        private void Awake()
        {
            //TODO DI
            _localizer = FindObjectOfType<GameInitializer>().GetLocalizer;

            _text.text = _localizer.GetText(_key);
        }

        private void OnValidate()
        {
            _text = GetComponent<TMP_Text>();
        }
    }
}
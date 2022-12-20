using Game.TroopsGenerator;
using Services.Localizer;
using Services.ResourceService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace TroopsGenerator
{
    public class TroopView : MonoBehaviour, IPoolItem
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _amount;
        [SerializeField] private Image _icon;

        //TODO DI
        private IResourceService _resourceService;
        private ILocalizer _localizer;

        public void SetData(TroopData troopsData)
        {
            _name.text = _localizer.GetText(troopsData.TypeId);
            _amount.text = troopsData.Amount.ToString();
            _icon.sprite = _resourceService.GetSpriteById(troopsData.TypeId);
        }

        public void InitItem()
        {
            //TODO DI
            var gameLauncher = FindObjectOfType<GameInitializer>();

            _resourceService = gameLauncher.GetResourceService;
            _localizer = gameLauncher.GetLocalizer;
        }

        public void TerminateItem()
        {
        }
    }
}

using Game.TroopsGenerator;
using Services.DataService;
using Services.MessageBus;
using Services.ScreenService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace TroopsGenerator
{
    public class TroopsGeneratorScreen : ScreenBaseParamNoParam
    {
        //TODO DI
        private IMessageBus _messageBus;
        private IDataService _dataService;

        [SerializeField] private Button _generateTroops;
        [SerializeField] private TroopView _template;
        [SerializeField] private Transform _listRoot;
        [SerializeField] private TMP_InputField _amountInput;

        private GameObjectPool<TroopView> _troopsPool;

        private void Awake()
        {
            //TODO DI
            var gameLauncher = FindObjectOfType<GameInitializer>();

            _dataService = gameLauncher.GetDataService;
            _messageBus = gameLauncher.GetMessageBus;

            _troopsPool = new GameObjectPool<TroopView>(_template, _listRoot);
            _troopsPool.Push(_template);

            _generateTroops.onClick.AddListener(OnGenerateButtonClicked);
            _amountInput.onSelect.AddListener(HidePlaceholder);
        }
  
        protected override void OnOpen()
        {
            _messageBus.AddListener<TroopsGeneratedMsg>(OnGenerateTroops);
        }

        protected override void OnClose()
        {
            _messageBus.RemoveListener<TroopsGeneratedMsg>(OnGenerateTroops);
        }

        private void OnGenerateTroops(TroopsGeneratedMsg msg)
        {
            _troopsPool.PushAllAlive();

            var troopsData = _dataService.GetData<TroopsData>();

            for (var i = 0; i < troopsData.Troops.Count; i++)
            {
                var troopData = troopsData.Troops[i];

                if (troopData.Amount > 0)
                {
                    var troop = _troopsPool.Pull();
                    troop.SetData(troopData);
                }
            }
        }

        private void OnGenerateButtonClicked()
        {
            if (int.TryParse(_amountInput.text, out var amount) == false)
                amount = 0;

            _messageBus.Dispatch(new GenerateTroopsMsg(amount));
        }

        private void HidePlaceholder(string _)
        {
            _amountInput.placeholder.gameObject.SetActive(false);
        }
    }
}

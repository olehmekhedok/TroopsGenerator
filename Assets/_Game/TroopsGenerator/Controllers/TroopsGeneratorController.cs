using Services.ConfigService;
using Services.DataService;
using Services.FeatureService;
using Services.MessageBus;
using TroopsGenerator;
using UnityEngine;

namespace Game.TroopsGenerator
{
    public struct GenerateTroopsMsg : IMessage
    {
        public int Amount;

        public GenerateTroopsMsg(int amount)
        {
            Amount = amount;
        }
    }

    public struct TroopsGeneratedMsg : IMessage
    {
    }

    public class TroopsGeneratorController : ControllerBase
    {
        //TODO DI
        private IDataService _dataService;
        private IMessageBus _messageBus;
        private IConfigService _configService;

        public TroopsGeneratorController()
        {
            //TODO DI
            var gameLauncher = Object.FindObjectOfType<GameInitializer>();

            _dataService = gameLauncher.GetDataService;
            _messageBus = gameLauncher.GetMessageBus;
            _configService = gameLauncher.GetConfigService;
        }

        public override void Init()
        {
            _messageBus.AddListener<GenerateTroopsMsg>(OnGenerateTroops);
        }

        private void OnGenerateTroops(GenerateTroopsMsg msg)
        {
            var troopsData = _dataService.GetData<TroopsData>();

            foreach (var troopData in troopsData.Troops)
            {
                troopData.Amount = 0;
            }

            var troopsConfig = _configService.GetConfig<TroopsConfig>();
            var generatorConfig = _configService.GetConfig<TroopsGeneratorConfig>();

            var portion = (float) msg.Amount / troopsConfig.Troops.Length;
            var threshold = portion * generatorConfig.Variety;

            var totalAmount = 0;

            for (var i = 0; i < troopsConfig.Troops.Length - 1; i++)
            {
                var troopAmount = (int) Random.Range(portion - threshold, portion + threshold);
                totalAmount += troopAmount;

                var troop = new TroopData();

                troop.Amount = troopAmount;
                troop.TypeId = troopsConfig.Troops[i].TypeId;

                troopsData.Troops.Add(troop);
            }

            var lastTroop = new TroopData();

            lastTroop.Amount = msg.Amount - totalAmount;
            lastTroop.TypeId = troopsConfig.Troops[troopsConfig.Troops.Length - 1].TypeId;

            troopsData.Troops.Add(lastTroop);

            _messageBus.Dispatch(new TroopsGeneratedMsg());
        }
    }
}

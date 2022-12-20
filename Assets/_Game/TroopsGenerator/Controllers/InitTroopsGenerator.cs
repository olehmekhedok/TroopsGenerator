using Services.ConfigService;
using Services.DataService;
using Services.FeatureService;
using Services.ScreenService;
using TroopsGenerator;
using UnityEngine;

namespace Game.TroopsGenerator
{
    public class InitTroopsGenerator : ControllerBase
    {
        //TODO DI
        private IDataService _dataService;
        private IConfigService _configService;
        private IScreenService _screenService;

        public InitTroopsGenerator()
        {
            //TODO DI
            var gameLauncher = Object.FindObjectOfType<GameInitializer>();
            _dataService = gameLauncher.GetDataService;
            _configService = gameLauncher.GetConfigService;
            _screenService = gameLauncher.GetScreenService;
        }

        public override void Init()
        {
            var troopsData = new TroopsData();

            var troopsConfig = _configService.GetConfig<TroopsConfig>();
            foreach (var config in troopsConfig.Troops)
            {
                troopsData.Troops.Add(new TroopData
                {
                    TypeId = config.TypeId
                });
            }

            _dataService.SetData(troopsData);

            _screenService.OpenScreen<TroopsGeneratorScreen>();
        }
    }
}

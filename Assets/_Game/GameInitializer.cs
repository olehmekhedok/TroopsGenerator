using Services.ConfigService;
using Services.DataService;
using Services.FeatureService;
using Services.Localizer;
using Services.MessageBus;
using Services.ResourceService;
using Services.ScreenService;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameConfigs _gameConfigs;
    [SerializeField] private LocalizationProvider _localizationProvider;
    [SerializeField] private Transform _uiCanvas;

    private IResourceService _resourceService;
    private IConfigService _configService;
    private IScreenService _screenService;
    private ILocalizer _localizer;
    private IDataService _dataService;
    private IMessageBus _messageBus;

    private FeaturesService _featuresService;

    public IResourceService GetResourceService => _resourceService;
    public IConfigService GetConfigService => _configService;
    public IScreenService GetScreenService => _screenService;
    public ILocalizer GetLocalizer => _localizer;
    public IDataService GetDataService => _dataService;
    public IMessageBus GetMessageBus => _messageBus;

    private void Awake()
    {
        _messageBus = new MessageBus();
        _dataService = new DataService();
        _resourceService = new ResourceService();
        _localizer = new Localizer(_localizationProvider);
        _screenService = new ScreenService(_resourceService, _uiCanvas);
        _configService = new ConfigService(_gameConfigs.TroopsConfig, _gameConfigs.TroopsGeneratorConfig);

        _featuresService = new FeaturesService();
        _featuresService.Init();
    }
}

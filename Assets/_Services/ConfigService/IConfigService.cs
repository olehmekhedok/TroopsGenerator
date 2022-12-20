namespace Services.ConfigService
{
    public interface IConfigService
    {
        T GetConfig<T>() where T : class, IConfig;
    }
}
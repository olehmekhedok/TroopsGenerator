namespace Services.Localizer
{
    public interface ILocalizationProvider
    {
        string GetText(string key);
    }
}
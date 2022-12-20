namespace Services.Localizer
{
    public class Localizer : ILocalizer
    {
        private readonly ILocalizationProvider _localizationProvider;

        public Localizer(ILocalizationProvider localizationProvider)
        {
            _localizationProvider = localizationProvider;
        }

        public string GetText(string key)
        {
            return _localizationProvider.GetText(key);
        }
    }
}

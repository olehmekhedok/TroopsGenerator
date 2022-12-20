namespace Services.ScreenService
{
    public interface IScreenService
    {
        void OpenScreen<TScreen>()
            where TScreen : ScreenBase, IScreen<NoParam>;

        void OpenScreen<TScreen, TParam>(TParam param)
            where TScreen : ScreenBase, IScreen<TParam>
            where TParam : struct, IScreenParam;

        void CloseScreen<TScreen>()
            where TScreen : IScreen;
    }
}
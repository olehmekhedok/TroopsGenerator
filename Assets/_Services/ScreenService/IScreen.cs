namespace Services.ScreenService
{
    public interface IScreen
    {
        void Close();
    }

    public interface IScreen<TParam> : IScreen
        where TParam : struct
    {
        void Open(TParam param);
    }
}
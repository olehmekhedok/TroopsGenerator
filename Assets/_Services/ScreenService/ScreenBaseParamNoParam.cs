namespace Services.ScreenService
{
    public abstract class ScreenBaseParamNoParam : ScreenBaseParam<NoParam>
    {
        protected abstract void OnOpen();

        protected sealed override void OnOpen(NoParam param)
        {
            OnOpen();
        }
    }
}
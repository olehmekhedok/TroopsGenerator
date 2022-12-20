namespace Services.ScreenService
{
    public abstract class ScreenBaseParam<TParam> : ScreenBase, IScreen<TParam>
        where TParam : struct
    {
        protected abstract void OnOpen(TParam param);

        void IScreen<TParam>.Open(TParam param)
        {
            OnOpen(param);
        }
    }
}
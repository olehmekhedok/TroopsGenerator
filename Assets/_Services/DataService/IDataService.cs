namespace Services.DataService
{
    public interface IDataService
    {
        T GetData<T>() where T : IData;
        void SetData<T>(T data) where T : IData;
    }
}
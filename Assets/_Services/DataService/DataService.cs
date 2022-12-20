using System;
using System.Collections.Generic;

namespace Services.DataService
{
    //TODO moq implementation
    public class DataService : IDataService
    {
        private readonly Dictionary<Type, IData> _data = new Dictionary<Type, IData>();

        public T GetData<T>() where T : IData
        {
            var type = typeof(T);
            if (_data.TryGetValue(type, out var data))
            {
                return (T) data;
            }

            throw new Exception($"[DataService] {typeof(T)} data not found.");
        }

        public void SetData<T>(T data) where T : IData
        {
            _data[typeof(T)] = data;
        }
    }
}

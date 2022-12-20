using System.Collections.Generic;
using Services.DataService;

namespace Game.TroopsGenerator
{
    public class TroopsData : IData
    {
        public List<TroopData> Troops = new List<TroopData>();
    }
}

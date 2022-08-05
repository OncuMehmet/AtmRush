using System;

namespace Data.ValueObject
{
    public enum CollectableTypes 
    {
        Money = 1,
        Gold = 2,
        Diamond = 3
    }
    [Serializable]
    public class CollectableStateData 
    {
        public CollectableTypes collectableTypes = CollectableTypes.Money;
    }

}
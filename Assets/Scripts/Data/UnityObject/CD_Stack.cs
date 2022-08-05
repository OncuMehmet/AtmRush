using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Stack", menuName = "ATMRush/CD_Stack", order = 0)]
    public class CD_Stack : ScriptableObject
    {
        public StackData data;
    }
}